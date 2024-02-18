using OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace LSystem
{
    public class TreeLoader
    {
        private static void GetTreeInfo(MString word, out float rootThick, out int maxDepth)
        {
            rootThick = 0.0f;
            maxDepth = 0;

            // 한 글자마다 탐색함.
            int idx = 0;
            Stack<float> thickStack = new Stack<float>();
            while (idx < word.Length)
            {
                if (word.Length == 0) break;
                MChar c = word[idx];

                if (c.Alphabet == "!")
                {
                    rootThick = c[0];
                }
                else if (c.Alphabet == "[")
                {
                    thickStack.Push(rootThick);
                    maxDepth = Math.Max(maxDepth, thickStack.Count); 
                }
                else if (c.Alphabet == "]")
                {
                    rootThick = thickStack.Pop();
                }

                idx++;
            }
        }

        private static void CreateLeaf(Pose pose, uint baseIndex, float scaled, float branchLength, out List<float> leafVertexList3D, out List<uint> leafIndices)
        {
            GlobalParam g = LSystemUnif.GlobalParameter;

            leafVertexList3D = new List<float>();
            leafIndices = new List<uint>();

            float leafWidth = g.ContainsKey("leafWidth") ? g["leafWidth"] : 1.0f;
            float leafHeight = g.ContainsKey("leafHeight") ? g["leafHeight"] : 1.0f;

            Vertex3f[] p = new Vertex3f[4];
            p[0] = new Vertex3f(-leafWidth, 0, 0);
            p[1] = new Vertex3f(leafWidth, 0, 0);
            p[2] = new Vertex3f(leafWidth, 0, leafHeight);
            p[3] = new Vertex3f(-leafWidth, 0, leafHeight);

            int leafRotCount = g.ContainsKey("leafRotCount") ? (int)g["leafRotCount"] : 1;
            int unitAngle = (int)(180.0f / (float)leafRotCount);
            int angle = 0;

            uint vertexIndex = 0;
            Vertex2f[] texCoords = new Vertex2f[4] { new Vertex2f(1, 1), new Vertex2f(0, 1), new Vertex2f(0, 0), new Vertex2f(1, 0)};

            Vertex3f forward = pose.Forward().Normalized;

            for (int n = 0; n < leafRotCount; n++)
            {
                Matrix3x3f localRot = ((Matrix3x3f)forward.Rotate(angle).Concatenate(pose.Quaternion)); // 순서중요
                Matrix3x3f localScale = Matrix3x3f.Scaled(1, 1, scaled*branchLength);

                angle += unitAngle;

                for (int i = 0; i < p.Length; i++)
                {
                    Vertex3f leafPos = localRot * localScale * (p[i]) + pose.Postiton * scaled;
                    leafVertexList3D.Add(leafPos);
                    leafVertexList3D.Add(texCoords[i]);
                }

                leafIndices.Add(baseIndex + vertexIndex + 0);
                leafIndices.Add(baseIndex + vertexIndex + 1);
                leafIndices.Add(baseIndex + vertexIndex + 2);
                leafIndices.Add(baseIndex + vertexIndex + 0);
                leafIndices.Add(baseIndex + vertexIndex + 2);
                leafIndices.Add(baseIndex + vertexIndex + 3);
                vertexIndex += 4;
            }
        }

        public static (RawModel3d, RawModel3d) Load(MString sentence, float scaled, string objfilename = "", int resolution = 8)
        {
            GlobalParam g = LSystemUnif.GlobalParameter;

            // 모델 저장을 위한 리스트
            List<float> branchList3D = new List<float>();
            List<uint> branchIndices = new List<uint>();
            List<float> leafVertexList3D = new List<float>();
            List<uint> leafIndices = new List<uint>();

            // 문자열을 순회하면서 경로를 만든다.
            Stack<Pose> stack = new Stack<Pose>();
            Stack<float> thickStack = new Stack<float>();
            Pose pose = new Pose(Quaternion.Identity, Vertex3f.Zero);

            // context-sensitive를 위한 설정
            Stack<string> contextStack = new Stack<string>();
            string branchContext = "";

            // 나무의 기본정보를 가져온다.
            GetTreeInfo(sentence, out float thick, out int maxDepth);

            // 줄기의 밑둥의 큰 원을 만든다.
            float rootThickRatio = g.ContainsKey("rootThickRatio") ? g["rootThickRatio"] : 1.0f;
            float radius = rootThickRatio * thick; // base Root Thick
            Vertex3f[] baseVertor = new Vertex3f[resolution + 1];
            float unitTu = 1.0f / resolution;
            float unitTheta = 360 / resolution;
            for (int i = 0; i <= resolution; i++)
            {
                Vertex3f p = Vertex3f.UnitZ.Rotate(Vertex3f.UnitX * radius, i * unitTheta) * scaled;
                baseVertor[i] = p;
                branchList3D.Add(p.x);          // x
                branchList3D.Add(p.y);          // y
                branchList3D.Add(0);            // z
                branchList3D.Add(unitTu * i);   // tu
                branchList3D.Add(0);            // tv
            }
            branchList3D.Add(Vertex3f.Zero);
            branchList3D.Add(Vertex2f.Zero);

            // 줄기의 밑둥의 큰 원이다.
            Stack<Vertex3f[]> branchBaseStack = new Stack<Vertex3f[]>();
            Stack<uint> baseIndexStack = new Stack<uint>();
            Stack<uint> depthStack = new Stack<uint>();
            baseIndexStack.Push(0);

            int idx = 0;
            float branchLength = 1.0f;
            uint baseIndex = 0;
            uint parentIndex = 0;
            uint depth = 0;
            uint circularVertexCount = (uint)resolution + 2;

            // 한 글자마다 탐색함.
            while (idx < sentence.Length)
            {
                if (sentence.Length == 0) break;
                MChar c = sentence[idx];

                Vertex3f forward = pose.Forward();
                Vertex3f up = pose.Up();
                Vertex3f left = pose.Left();
                Vertex3f start = pose.Postiton;

                float angle = c.Length > 0 ? c[0] : 0.0f;

                if (c.Alphabet == "F")
                {
                    float r = c[0];
                    Vertex3f end = start + forward * r;
                    branchContext += c.Alphabet;
                    branchLength = r;
                    baseIndex += circularVertexCount ;

                    LoadBranch(parentIndex, baseIndex, depth, scaled, baseVertor, start, end, thick,
                        out float[] data, out uint[] indices, out Vertex3f[] q);
                    parentIndex = baseIndex;

                    baseVertor = q;
                    pose.Postiton = end;

                    branchList3D.AddRange(data);
                    branchIndices.AddRange(indices);
                    depth++;

                    // tropism vector modify!
                    Vertex3f H = forward;
                    Vertex3f T = new Vertex3f(g["Tx"], g["Ty"], g["Tz"]);
                    Vertex3f B = H.Cross(T);
                    float alpha = g["e"] * B.Norm();
                    B.Normalize();
                    Vertex3f H1 = B.Rotate(H, alpha).Normalized;
                    Vertex3f L1 = H1.Cross(T).Normalized;
                    Vertex3f U1 = H1.Cross(L1).Normalized;
                    pose.Quaternion = Matrix3x3f.Identity.ToQuaternionFromTNB(L1, U1, H1);

                }
                else if (c.Alphabet == "A")
                {
                    uint baseTriangleIndex = (uint)((leafVertexList3D.Count / 5));
                    CreateLeaf(pose, baseTriangleIndex, scaled, branchLength, out List<float> leafVertices, out List<uint> indices);
                    leafVertexList3D.AddRange(leafVertices.ToArray());
                    leafIndices.AddRange(indices);
                }
                else if (c.Alphabet == "+")
                {
                    pose.Quaternion = up.Rotate(angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "-")
                {
                    pose.Quaternion = up.Rotate(-angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "&")
                {
                    pose.Quaternion = left.Rotate(angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "^")
                {
                    pose.Quaternion = left.Rotate(-angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "\\")
                {
                    pose.Quaternion = forward.Rotate(angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "/")
                {
                    pose.Quaternion = forward.Rotate(-angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "$")
                {
                    Vertex3f V = Vertex3f.UnitZ;
                    Matrix4x4f mat = ((Matrix4x4f)pose.Quaternion);
                    Vertex3f H = mat.ForwardVector().Normalized;
                    Vertex3f L = V.Cross(H).Normalized;
                    Vertex3f U = H.Cross(L).Normalized;
                    pose.Quaternion = Matrix3x3f.Identity.ToQuaternionFromTNB(H, L, U);
                }
                else if (c.Alphabet == "!")
                {
                    thick = c[0];
                }
                else if (c.Alphabet == "[")
                {
                    stack.Push(pose);
                    baseIndexStack.Push(parentIndex);
                    branchBaseStack.Push(baseVertor);
                    depthStack.Push(depth);
                    thickStack.Push(thick);
                    contextStack.Push(branchContext);
                    branchContext = "";
                }
                else if (c.Alphabet == "]")
                {
                    // 줄기의 윗면을 닫는다.
                    for (uint i = 0; i < resolution; i++)
                    {
                        uint a = i;
                        uint b = (uint)((i + 1) % resolution);
                        branchIndices.Add(baseIndex + (uint)resolution + 1);
                        branchIndices.Add(baseIndex + a);
                        branchIndices.Add(baseIndex + b);
                    }

                    // 스택에서 회복된 부모의 정보를 가져온다.
                    pose = stack.Pop();
                    parentIndex = baseIndexStack.Pop();
                    baseVertor = branchBaseStack.Pop();
                    depth = depthStack.Pop();
                    thick = thickStack.Pop();
                    branchContext = contextStack.Pop();
                }

                idx++;
            }

            // raw3d 모델을 만든다.
            float[] vertices = branchList3D.ToArray();
            uint[] fIndices = branchIndices.ToArray();
            int[] splitOpt = new int[] { 3, 2 };
            uint vao = GpuLoader.LoadData(vertices, splitOpt, fIndices, BufferUsage.StaticDraw);
            RawModel3d rawModel = new RawModel3d(vao, vertices, 5, fIndices.Length);
            rawModel.IsDrawElement = true;

            vao = GpuLoader.LoadData(leafVertexList3D.ToArray(), new[] { 3, 2 }, leafIndices.ToArray(), BufferUsage.StaticDraw);
            RawModel3d leafRawModel = new RawModel3d(vao, vertices, 5, fIndices.Length);
            leafRawModel.IsDrawElement = true;

            // obj 파일을 저장하는 옵션이면 
            // ---------------------------------------------------------------
            int stride = 0;
            for (int i = 0; i < splitOpt.Length; i++) stride += splitOpt[i];
            int vidx = 0;

            if (objfilename != "")
            {
                string filename = Path.GetFileNameWithoutExtension(objfilename);

                float[] leaf = leafVertexList3D.ToArray();
                uint[] leafInds = leafIndices.ToArray();
                StreamWriter sw = new StreamWriter(objfilename);
                sw.WriteLine("# WaveFront *.obj file (generated by LSystem)");
                sw.WriteLine("g Tree_small_1");
                sw.WriteLine($"mtllib {filename}.mtl");
                sw.WriteLine($"usemtl {filename}.001");

                sw.WriteLine("# stem");

                for (int i = 0; i < vertices.Length; i += stride) // stem vertices
                {
                    sw.WriteLine($"v {vertices[i]} {vertices[i + 2]} {vertices[i + 1]}");
                    sw.WriteLine($"vt {0.5f * vertices[i + 3]} {1.0f - vertices[i + 4]} 0");
                    vidx++;
                }

                sw.WriteLine("# leaf");
                for (int i = 0; i < leaf.Length; i += stride) // leaf vertices
                {
                    sw.WriteLine($"v {leaf[i]} {leaf[i + 2]} {leaf[i + 1]}");
                    sw.WriteLine($"vt {0.5f + 0.5f * leaf[i + 3]} {1.0f - leaf[i + 4]} 0");
                }

                for (int i = 0; i < fIndices.Length; i += 3)
                {
                    sw.WriteLine($"f {fIndices[i] + 1}/{fIndices[i] + 1} {fIndices[i + 1] + 1}/{fIndices[i + 1] + 1} {fIndices[i + 2] + 1}/{fIndices[i + 2] + 1}");
                }

                for (int i = 0; i < leafInds.Length; i += 3)
                {
                    sw.WriteLine($"f {vidx + leafInds[i] + 1}/{vidx + leafInds[i] + 1} {vidx + leafInds[i + 1] + 1}/{vidx + leafInds[i + 1] + 1} {vidx + leafInds[i + 2] + 1}/{vidx + leafInds[i + 2] + 1}");
                }

                sw.Close();

                sw = new StreamWriter(Path.GetDirectoryName(objfilename) + $"\\{filename}.mtl");
                sw.WriteLine($"newmtl {filename}.001");
                sw.WriteLine("Ns 96.078431");
                sw.WriteLine("Ka 1.000000 1.000000 1.000000");
                sw.WriteLine("Kd 0.640000 0.640000 0.640000");
                sw.WriteLine("Ks 0.000000 0.000000 0.000000");
                sw.WriteLine("Ke 0.000000 0.000000 0.000000");
                sw.WriteLine("Ni 1.000000");
                sw.WriteLine("d 1.000000");
                sw.WriteLine("illum 2");
                sw.WriteLine($"map_Kd {filename}.png");
                sw.Close();
            }

            return (rawModel, leafRawModel);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <param name="baseIndex"></param>
        /// <param name="depth"></param>
        /// <param name="scaled"></param>
        /// <param name="p"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="thick"></param>
        /// <param name="data"></param>
        /// <param name="indices"></param>
        /// <param name="q"></param>
        public static void LoadBranch(uint parentIndex, uint baseIndex, uint depth, float scaled, Vertex3f[] p, Vertex3f start, Vertex3f end, float thick
            ,out float[] data, out uint[] indices, out Vertex3f[] q)
        {
            List<float> vertices = new List<float>();
            List<uint> indexList = new List<uint>();

            uint N = (uint)p.Length - 1;
            q = new Vertex3f[N + 1];
           
            // 이전 단계의 줄기로 새로운 줄기의 윗면의 점들을 계산한다.
            Vertex3f s0 = p[0];
            Vertex3f s = s0 - start;
            Vertex3f f = end - start;
            Vertex3f u = f.Cross(s).Normalized;
            Vertex3f l = u.Cross(f).Normalized;
            q[0] = f + l * (thick);
            float unitDeg = 360.0f / N;

            // 윗면을 만든다.
            Vertex3f r0 = q[0];
            for (int i = 0; i <= N; i++)
            {
                Vertex3f src = f.Rotate(r0, unitDeg * i);
                src += start;
                q[i] = src;

                float tu = (float)i / (float)N;
                float tv = (depth + 1);
                vertices.Add(src * scaled); // 3
                vertices.Add(tu);
                vertices.Add(-tv);
            }
            vertices.Add(end * scaled);
            vertices.Add(0);
            vertices.Add(0);

            // indices
            for (uint i = 0; i < N; i++)
            {
                uint a = (i + 0);
                uint b = (i + 1);

                indexList.Add(parentIndex + a);
                indexList.Add(parentIndex + b);
                indexList.Add(baseIndex + b);
                indexList.Add(parentIndex + a);
                indexList.Add(baseIndex + b);
                indexList.Add(baseIndex + a);
            }

            data = vertices.ToArray();
            indices = indexList.ToArray();

        }

    }
}

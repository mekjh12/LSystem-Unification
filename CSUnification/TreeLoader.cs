using OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystem
{
    public class TreeLoader
    {
        private static float GetRootStemRadius(MString word)
        {
            // 문자열을 순회하면서 경로를 만든다.
            Stack<float> thickStack = new Stack<float>();

            int idx = 0;
            float thick = 0.0f;

            // 한 글자마다 탐색함.
            while (idx < word.Length)
            {
                if (word.Length == 0) break;
                MChar c = word[idx];

                if (c.Alphabet == "!")
                {
                    thick = c[0];
                }
                else if (c.Alphabet == "[")
                {
                    thickStack.Push(thick);
                }
                else if (c.Alphabet == "]")
                {
                    thick = thickStack.Pop();
                }

                idx++;
            }

            return thick;
        }

        private static void CreateLeaf(GlobalParam g, Pose pose, float branchLength, out List<float> leafVertexList3D, out List<float> leafTexCoordList3D)
        {
            leafVertexList3D = new List<float>();
            leafTexCoordList3D = new List<float>();

            float leafWidth = g.ContainsKey("leafWidth") ? g["leafWidth"] : 1.0f;
            float leafHeight = g.ContainsKey("leafHeight") ? g["leafHeight"] : 1.0f;

            Vertex3f[] p = new Vertex3f[6];
            p[0] = new Vertex3f(-leafWidth, 0, -1);
            p[1] = new Vertex3f(leafWidth, 0, -1);
            p[2] = new Vertex3f(leafWidth, 0, leafHeight);
            p[3] = new Vertex3f(-leafWidth, 0, -1);
            p[4] = new Vertex3f(leafWidth, 0, leafHeight);
            p[5] = new Vertex3f(-leafWidth, 0, leafHeight);

            int leafRotCount = (int)g["leafRotCount"];
            int unitAngle = (int)(180.0f / (float)leafRotCount);
            int angle = 0;
            for (int n = 0; n < leafRotCount; n++)
            {
                Matrix3x3f localRot = ((Matrix3x3f)pose.Quaternion.Concatenate(Vertex3f.UnitZ.Rotate(angle)));
                angle += unitAngle;

                for (int i = 0; i < 6; i++)
                {
                    Vertex3f leafPos = localRot * (p[i] * branchLength * 0.5f) + pose.Postiton * 0.01f;
                    leafVertexList3D.Add(leafPos.x);
                    leafVertexList3D.Add(leafPos.y);
                    leafVertexList3D.Add(leafPos.z);
                }

                leafTexCoordList3D.Add(1); leafTexCoordList3D.Add(1);
                leafTexCoordList3D.Add(0); leafTexCoordList3D.Add(1);
                leafTexCoordList3D.Add(0); leafTexCoordList3D.Add(0);
                leafTexCoordList3D.Add(1); leafTexCoordList3D.Add(1);
                leafTexCoordList3D.Add(0); leafTexCoordList3D.Add(0);
                leafTexCoordList3D.Add(1); leafTexCoordList3D.Add(0);
            }

        }

        public static (RawModel3d, RawModel3d) Load(MString word, GlobalParam g, int resolution = 8)
        {
            List<float> list = new List<float>();
            List<float> branchList3D = new List<float>();
            List<float> branchTexcoord = new List<float>();

            List<float> leafVertexList3D = new List<float>();
            List<float> leafTexCoordList3D = new List<float>();

            // 문자열을 순회하면서 경로를 만든다.
            Stack<Pose> stack = new Stack<Pose>();
            Pose pose = new Pose(Quaternion.Identity, Vertex3f.Zero);
            Stack<float> thickStack = new Stack<float>();

            // 줄기의 밑둥의 큰 원이다.
            Vertex3f[] baseVertor = null;
            Stack<Vertex3f[]> branchBaseStack = new Stack<Vertex3f[]>();

            // context-sensitive를 위한 설정
            Stack<string> contextStack = new Stack<string>();
            string branchContext = "";

            int idx = 0;
            float thick = 2.0f * GetRootStemRadius(word);
            float branchLength = 1.0f;

            // 한 글자마다 탐색함.
            while (idx < word.Length)
            {
                if (word.Length == 0) break;
                MChar c = word[idx];
                Matrix4x4f matQuaternion = (Matrix4x4f)pose.Matrix4x4f;
                Vertex3f forward = matQuaternion.ForwardVector();
                Vertex3f up = matQuaternion.UpVector();
                Vertex3f left = matQuaternion.LeftVector();

                if (baseVertor == null)
                {
                    baseVertor = new Vertex3f[resolution];
                    float radius = thick;
                    float unitTheta = 360 / baseVertor.Length;
                    for (int i = 0; i < baseVertor.Length; i++)
                    {
                        baseVertor[i] = Vertex3f.UnitZ.Rotate(Vertex3f.UnitX * radius, i * unitTheta);
                    }
                }

                if (c.Alphabet == "F")
                {
                    float r = c[0] * LSystemUnif.RandomVertex2f.x;
                    Vertex3f start = pose.Postiton;
                    Vertex3f end = start + forward * r;
                    branchContext += c.Alphabet;
                    branchLength = forward.Norm();

                    list.Add(start.x);
                    list.Add(start.y);
                    list.Add(start.z);
                    list.Add(end.x);
                    list.Add(end.y);
                    list.Add(end.z);

                    (float[] res, Vertex3f[] rot) = LoadBranch(baseVertor, start, end, thick, false);
                    branchList3D.AddRange(res);

                    //branchLength, thick
                    float uvUnit = 1 / (float)(baseVertor.Length);
                    float uv = 0.0f;
                    for (int i = 0; i < baseVertor.Length; i++)
                    {
                        branchTexcoord.Add(uv); branchTexcoord.Add(0.0f);
                        branchTexcoord.Add(uv + uvUnit); branchTexcoord.Add(0.0f);
                        branchTexcoord.Add(uv); branchTexcoord.Add(1.0f);
                        branchTexcoord.Add(uv); branchTexcoord.Add(1.0f);
                        branchTexcoord.Add(uv + uvUnit); branchTexcoord.Add(0.0f);
                        branchTexcoord.Add(uv + uvUnit); branchTexcoord.Add(1.0f);
                        uv += uvUnit;
                    }

                    baseVertor = rot;

                    pose.Postiton = end;

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
                else if (c.Alphabet == "f")
                {
                    float r = c[0];
                    Vertex3f start = pose.Postiton;
                    Vertex3f end = start + forward * r;
                    branchContext += c.Alphabet;

                    list.Add(start.x);
                    list.Add(start.y);
                    list.Add(start.z);
                    list.Add(end.x);
                    list.Add(end.y);
                    list.Add(end.z);

                    pose.Postiton = end;
                }
                else if (c.Alphabet == "A")
                {
                    CreateLeaf(g, pose, branchLength, out List<float> leafVertices, out List<float> leafTexCoords);
                    leafVertexList3D.AddRange(leafVertices.ToArray());
                    leafTexCoordList3D.AddRange(leafTexCoords.ToArray());
                }
                else if (c.Alphabet == "+")
                {
                    float angle = c[0];
                    pose.Quaternion = up.Rotate(angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "-")
                {
                    float angle = c[0];
                    pose.Quaternion = up.Rotate(-angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "&")
                {
                    float angle = c[0];
                    pose.Quaternion = left.Rotate(angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "^")
                {
                    float angle = c[0];
                    pose.Quaternion = left.Rotate(-angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "\\")
                {
                    float angle = c[0];
                    pose.Quaternion = forward.Rotate(angle).Concatenate(pose.Quaternion);
                }
                else if (c.Alphabet == "/")
                {
                    float angle = c[0];
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
                    branchBaseStack.Push(baseVertor);
                    thickStack.Push(thick);
                    contextStack.Push(branchContext);
                    branchContext = "";
                }
                else if (c.Alphabet == "]")
                {
                    pose = stack.Pop();
                    baseVertor = branchBaseStack.Pop();
                    thick = thickStack.Pop();
                    branchContext = contextStack.Pop();
                }

                idx++;
            }

            for (int i = 0; i < branchList3D.Count; i++)
            {
                branchList3D[i] = branchList3D[i] * 0.01f;
            }

            // raw3d 모델을 만든다.
            uint vao = Gl.GenVertexArray();
            Gl.BindVertexArray(vao);
            uint vbo = StoreDataInAttributeList(0, 3, branchList3D.ToArray());
            StoreDataInAttributeList(1, 2, branchTexcoord.ToArray());
            Gl.BindVertexArray(0);
            RawModel3d rawModel = new RawModel3d(vao, branchList3D.ToArray());


            vao = Gl.GenVertexArray();
            Gl.BindVertexArray(vao);
            StoreDataInAttributeList(0, 3, leafVertexList3D.ToArray());
            StoreDataInAttributeList(1, 2, leafTexCoordList3D.ToArray());
            Gl.BindVertexArray(0);
            RawModel3d leafRawModel = new RawModel3d(vao, leafVertexList3D.ToArray());
            return (rawModel, leafRawModel);
        }


        /// <summary>
        /// 줄기의 모델을 읽어온다.
        /// </summary>
        /// <param name="startNPolygon">이전 단계의 줄기 윗면의 점들</param>
        /// <param name="start">줄기의 시작 지점</param>
        /// <param name="end">줄기가 끝나는 지점</param>
        /// <param name="ratioThick">줄기의 단면의 반지름의 줄어드는 비율</param>
        /// <returns></returns>
        private static (float[], Vertex3f[] endNPolygon) LoadBranch(Vertex3f[] startNPolygon,
            Vertex3f start, Vertex3f end, float ratioThick, bool isRelativesize)
        {
            List<float> positionList = new List<float>();
            int num = startNPolygon.Length;
            Vertex3f[] evec = new Vertex3f[num];

            // 이전 단계의 굵기를 계산하여 다음 단계의 굵기를 계산한다.
            float maxThick = float.MinValue;
            for (int i = 0; i < startNPolygon.Length; i++)
            {
                float d = (startNPolygon[0] - startNPolygon[i]).Norm();
                maxThick = Math.Max(maxThick, d);
            }
            float baseThick = maxThick * 0.5f;
            float terminalThick = baseThick * ratioThick;

            // 이전 단계의 줄기로 새로운 줄기의 윗면의 점들을 계산한다.
            Vertex3f s0 = startNPolygon[0];
            Vertex3f s = s0 - start;
            Vertex3f f = end - start;
            Vertex3f u = f.Cross(s).Normalized;
            Vertex3f l = u.Cross(f).Normalized;
            evec[0] = f + l * (ratioThick);
            float unitDeg = 360.0f / num;

            // 윗면을 만든다.
            Vertex3f r0 = evec[0];
            for (int i = 0; i < num; i++)
            {
                Vertex3f src = f.Rotate(r0, unitDeg * i);
                evec[i] = src + start;
            }

            // 아랫면과 윗면의 점들로 옆면을 만든다.
            for (int i = 0; i < num; i++)
            {
                positionList.Add(startNPolygon[(i + 0) % num].x);
                positionList.Add(startNPolygon[(i + 0) % num].y);
                positionList.Add(startNPolygon[(i + 0) % num].z);
                positionList.Add(startNPolygon[(i + 1) % num].x);
                positionList.Add(startNPolygon[(i + 1) % num].y);
                positionList.Add(startNPolygon[(i + 1) % num].z);
                positionList.Add(evec[(i + 0) % num].x);
                positionList.Add(evec[(i + 0) % num].y);
                positionList.Add(evec[(i + 0) % num].z);

                positionList.Add(evec[(i + 0) % num].x);
                positionList.Add(evec[(i + 0) % num].y);
                positionList.Add(evec[(i + 0) % num].z);
                positionList.Add(startNPolygon[(i + 1) % num].x);
                positionList.Add(startNPolygon[(i + 1) % num].y);
                positionList.Add(startNPolygon[(i + 1) % num].z);
                positionList.Add(evec[(i + 1) % num].x);
                positionList.Add(evec[(i + 1) % num].y);
                positionList.Add(evec[(i + 1) % num].z);
            }

            float[] positions = positionList.ToArray();

            return (positions, evec);
        }

        public static unsafe uint StoreDataInAttributeList(uint attributeNumber, int coordinateSize, float[] data, BufferUsage usage = BufferUsage.StaticDraw)
        {
            // VBO 생성
            uint vboID = Gl.GenBuffer();

            // VBO의 데이터를 CPU로부터 GPU에 복사할 때 사용하는 BindBuffer를 다음과 같이 사용
            Gl.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            Gl.BufferData(BufferTarget.ArrayBuffer, (uint)(data.Length * sizeof(float)), data, usage);

            // 이전에 BindVertexArray한 VAO에 현재 Bind된 VBO를 attributeNumber 슬롯에 설정
            Gl.VertexAttribPointer(attributeNumber, coordinateSize, VertexAttribType.Float, false, 0, IntPtr.Zero);
            //Gl.VertexArrayVertexBuffer(glVertexArrayVertexBuffer, vboID, )

            // GPU 메모리 조작이 필요 없다면 다음과 같이 바인딩 해제
            Gl.BindBuffer(BufferTarget.ArrayBuffer, 0);

            return vboID;
        }

    }
}

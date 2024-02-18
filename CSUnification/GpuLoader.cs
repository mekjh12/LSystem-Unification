using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using static OpenGL.Gl;

namespace LSystem
{
    /// <summary>
    /// GPU에 Data를 업로드하기 위한 정적클래스
    /// </summary>
    public class GpuLoader
    {
        /// <summary>
        /// # 실수배열을 구조화하여 하나로 GPU에 올린다. <br/>
        /// * postion3, texcoord2 이면 삼각형을 그리기 위해서 vx, vy, vz, tu, tv의 순으로 총 15개의 실수형을 넘긴다.<br/>
        /// * 또한 3, 2개의 배열을 넘겨 형태를 알려준다.<br/>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="split"></param>
        /// <param name="indices"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static uint LoadData(float[] data, int[] split, uint[] indices, BufferUsage usage = BufferUsage.StaticDraw)
        {
            uint vao = Gl.GenVertexArray();
            uint vbo = Gl.GenBuffer();
            uint ebo = Gl.GenBuffer();

            int vertexFloatCount = 0;
            for (int i = 0; i < split.Length; i++) vertexFloatCount += split[i];

            Gl.BindVertexArray(vao);
            uint verticesCount = (uint)(data.Length / vertexFloatCount);
            int dataSize = sizeof(float) * data.Length;
            int stride = vertexFloatCount * sizeof(float);
            Gl.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            Gl.BufferData(BufferTarget.ArrayBuffer, (uint)dataSize, data, usage);

            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            Gl.BufferData(BufferTarget.ElementArrayBuffer, sizeof(uint) * (uint)indices.Length, indices, usage);

            int baseVertexIndex = 0;
            for (uint i = 0; i < split.Length; i++)
            {
                int num = split[i];
                Gl.EnableVertexAttribArray(i);
                Gl.VertexAttribPointer(i, split[i], VertexAttribType.Float, false, stride, new IntPtr(baseVertexIndex * sizeof(float)));
                baseVertexIndex += num;
            }

            Gl.BindVertexArray(0);
            return vao;
        }

        /// <summary>
        /// * 같은 종류의 데이터를 업로드한다.<br/>
        /// * vao를 바인딩 후에 사용해야 한다.<br/>
        /// </summary>
        /// <param name="attributeNumber">VAO의 슬롯번호</param>
        /// <param name="coordinateSize">데이터의 벡터 성분의 개수</param>
        /// <param name="data">데이터의 배열</param>
        /// <param name="usage">GPU에서의 사용 용도</param>
        /// <returns>vbo를 반환</returns>
        public static uint StoreDataInAttributeList(uint attributeNumber, int coordinateSize, float[] data, BufferUsage usage = BufferUsage.StaticDraw)
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

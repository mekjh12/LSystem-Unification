using OpenGL;
using System;
using System.Windows.Media.Media3D;

namespace LSystem
{
    public class MousePickUp
    {
        public static Vertex3f PickUp(Camera camera, int px, int py, float width, float height)
        {
            float x = (px - ((float)width / 2.0f)) / ((float)width / 2.0f);
            float y = (((float)height / 2.0f) - py) / ((float)height / 2.0f);
            Matrix4x4f projMatrix = camera.ProjectiveMatrix;
            Matrix4x4f viewMatrix = camera.ViewMatrix;

            Vertex3f pos = camera.Position;
            if (camera is OrbitCamera)
            {
                pos = (camera as OrbitCamera).OrbitPositon;
            }
            Vertex4f at = GetWorldLocation(new Vertex4f(x, y, 0.99999f, 1.0f), projMatrix, viewMatrix);
            Vertex3f f = new Vertex3f(at.x - pos.x, at.y - pos.y, at.z - pos.z).Normalized;
            Console.WriteLine(f);
            float t = (f.z == 0) ? 0 : -pos.z / f.z;
            Vertex3f contactPoint = pos + f * t;

            return contactPoint;

            Vertex4f GetWorldLocation(Vertex4f screenCoord, Matrix4x4f proj, Matrix4x4f view)
            {
                Vertex4f projCoord = proj.Inverse * screenCoord;
                Vertex4f viewCoord = new Vertex4f(projCoord.x / projCoord.w, projCoord.y / projCoord.w, projCoord.z / projCoord.w, 1.0f);
                Vertex4f worldCoord = view.Inverse * viewCoord;
                return worldCoord;
            }
        }
    }
}

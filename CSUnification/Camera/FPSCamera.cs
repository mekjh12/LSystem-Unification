using LSystem;
using OpenGL;
using System;

namespace LSystem
{
    public class FpsCamera : Camera
    {       
        public FpsCamera(string name, float x, float y, float z, float yaw, float pitch) : base(name, x, y, z)
        {
            _pitch = pitch;
            _yaw = yaw;
            UpdateCameraVectors();
        }

        public override Matrix4x4f ViewMatrix =>
            Extension.CreateViewMatrix(_position, _cameraRight, _cameraUp, _cameraForward);

        public override void Update(int deltaTime)
        {
            base.Update(deltaTime);
        }

        protected override void UpdateCameraVectors()
        {
            Vertex3f direction = Vertex3f.Zero;
            float yawRad = _yaw.ToRadian();
            float pitchRad = _pitch.ToRadian();
            direction.x = Cos(yawRad) * Cos(pitchRad);
            direction.y = Sin(yawRad) * Cos(pitchRad);
            direction.z = Sin(pitchRad);

            _cameraForward = direction.Normalized;
            _cameraRight = _cameraForward.Cross(Vertex3f.UnitZ).Normalized;
            _cameraUp = _cameraRight.Cross(_cameraForward).Normalized;

            float Cos(float radian)=> (float)Math.Cos(radian);
            float Sin(float radian)=> (float)Math.Sin(radian);
        }

        /*
        public void UpdateDirection(Vertex3f direction)
        {
            if (direction == Vertex3f.UnitZ)
            {
                _cameraForward = direction;
                _cameraRight = Vertex3f.UnitX;
                _cameraUp = Vertex3f.UnitY;
                _pitch = 90;
                _yaw = 0;
            }
            else
            {
                _cameraForward = direction.Normalized;
                _cameraRight = _cameraForward.Cross(Vertex3f.UnitZ).Normalized;
                _cameraUp = _cameraRight.Cross(_cameraForward).Normalized;

                Vertex3f d0 = new Vertex3f(_cameraForward.x, _cameraForward.y, 0);
                float pitch = ((float)Math.Acos(_cameraForward.Dot(d0.Normalized))).ToDegree();
                _pitch = (_cameraForward.z > 0) ? pitch : -pitch;

                float yaw = ((float)Math.Acos(d0.Dot(Vertex3f.UnitX))).ToDegree();
                _yaw = (d0.y > 0) ? yaw : 360 - yaw;
            }
        }
        */


    }
}
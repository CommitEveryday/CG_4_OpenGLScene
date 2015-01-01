using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG_4_OpenGLScene
{
    class Camera
    {
        private Point3D eye;
        public Point3D cntr { get; set; }
        private float dist, angleh, anglev;
        public float distance { get { return dist; } set { dist = value; } }
        public Camera(Point3D eye, Point3D cntr, float distance = 20)
        {
            this.eye = eye;
            this.cntr = cntr;
            this.dist = distance;
            angleh = 90;
            anglev = 90;
            calc();
        }
        public void view(SharpGL.OpenGL gl)
        {
            calc();
            gl.LookAt(
                eye.x, eye.y, eye.z,
                cntr.x, cntr.y, cntr.z,
                0, 1, 0
                );
        }
        private void calc()
        {
            eye.x = cntr.x + dist * (float)Math.Cos(angleh * Math.PI / 180);
            eye.y = cntr.y + dist * (float)Math.Cos(anglev * Math.PI / 180);
            eye.z = cntr.z + dist * (float)Math.Sin(angleh * Math.PI / 180);
        }
        public static Camera operator ++(Camera cam)
        {
            cam.distance--;
            return cam;
        }
        public static Camera operator --(Camera cam)
        {
            cam.distance++;
            return cam;
        }
        private void checkAngleH(ref float angle)
        {
            if (angle > 360) angle -= 360;
            if (angle < 0) angle += 360;
        }
        private void checkAngleV(ref float angle)
        {
            if (angle > 90) angle = 90;
            if (angle < 0) angle = 0;
        }
        public void left(float angle = 1)
        {
            angleh += angle;
            checkAngleH(ref angleh);
        }
        public void right(float angle = 1)
        {
            angleh -= angle;
            checkAngleH(ref angleh);
        }
        public void moveh(float angle)
        {
            angleh += angle;
            checkAngleH(ref angleh);
        }
        public void up(float angle = 1)
        {
            anglev -= angle;
            checkAngleV(ref anglev);
        }
        public void down(float angle = 1)
        {
            anglev += angle;
            checkAngleV(ref anglev);
        }
        public void movev(float angle)
        {
            anglev += angle;
            checkAngleV(ref anglev);
        }
    }
}

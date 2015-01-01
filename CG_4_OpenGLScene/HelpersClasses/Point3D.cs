using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG_4_OpenGLScene
{
    class Point3D
    {
        public float x, y, z;
        public Point3D(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point3D(float[] arr)
        {
            this.x = arr[0];
            this.y = arr[1];
            this.z = arr[2];
        }

        public static Point3D operator -(Point3D a, Point3D b)
        {
            return new Point3D(a.x-b.x, a.y-b.y, a.z-b.z);
        }
    }
}

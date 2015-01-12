using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CG_4_OpenGLScene
{
    class Vector3d
    {
        public float x, y, z;

        public Vector3d(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3d(float[] arr)
        {
            this.x = arr[0];
            this.y = arr[1];
            this.z = arr[2];
        }

        public Vector3d(Point3D endPoint) :this(new Point3D(), endPoint)
        {
        }

        public Vector3d(Point3D startPoint, Point3D endPoint)
            :this(endPoint.x-startPoint.x, endPoint.y-startPoint.y, 
            endPoint.z-startPoint.z)
        {
        }

        public float GetLen()
        {
            return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public Vector3d GetNormalize()
        {
            float len = GetLen();
            return new Vector3d(x / len, y / len, z / len);
        }

        public static Vector3d operator +(Vector3d a, Vector3d b)
        {
            return new Vector3d(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3d operator *(float a, Vector3d b)
        {
            return new Vector3d(a * b.x, a * b.y, a * b.z);
        }

        public static Vector3d operator /(Vector3d v, float a)
        {
            return new Vector3d(v.x/a, v.y/a, v.z/a);
        }

        public static Vector3d Product(Vector3d a, Vector3d b)
        {
            return 
                new Vector3d(
                    a.y * b.z - a.z * b.y,
                    a.z * b.x - a.x * b.z,
                    a.x * b.y - a.y * b.x);
        }

        public float[] ToArray()
        {
            return new float[] { x, y, z };
        }

        public Point3D GetAsPoint3D()
        {
            return new Point3D(x, y, z );
        }
    }
}

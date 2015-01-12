using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CG_4_OpenGLScene
{
    /// <summary>
    /// Для работы с однородными координатами
    /// </summary>
    class HomogeneousCoordinates
    {
        public double x, y, z, h;

        public HomogeneousCoordinates(double x = 0, double y = 0, double z = 0, double h = 1)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.h = h;
        }

        public HomogeneousCoordinates(Point3D point)
        {
            this.x = point.x;
            this.y = point.y;
            this.z = point.z;
            this.h = 1;
        }

        public void Normalize()
        {
            x = x / h;
            y = y / h;
            z = z / h;
        }

        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    case 3:
                        return h;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                    case 3:
                        h = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public static HomogeneousCoordinates operator *(HomogeneousCoordinates vec, Matrix m)
        {
            HomogeneousCoordinates res = new HomogeneousCoordinates();
            for (int i = 0; i < 4; i++)
            {
                res[i] = 0;
                for (int j = 0; j < 4; j++)
                {
                    res[i] += vec[j] * m[j, i];
                }
            }
            return res;
        }

        public PointF ToPointF()
        {
            return new PointF((float)x, (float)y);
        }

        public Point3D ToPoint3D()
        {
            return new Point3D((float)x, (float)y, (float)z);
        }

        public float[] ToArray()
        {
            return new float[] { (float)x, (float)y, (float)z, (float)h };
        }
    }
}

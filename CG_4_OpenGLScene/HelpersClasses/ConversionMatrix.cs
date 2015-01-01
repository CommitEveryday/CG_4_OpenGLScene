using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG_4_OpenGLScene
{
    /// <summary>
    /// Матрицы преобразования в пространстве
    /// Для умножения на вектор-строку справа
    /// </summary>
    static class ConversionMatrix
    {
        /// <summary>
        /// Растяжение/сжатие
        /// </summary>
        /// <param name="kx"></param>
        /// <param name="ky"></param>
        /// <param name="kz"></param>
        /// <returns></returns>
        public static Matrix GetDilatation(double kx, double ky, double kz)
        {
            double[,] res = new double[4, 4];
            SetZero(res);
            res[0, 0] = kx;
            res[1, 1] = ky;
            res[2, 2] = kz;
            res[3, 3] = 1;
            return new Matrix(4, 4, res);
        }

        private static void SetZero(double[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i, j] = 0;
                }
            }
        }

        public static Matrix GetRotationX(double angleX)
        {
            double[,] res = new double[4, 4];
            SetZero(res);
            res[0, 0] = 1;
            res[1, 1] = Math.Cos(angleX);
            res[1, 2] = Math.Sin(angleX);
            res[2, 1] = -Math.Sin(angleX);
            res[2, 2] = Math.Cos(angleX);
            res[3, 3] = 1;
            return new Matrix(4, 4, res);
        }

        public static Matrix GetRotationY(double angleY)
        {
            double[,] res = new double[4, 4];
            SetZero(res);
            res[0, 0] = Math.Cos(angleY);
            res[0, 2] = -Math.Sin(angleY);
            res[1, 1] = 1;
            res[2, 0] = Math.Sin(angleY);
            res[2, 2] = Math.Cos(angleY);
            res[3, 3] = 1;
            return new Matrix(4, 4, res);
        }

        public static Matrix GetRotationZ(double angleZ)
        {
            double[,] res = new double[4, 4];
            SetZero(res);
            res[0, 0] = Math.Cos(angleZ);
            res[0, 1] = Math.Sin(angleZ);
            res[1, 0] = -Math.Sin(angleZ);
            res[1, 1] = Math.Cos(angleZ);
            res[2, 2] = 1;
            res[3, 3] = 1;
            return new Matrix(4, 4, res);
        }

        /// <summary>
        /// Отражение относительно плоскости X=0
        /// </summary>
        /// <param name="angleZ"></param>
        /// <returns></returns>
        public static Matrix GetReflectionX()
        {
            double[,] res = new double[4, 4];
            SetZero(res);
            res[0, 0] = -1;
            res[1, 1] = 1;
            res[2, 2] = 1;
            res[3, 3] = 1;
            return new Matrix(4, 4, res);
        }

        public static Matrix GetReflectionY()
        {
            double[,] res = new double[4, 4];
            SetZero(res);
            res[0, 0] = 1;
            res[1, 1] = -1;
            res[2, 2] = 1;
            res[3, 3] = 1;
            return new Matrix(4, 4, res);
        }

        public static Matrix GetReflectionZ()
        {
            double[,] res = new double[4, 4];
            SetZero(res);
            res[0, 0] = 1;
            res[1, 1] = 1;
            res[2, 2] = -1;
            res[3, 3] = 1;
            return new Matrix(4, 4, res);
        }

        /// <summary>
        /// Параллельный перенос
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dz"></param>
        /// <returns></returns>
        public static Matrix GetTranslation(double dx, double dy, double dz)
        {
            double[,] res = new double[4, 4];
            SetZero(res);
            res[0, 0] = 1;
            res[1, 1] = 1;
            res[2, 2] = 1;
            res[3, 0] = dx;
            res[3, 1] = dy;
            res[3, 2] = dz;
            res[3, 3] = 1;
            return new Matrix(4, 4, res);
        }

    }
}

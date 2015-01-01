using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG_4_OpenGLScene
{
    class Matrix
    {
        double[,] values;
        int rows, cols;

        public Matrix(int n, int m, double[] valuesAsRow)
        {
            rows = n;
            cols = m;
            values = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    values[i, j] = valuesAsRow[i * cols + j];
        }

        public Matrix(int n, int m, double[,] valuesForCopy)
        {
            rows = n;
            cols = m;
            values = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    values[i, j] = valuesForCopy[i, j];
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            int n = a.rows;
            int l = a.cols;
            int m = b.cols;
            double[,] res = new double[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < l; k++)
                        res[i, j] += a.values[i, k] * b.values[k, j];
                }
            return new Matrix(n, m, res);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                IList<string> row = new List<string>();
                for (int j = 0; j < cols; j++)
                    row.Add(values[i, j].ToString());
                sb.AppendLine(String.Join("; ", row));
            }
            return sb.ToString();
        }

        public double this[int i, int j]
        {
            get
            {
                return values[i, j];
            }
        }
    }
}

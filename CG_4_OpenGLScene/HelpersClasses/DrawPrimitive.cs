using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene
{
    static class DrawPrimitive
    {
        /// <summary>
        /// Предполагается, что обход точек выполняется против часовой стрелки.
        /// </summary>
        /// <param name="gl"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="showNormal"></param>
        public static void Quard(OpenGL gl, Point3D a, Point3D b, Point3D c, Point3D d, bool showNormal = false)
        {
            gl.PushAttrib(AttributeMask.All);
            Vector3d d1, d2, norm;
            d1 = new Vector3d(a, b);
            d2 = new Vector3d(b, c);
            norm = Vector3d.Product(d1, d2).GetNormalize();
            gl.Begin(BeginMode.Quads);
            {
                gl.Normal(norm.ToArray());
                gl.Vertex(a.ToArray());
                gl.Vertex(b.ToArray());
                gl.Vertex(c.ToArray());
                gl.Vertex(d.ToArray());
            }
            gl.End();
            if (showNormal)
            {
                gl.LineWidth(3);
                gl.Color(1, 1, 1);
                gl.Begin(BeginMode.Lines);
                {
                    gl.Vertex(a.ToArray());
                    gl.Vertex((new Vector3d(a) + norm).ToArray());
                    gl.Vertex(b.ToArray());
                    gl.Vertex((new Vector3d(b) + norm).ToArray());
                    gl.Vertex(c.ToArray());
                    gl.Vertex((new Vector3d(c) + norm).ToArray());
                    gl.Vertex(d.ToArray());
                    gl.Vertex((new Vector3d(d) + norm).ToArray());
                }
                gl.End();
            }
            gl.PopAttrib();
        }

        public static void Triangle(OpenGL gl, Point3D a, Point3D b, Point3D c, bool showNormal = false)
        {
            gl.PushAttrib(AttributeMask.All);
            Vector3d d1, d2, norm;
            d1 = new Vector3d(a, b);
            d2 = new Vector3d(b, c);
            norm = Vector3d.Product(d1, d2).GetNormalize();
            gl.Begin(BeginMode.Triangles);
            {
                gl.Normal(norm.ToArray());
                gl.Vertex(a.ToArray());
                gl.Vertex(b.ToArray());
                gl.Vertex(c.ToArray());
            }
            gl.End();
            if (showNormal)
            {
                gl.LineWidth(3);
                gl.Color(1, 1, 1);
                gl.Begin(BeginMode.Lines);
                {
                    gl.Vertex(a.ToArray());
                    gl.Vertex((new Vector3d(a) + norm).ToArray());
                    gl.Vertex(b.ToArray());
                    gl.Vertex((new Vector3d(b) + norm).ToArray());
                    gl.Vertex(c.ToArray());
                    gl.Vertex((new Vector3d(c) + norm).ToArray());
                }
                gl.End();
            }
            gl.PopAttrib();
        }
    }
}

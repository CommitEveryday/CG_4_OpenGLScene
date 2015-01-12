using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;

namespace CG_4_OpenGLScene
{
    class Triangle : AbstractFigure
    {
        private float scaleKoef;
        public Triangle(Point3D position, float scaleKoef = 1)
            : base(position)
        {
            this.scaleKoef = scaleKoef;
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            gl.Translate(position.x, position.y + 1f, position.z);
            gl.Scale(scaleKoef, scaleKoef, scaleKoef);
            //  DrawPrimitive a coloured pyramid.
            gl.Begin(OpenGL.GL_TRIANGLES);
            {
                Vector3d d1, d2, norm;
                d1 = new Vector3d(new Point3D(0.0f, 1.0f, 0.0f), new Point3D(-1.0f, -1.0f, 1.0f));
                d2 = new Vector3d(new Point3D(-1.0f, -1.0f, 1.0f), new Point3D(1.0f, -1.0f, 1.0f));
                norm = Vector3d.Product(d1, d2).GetNormalize();
                gl.Normal(norm.ToArray());

                gl.Color(1.0f, 0.0f, 0.0f, 100);
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 1.0f, 0.0f, 100);
                gl.Vertex(-1.0f, -1.0f, 1.0f);
                gl.Color(0.0f, 0.0f, 1.0f, 100);
                gl.Vertex(1.0f, -1.0f, 1.0f);

                d1 = new Vector3d(new Point3D(0.0f, 1.0f, 0.0f), new Point3D(1.0f, -1.0f, 1.0f));
                d2 = new Vector3d(new Point3D(1.0f, -1.0f, 1.0f), new Point3D(1.0f, -1.0f, -1.0f));
                norm = Vector3d.Product(d1, d2).GetNormalize();
                gl.Normal(norm.ToArray());
                gl.Color(1.0f, 0.0f, 0.0f, 100);
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 0.0f, 1.0f, 100);
                gl.Vertex(1.0f, -1.0f, 1.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(1.0f, -1.0f, -1.0f);

                d1 = new Vector3d(new Point3D(0.0f, 1.0f, 0.0f), new Point3D(1.0f, -1.0f, -1.0f));
                d2 = new Vector3d(new Point3D(1.0f, -1.0f, -1.0f), new Point3D(-1.0f, -1.0f, -1.0f));
                norm = Vector3d.Product(d1, d2).GetNormalize();
                gl.Normal(norm.ToArray());
                gl.Color(1.0f, 0.0f, 0.0f);
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(1.0f, -1.0f, -1.0f);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(-1.0f, -1.0f, -1.0f);

                d1 = new Vector3d(new Point3D(0.0f, 1.0f, 0.0f), new Point3D(-1.0f, -1.0f, -1.0f));
                d2 = new Vector3d(new Point3D(-1.0f, -1.0f, -1.0f), new Point3D(-1.0f, -1.0f, 1.0f));
                norm = Vector3d.Product(d1, d2).GetNormalize();
                gl.Normal(norm.ToArray());
                gl.Color(1.0f, 0.0f, 0.0f);
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(-1.0f, -1.0f, -1.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(-1.0f, -1.0f, 1.0f);
            }
            gl.End();
            gl.PopMatrix();
        }
    }
}

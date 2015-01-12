using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene
{
    class Pyramid : AbstractFigure
    {
        private int doubledFaceNumber;
        private float size;

        public Pyramid(Point3D position, int doubledFaceNumber = 4, float size = 1)
            : base(position)
        {
            this.doubledFaceNumber = doubledFaceNumber;
            this.size = size;
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            gl.Translate(position.x, position.y, position.z);
            gl.Rotate(-90, 1, 0, 0);
            int iPivot = 1;
            float x, y;
            //gl.Begin(BeginMode.TriangleFan);
            {
                //gl.Vertex(0f, 0f, size);
                Point3D top = new Point3D(0f, 0f, size);
                Point3D prevPoint = null;
                for (float angle = 0; angle <= (2f * Math.PI) + (((float)Math.PI / doubledFaceNumber) / 2); angle += ((float)Math.PI / doubledFaceNumber))
                {
                    y = size * (float)Math.Sin(angle);
                    x = size * (float)Math.Cos(angle);
                    if ((iPivot++ % 2) == 0)
                        gl.Color(0f, 1f, 0f);
                    else
                        gl.Color(1f, 0f, 0f);
                    //gl.Vertex(x, y);
                    if (prevPoint != null)
                    {
                        DrawPrimitive.Triangle(gl, top, prevPoint, new Point3D(x,y), false);
                    }
                    prevPoint = new Point3D(x, y);
                }
            }
            //gl.End();
            //основание
            gl.Begin(BeginMode.TriangleFan);
            {
                gl.Normal(0, 0, -1f);
                gl.Vertex(0f, 0f, 0f);
                for (float angle = 0; angle <= (2f * Math.PI) + (((float)Math.PI / doubledFaceNumber) / 2); angle += ((float)Math.PI / doubledFaceNumber))
                {
                    x = size * (float)Math.Sin(angle);
                    y = size * (float)Math.Cos(angle);
                    if ((iPivot++ % 2) == 0)
                        gl.Color(0f, 1f, 0f);
                    else
                        gl.Color(1f, 0f, 0f);
                    gl.Vertex(x, y);
                }
            }
            gl.End();

            gl.PopMatrix();
        }
    }
}

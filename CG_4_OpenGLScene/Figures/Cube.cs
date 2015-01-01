using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.Enumerations;
using SharpGL;

namespace CG_4_OpenGLScene
{
    class Cube : AbstractColorFigure
    {
        private float size;

        public Cube(ColorF color, Point3D position, float size = 1)
            : base(color, position)
        {
            this.size = size;
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            float halfSize = size / 2;
            gl.Translate(position.x, position.y + halfSize, position.z);
            gl.Color(color.GetInArrWithAlpha());
            gl.Begin(BeginMode.QuadStrip);
            {
                gl.Normal(0, 1, 0);
                gl.Vertex(halfSize, halfSize, -halfSize);
                gl.Vertex(-halfSize, halfSize, -halfSize);
                gl.Vertex(halfSize, halfSize, halfSize);
                gl.Vertex(-halfSize, halfSize, halfSize);

                gl.Normal(0, 0, -1);
                gl.Vertex(halfSize, -halfSize, halfSize);
                gl.Vertex(-halfSize, -halfSize, halfSize);

                gl.Normal(0, -1, 0);
                gl.Vertex(halfSize, -halfSize, -halfSize);
                gl.Vertex(-halfSize, -halfSize, -halfSize);

                gl.Normal(0, 0, 1);
                gl.Vertex(halfSize, halfSize, -halfSize);
                gl.Vertex(-halfSize, halfSize, -halfSize);
            }
            gl.End();
            gl.Begin(BeginMode.Quads);
            {
                gl.Normal(-1, 0, 0);
                gl.Vertex(-halfSize, halfSize, halfSize);
                gl.Vertex(-halfSize, halfSize, -halfSize);
                gl.Vertex(-halfSize, -halfSize, -halfSize);
                gl.Vertex(-halfSize, -halfSize, halfSize);
            }
            gl.End();
            gl.Begin(BeginMode.Quads);
            {
                gl.Normal(1, 0, 0);
                gl.Vertex(halfSize, halfSize, -halfSize);
                gl.Vertex(halfSize, halfSize, halfSize);
                gl.Vertex(halfSize, -halfSize, halfSize);
                gl.Vertex(halfSize, -halfSize, -halfSize);
            }
            gl.End();
            gl.PopMatrix();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene
{
    class Grid : AbstractColorFigure
    {
        private float step;
        private float max;

        public Grid(ColorF color, Point3D position, float step = 1, float max = 5)
            : base(color, position)
        {
            this.step = step;
            this.max = max;
        }

        public override void Draw(OpenGL gl)
        {
            gl.PushAttrib(AttributeMask.Line);
            gl.PushMatrix();
            //gl.Enable(OpenGL.GL_LINE_STIPPLE);
            //gl.LineStipple(1, 0x0F0F);
            gl.Color(color.GetInArrWithAlpha());
            gl.Begin(BeginMode.Lines);
            {
                for (float y = -max; y <= max; y += step)
                {
                    for (float z = -max; z <= max; z += step)
                    {
                        gl.Vertex(-max, y, z);
                        gl.Vertex(max, y, z);
                    }
                    for (float x = -max; x <= max; x += step)
                    {
                        gl.Vertex(x, y, -max);
                        gl.Vertex(x, y, max);
                    }
                }
                for (float z = -max; z <= max; z += step)
                {
                    for (float x = -max; x <= max; x += step)
                    {
                        gl.Vertex(x, -max, z);
                        gl.Vertex(x, max, z);
                    }
                }
            }
            gl.End();
            //gl.Disable(OpenGL.GL_LINE_STIPPLE);
            gl.PopMatrix();
            gl.PopAttrib();
        }
    }
}

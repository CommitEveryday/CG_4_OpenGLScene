using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene
{
    class Axis : AbstractFigure
    {
        private float lens;

        public Axis(Point3D position, float lens)
        :base(position)
        {
            this.lens = lens;
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            float[] curSize = new float[1];
            gl.GetFloat(GetTarget.PointSize, curSize);
            gl.PointSize(5);
            gl.PushMatrix();
            gl.Translate(position.x, position.y, position.z);
            gl.Begin(BeginMode.Lines);
            {
                gl.Color(1.0f, 0.0f, 0.0f, 1f);
                gl.Vertex(0.0f, 0.0f, 0.0f);
                gl.Vertex(lens, 0.0f, 0.0f);
                gl.Color(0.0f, 1.0f, 0.0f, 1f);
                gl.Vertex(0.0f, 0.0f, 0.0f);
                gl.Vertex(0.0f, lens, 0.0f);
                gl.Color(0.0f, 0.0f, 1.0f, 1f);
                gl.Vertex(0.0f, 0.0f, 0.0f);
                gl.Vertex(0.0f, 0.0f, lens);
            }
            gl.End();
            gl.PointSize(curSize[0]);
            gl.PopMatrix();
        }
    }
}

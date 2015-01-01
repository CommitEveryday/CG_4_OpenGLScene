using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.Enumerations;
using System.Drawing;

namespace CG_4_OpenGLScene
{
    class Ground : AbstractColorFigure
    {
        public float lenByX { get; protected set; }
        public float lenByZ { get; protected set; }

        public Ground(ColorF color, Point3D center, float lenByX, float lenByZ)
            : base(color, center)
        {
            this.lenByX = lenByX;
            this.lenByZ = lenByZ;
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            gl.Begin(BeginMode.Quads);
            {
                gl.Color(color.GetInArr());
                gl.Normal(0, 1, 0);
                gl.Vertex(position.x - lenByX / 2, position.y, position.z + lenByZ / 2);
                gl.Vertex(position.x + lenByX / 2, position.y, position.z + lenByZ / 2);
                gl.Vertex(position.x + lenByX / 2, position.y, position.z - lenByZ / 2);
                gl.Vertex(position.x - lenByX / 2, position.y, position.z - lenByZ / 2);
            }
            gl.End();
            gl.PopMatrix();
        }
    }
}

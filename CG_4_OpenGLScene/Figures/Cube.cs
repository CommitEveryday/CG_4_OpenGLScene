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
            Point3D[] vertex = new Point3D[]
            {
                new Point3D(halfSize, halfSize, halfSize),
                new Point3D(-halfSize, halfSize, halfSize),
                new Point3D(-halfSize, -halfSize, halfSize),
                new Point3D(halfSize, -halfSize, halfSize),
                new Point3D(halfSize, halfSize, -halfSize),
                new Point3D(-halfSize, halfSize, -halfSize),
                new Point3D(-halfSize, -halfSize, -halfSize),
                new Point3D(halfSize, -halfSize, -halfSize)
            };
            DrawPrimitive.Quard(gl, vertex[0], vertex[1], vertex[2], vertex[3], false);
            DrawPrimitive.Quard(gl, vertex[0], vertex[4], vertex[5], vertex[1], false);
            DrawPrimitive.Quard(gl, vertex[7], vertex[6], vertex[5], vertex[4], false);
            DrawPrimitive.Quard(gl, vertex[3], vertex[2], vertex[6], vertex[7], false);
            DrawPrimitive.Quard(gl, vertex[1], vertex[5], vertex[6], vertex[2], false);
            DrawPrimitive.Quard(gl, vertex[0], vertex[3], vertex[7], vertex[4], false);
            gl.PopMatrix();
        }
    }
}

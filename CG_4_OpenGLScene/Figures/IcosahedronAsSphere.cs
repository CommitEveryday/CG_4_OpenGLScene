using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene
{
    /// <summary>
    /// Икосаэдр, нормали которого установлены не от полигонов, а то центра, как будто
    /// это сфера
    /// </summary>
    class IcosahedronAsSphere : Icosahedron
    {
        public IcosahedronAsSphere(ColorF color, Point3D position, float scaleKoef = 1)
            : base(color, position, scaleKoef)
        {
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            gl.Translate(position.x, position.y + Z * scaleKoef, position.z);
            gl.Scale(scaleKoef, scaleKoef, scaleKoef);
            int i;
            gl.Color(color.GetInArrWithAlpha());

            //float[] specular1 = { 1, 1, 1, 1 };
            //gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, specular1);
            //gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, 128);

            gl.Begin(BeginMode.Triangles);
            for (i = 0; i < 20; i++)
            {
                gl.Normal(vdata[tindices[i][0]]);
                gl.Vertex(vdata[tindices[i][0]]);
                gl.Normal(vdata[tindices[i][1]]);
                gl.Vertex(vdata[tindices[i][1]]);
                gl.Normal(vdata[tindices[i][2]]);
                gl.Vertex(vdata[tindices[i][2]]);
            }
            gl.End();
            gl.PopMatrix();
        }
    }
}

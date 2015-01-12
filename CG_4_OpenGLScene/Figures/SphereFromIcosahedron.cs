using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene
{
    /// <summary>
    /// Сфера как результат разбиения икосаэдра и усатновка нормалей
    /// </summary>
    class SphereFromIcosahedron : Icosahedron
    {
        /// <summary>
        /// Число разбиений каждого полигона исходного икосаэдра
        /// на четыре части
        /// </summary>
        byte divineCount;

        public SphereFromIcosahedron(ColorF color, Point3D position, 
            byte divineCount = 0, float scaleKoef = 1)
            : base(color, position, scaleKoef)
        {
            this.divineCount = divineCount;
        }

        void drawTriangle(OpenGL gl, Vector3d v1, Vector3d v2, Vector3d v3)
        {
            gl.Begin(BeginMode.Triangles);
            gl.Normal(v1.ToArray());
            gl.Vertex(v1.ToArray());
            gl.Normal(v2.ToArray());
            gl.Vertex(v2.ToArray());
            gl.Normal(v3.ToArray());
            gl.Vertex(v3.ToArray());
            gl.End();
        }

        void subdivine(OpenGL gl, Vector3d v1, Vector3d v2, Vector3d v3, int depth)
        {
        Vector3d v12, v23, v31;
        if(depth<=0)
        {
            drawTriangle(gl,v1,v2,v3);
            return;
        }
        v12 = ((v1 + v2) / 2.0f).GetNormalize();
        v23 = ((v2 + v3) / 2.0f).GetNormalize();
        v31 = ((v3 + v1) / 2.0f).GetNormalize();

        subdivine(gl,v1, v12, v31, depth - 1);
        subdivine(gl,v2, v23, v12, depth - 1);
        subdivine(gl,v3, v31, v23, depth - 1);
        subdivine(gl,v12, v23, v31, depth - 1);
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            gl.PushAttrib(AttributeMask.Lighting);
            gl.Translate(position.x, position.y + 1 * scaleKoef, position.z);
            gl.Scale(scaleKoef, scaleKoef, scaleKoef);

            gl.Color(color.GetInArrWithAlpha());

            float[] specular1 = { 1, 1, 1, 1 };
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, specular1);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SHININESS, 60);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, 128);

            for (int i = 0; i < 20; i++)
            {
                subdivine(gl,
                    new Vector3d(vdata[tindices[i][0]]), 
                    new Vector3d(vdata[tindices[i][1]]),
                    new Vector3d(vdata[tindices[i][2]]),
                    divineCount);
            }
            gl.PopAttrib();
            gl.PopMatrix();
        }
    }
}

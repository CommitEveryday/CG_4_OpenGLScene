using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.Enumerations;
using SharpGL;

namespace CG_4_OpenGLScene
{
    /// <summary>
    /// Икосаэдр
    /// </summary>
    class Icosahedron : AbstractColorFigure
    {
        //расстояние от точки начала координат до любой из вершин равно 1.0
        private const float X = .525731112119133606f;
        private const float Z = .850650808352039932f;
        float[][] vdata = new float[12][]{
              new float[3]{-X,0.0f,Z},new float[3]{X,0.0f,Z},new float[3]{-X,0.0f,-Z},new float[3]{X,0.0f,-Z},
              new float[3]{0.0f,Z,X},new float[3]{0.0f,Z,-X},new float[3]{0.0f,-Z,X},new float[3]{0.0f,-Z,-X},
              new float[3]{Z,X,0.0f},new float[3]{-Z,X,0.0f},new float[3]{Z,-X,0.0f},new float[3]{-Z,-X,0.0f}
        };

        int[][] tindices = new int[20][] {
              new int[3]{1,4,0},new int[3]{4,9,0},new int[3]{4,5,9},new int[3]{8,5,4},new int[3]{1,8,4},
              new int[3]{1,10,8},new int[3]{10,3,8},new int[3]{8,3,5},new int[3]{3,2,5},new int[3]{3,7,2},
              new int[3]{3,10,7},new int[3]{10,6,7},new int[3]{6,11,7},new int[3]{6,0,11},new int[3]{6,1,0},
              new int[3]{10,1,6},new int[3]{11,0,9},new int[3]{2,11,9},new int[3]{5,2,9},new int[3]{11,2,7}
        };

        private float scaleKoef;


        public Icosahedron(ColorF color, Point3D position, float scaleKoef = 1)
            : base(color, position)
        {
            this.scaleKoef = scaleKoef;
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            gl.Scale(scaleKoef, scaleKoef, scaleKoef);
            gl.Translate(position.x, position.y+Z, position.z);
            int i;
            gl.Color(color.GetInArrWithAlpha());

            float[] specular1 = { 1, 1, 1, 1 };
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, specular1);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, 128);

            gl.Begin(BeginMode.Triangles);
            for (i = 0; i < 20; i++)
            {
                //Здесь помещается информация о цвете
                //расчёт нормалей как перпендикуляров к граням
                //TODO проверить правильность
                Vector3d d1, d2, norm;
                //d1 = new Vector3d(new Point3D(tindices[i][1]), new Point3D(tindices[i][0]));
                //d2 = new Vector3d(new Point3D(tindices[i][2]), new Point3D(tindices[i][1]));
                d1 = new Vector3d(new Point3D(tindices[i][1]), new Point3D(tindices[i][2]));
                d2 = new Vector3d(new Point3D(tindices[i][1]), new Point3D(tindices[i][0]));
                norm = Vector3d.Product(d1, d2).GetNormalize();
                gl.Normal(norm.ToArray());
 
                gl.Vertex(vdata[tindices[i][0]]);
                gl.Vertex(vdata[tindices[i][1]]);
                gl.Vertex(vdata[tindices[i][2]]);
            }
            gl.End();
            gl.PopMatrix();
        }
    }
}

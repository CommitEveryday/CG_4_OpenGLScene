using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene.Figures
{
    class Parallelepiped : AbstractColorFigure
    {
        protected float sizeX, sizeY, sizeZ;
        protected Texture texture;

        protected float[] vertexs, normals, texCoord;

        public Parallelepiped(ColorF color, Point3D position, float sizeX = 1, float sizeY = 1, float sizeZ = 1, Texture texture = null)
            : base(color, position)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.sizeZ = sizeZ;
            this.texture = texture;
            float halfSizeX = sizeX/2;
            float halfSizeY = sizeY/2;
            float halfSizeZ = sizeZ/2;
            Point3D[] vertexsUniq = new Point3D[] 
            {
               new Point3D( halfSizeX, halfSizeY, halfSizeZ), 
               new Point3D(-halfSizeX, halfSizeY, halfSizeZ), 
               new Point3D(-halfSizeX, -halfSizeY, halfSizeZ),
               new Point3D( halfSizeX, -halfSizeY, halfSizeZ),
               new Point3D( halfSizeX, halfSizeY, -halfSizeZ),
               new Point3D(-halfSizeX, halfSizeY, -halfSizeZ),
               new Point3D(-halfSizeX, -halfSizeY, -halfSizeZ),
               new Point3D(halfSizeX, -halfSizeY, -halfSizeZ)
            };
            uint[][] faces = new uint[][]
            {
                //new uint[] {0, 1, 2, 3},
                //new uint[] {0, 4, 5, 1},
                //new uint[] {7, 6, 5, 4},
                //new uint[] {3, 2, 6, 7},
                //new uint[] {1, 5, 6, 2},
                //new uint[] {0, 3, 7, 4}
                new uint[] {2,3,0,1},   //z+
                new uint[] {1,0,4,5},   //y+
                new uint[] {7, 6, 5, 4},//z-
                new uint[] {3, 2, 6, 7},//y-
                new uint[] {6,2,1,5},   //x-
                new uint[] {3, 7, 4,0}  //x+
            };
            
            Vector3d[] normalsVec = new Vector3d[24];
            Vector3d[] vertexsVec = new Vector3d[24];

            int globalInd = 0;
            for (int faceInd = 0; faceInd < faces.GetLength(0); faceInd++)
            {
                Point3D a = vertexsUniq[faces[faceInd][0]];
                Point3D b = vertexsUniq[faces[faceInd][1]];
                Point3D c = vertexsUniq[faces[faceInd][2]];
                Point3D d = vertexsUniq[faces[faceInd][3]];
                Vector3d d1, d2, norm;
                d1 = new Vector3d(a, b);
                d2 = new Vector3d(b, c);
                norm = Vector3d.Product(d1, d2).GetNormalize();
                vertexsVec[globalInd] = new Vector3d(a);
                normalsVec[globalInd++] = norm;
                vertexsVec[globalInd] = new Vector3d(b);
                normalsVec[globalInd++] = norm;
                vertexsVec[globalInd] = new Vector3d(c);
                normalsVec[globalInd++] = norm;
                vertexsVec[globalInd] = new Vector3d(d);
                normalsVec[globalInd++] = norm;
            }

            normals = VectorArrToFloatArr(normalsVec);
            vertexs = VectorArrToFloatArr(vertexsVec);
            texCoord = new float[24 * 2];
            for (int i = 0; i < 6; i++)
            {
                //текстура грузится в память не с левого нижнего угла, а видимо
                //с левого верхнего. поэтому сжинем координаты
                //всё равно не совсем правильно, повёрнуто на 180, но сойдёт

                texCoord[i * 8 + 0] = 1;
                texCoord[i * 8 + 1] = 1;

                texCoord[i * 8 + 2] = 0;
                texCoord[i * 8 + 3] = 1;

                texCoord[i * 8 + 4] = 0;
                texCoord[i * 8 + 5] = 0;

                texCoord[i * 8 + 6] = 1;
                texCoord[i * 8 + 7] = 0;
            }
        }

        private float[] VectorArrToFloatArr(Vector3d[] vecArr)
        {
            float[] res = new float[vecArr.Length * 3];
            for (int i = 0; i < vecArr.Length; i++)
            {
                res[i * 3 + 0] = vecArr[i].x;
                res[i * 3 + 1] = vecArr[i].y;
                res[i * 3 + 2] = vecArr[i].z;
            }
            return res;
        }


        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            gl.PushAttrib(AttributeMask.All);
            gl.PushClientAttrib(OpenGL.GL_CLIENT_ALL_ATTRIB_BITS);

            gl.VertexPointer(3, 0, vertexs);
            gl.NormalPointer(OpenGL.GL_FLOAT, 0, normals);
            gl.TexCoordPointer(2, OpenGL.GL_FLOAT, 0, texCoord);

            gl.EnableClientState(OpenGL.GL_VERTEX_ARRAY);
            //gl.EnableClientState(OpenGL.GL_COLOR_ARRAY);
            gl.EnableClientState(OpenGL.GL_NORMAL_ARRAY);
            gl.EnableClientState(OpenGL.GL_TEXTURE_COORD_ARRAY);

            gl.Translate(position.x, position.y + sizeY / 2, position.z);

            gl.Color(color.GetInArrWithAlpha());

            if (texture != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                texture.Bind(gl);
            }
            else
                gl.Disable(OpenGL.GL_TEXTURE_2D);

            gl.DrawArrays(OpenGL.GL_QUADS, 0, 24);

            gl.PopClientAttrib();
            gl.PopAttrib();
            gl.PopMatrix();
        }
    }
}

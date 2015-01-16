using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.SceneGraph.Assets;
using SharpGL.Enumerations;
using SharpGL;

namespace CG_4_OpenGLScene.Figures
{
    struct TwoVal
    {
        public float x, y;
        public TwoVal(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class ParallelepipedWithDiffTextures : Parallelepiped
    {
        protected Texture textureXminus, textureYplus, textureYminus, textureZplus, textureZminus;

        public ParallelepipedWithDiffTextures(ColorF color, Point3D position, float sizeX = 1, float sizeY = 1, float sizeZ = 1,
            Texture textureXplus = null, Texture textureXminus = null,
            Texture textureYplus = null, Texture textureYminus = null,
            Texture textureZplus = null, Texture textureZminus = null,
            //порядок значений см. в инексном массиве
            TwoVal[] repeartTextCount = null
            )
            : base(color, position, sizeX, sizeY, sizeZ, textureXplus)
        {
            this.textureXminus = textureXminus;
            this.textureYplus = textureYplus;
            this.textureYminus = textureYminus;
            this.textureZplus = textureZplus;
            this.textureZminus = textureZminus;

            if (repeartTextCount != null)
            {
                for (int i = 0; i < 6; i++)
                {
                    texCoord[i * 8 + 0] = repeartTextCount[i].x;
                    texCoord[i * 8 + 1] = repeartTextCount[i].y;

                    texCoord[i * 8 + 2] = 0;
                    texCoord[i * 8 + 3] = repeartTextCount[i].y;

                    texCoord[i * 8 + 4] = 0;
                    texCoord[i * 8 + 5] = 0;

                    texCoord[i * 8 + 6] = repeartTextCount[i].x;
                    texCoord[i * 8 + 7] = 0;
                }
            }
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
            gl.EnableClientState(OpenGL.GL_NORMAL_ARRAY);
            gl.EnableClientState(OpenGL.GL_TEXTURE_COORD_ARRAY);

            gl.Translate(position.x, position.y + sizeY / 2, position.z);

            gl.Color(color.GetInArrWithAlpha());

            DrawArrayWithTexture(gl, OpenGL.GL_QUADS, 0, 4, textureZplus);//z+
            DrawArrayWithTexture(gl, OpenGL.GL_QUADS, 4, 4, textureYplus);//y+
            DrawArrayWithTexture(gl, OpenGL.GL_QUADS, 8, 4, textureZminus);//z-
            DrawArrayWithTexture(gl, OpenGL.GL_QUADS, 12, 4, textureYminus);//y-
            DrawArrayWithTexture(gl, OpenGL.GL_QUADS, 16, 4, textureXminus);//x-
            DrawArrayWithTexture(gl, OpenGL.GL_QUADS, 20, 4, texture);//x+

            gl.PopClientAttrib();
            gl.PopAttrib();
            gl.PopMatrix();
        }

        private void DrawArrayWithTexture(OpenGL gl, uint mode, int first, int count, Texture texture)
        {
            if (texture != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                texture.Push(gl);
            }
            else
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            gl.DrawArrays(mode, first, count);
            if (texture != null)
            {
                texture.Pop(gl);
            }
        }
    }
}

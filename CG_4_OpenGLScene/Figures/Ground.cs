using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.Enumerations;
using System.Drawing;
using SharpGL.SceneGraph.Assets;
using SharpGL;

namespace CG_4_OpenGLScene
{
    class Ground : AbstractColorFigure
    {
        public float lenByX { get; protected set; }
        public float lenByZ { get; protected set; }
        Texture texture;


        public Ground(ColorF color, Point3D center, float lenByX, float lenByZ, Texture texture = null)
            : base(color, center)
        {
            this.lenByX = lenByX;
            this.lenByZ = lenByZ;
            this.texture = texture;
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushAttrib(AttributeMask.All);
            gl.PushMatrix();
            if (texture != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                texture.Push(gl);
            }
            gl.Begin(BeginMode.Quads);
            {
                gl.Color(color.GetInArrWithAlpha());
                gl.Normal(0, 1, 0);
                gl.TexCoord(0, 0);
                gl.Vertex(position.x - lenByX / 2, position.y, position.z + lenByZ / 2);
                gl.TexCoord(lenByX, 0);
                gl.Vertex(position.x + lenByX / 2, position.y, position.z + lenByZ / 2);
                gl.TexCoord(lenByX, lenByZ);
                gl.Vertex(position.x + lenByX / 2, position.y, position.z - lenByZ / 2);
                gl.TexCoord(0, lenByZ);
                gl.Vertex(position.x - lenByX / 2, position.y, position.z - lenByZ / 2);
            }
            gl.End();
            if (texture != null)
            {
                texture.Pop(gl);
            }
            gl.PopMatrix();
            gl.PopAttrib();
        }
    }
}

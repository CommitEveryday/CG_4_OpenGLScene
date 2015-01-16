using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.SceneGraph.Assets;
using SharpGL;
using SharpGL.Enumerations;
using System.Drawing;

namespace CG_4_OpenGLScene.Figures
{
    class Board : AbstractColorFigure
    {
        ParallelepipedWithDiffTextures body;
        private float size;
        private Texture texture;
        private float height;
        private Texture textureBoard;

        public Board(OpenGL gl,ColorF color, Point3D position, float size = 1, float height = 0.1f, Texture texture = null,
            Texture textureBoard = null)
            : base(color, position)
        {
            this.size = size;
            this.height = height;
            this.texture = texture;
            this.textureBoard = textureBoard;
            body = new ParallelepipedWithDiffTextures(color, new Point3D(0, 0, 0), size, height, size, texture,
                texture, textureBoard, texture, texture, texture);
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            gl.PushAttrib(AttributeMask.All);
            gl.PushClientAttrib(OpenGL.GL_CLIENT_ALL_ATTRIB_BITS);

            gl.Translate(position.x, position.y, position.z);
            body.Draw(gl);

            gl.PopClientAttrib();
            gl.PopAttrib();
            gl.PopMatrix();
        }
    }
}

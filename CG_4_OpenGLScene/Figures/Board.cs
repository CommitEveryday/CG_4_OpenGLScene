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
        Parallelepiped body;
        private float size;
        private Texture texture;
        private float height;
        private Texture textureBoard;

        List<FigureFromOBJ> chessFigure;


        public Board(OpenGL gl,ColorF color, Point3D position, float size = 1, float height = 0.1f, Texture texture = null,
            Texture textureBoard = null)
            : base(color, position)
        {
            this.size = size;
            this.height = height;
            this.texture = texture;
            this.textureBoard = textureBoard;
            body = new Parallelepiped(color, new Point3D(0, 0, 0), size, height, size, texture);

            this.chessFigure = new List<FigureFromOBJ>();

            float quardSize = size/8;
            float halfQuard = quardSize/2;

            Texture text_white = new Texture();
            text_white.Create(gl, @"Texture\wood_white.jpg");
            Texture text_black = new Texture();
            text_black.Create(gl, @"Texture\wood_black.jpg");

            //FigureFromOBJ pawn = new FigureFromOBJ(new ColorF(Color.White), new Point3D(quardSize * 7 + halfQuard, 0, quardSize * 7 + halfQuard),
            //        @"ObjModel\p.obj", text_white);

            //chessFigure.Add(pawn);
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            gl.PushAttrib(AttributeMask.All);
            gl.PushClientAttrib(OpenGL.GL_CLIENT_ALL_ATTRIB_BITS);

            gl.Translate(position.x, position.y, position.z);
            body.Draw(gl);

            if (textureBoard != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                textureBoard.Bind(gl);

                float halfSize = size / 2;

                Point3D a = new Point3D(halfSize, height + 0.01f * height, halfSize);
                Point3D b = new Point3D(halfSize, height + 0.01f * height, -halfSize);
                Point3D c = new Point3D(-halfSize, height + 0.01f * height, -halfSize);
                Point3D d = new Point3D(-halfSize, height + 0.01f * height, halfSize);
                Vector3d d1, d2, norm;
                d1 = new Vector3d(a, b);
                d2 = new Vector3d(b, c);
                norm = Vector3d.Product(d1, d2).GetNormalize();
                gl.Color(1f, 1f, 1f, 1f);
                gl.Begin(BeginMode.Quads);
                {
                    gl.Normal(norm.ToArray());
                    gl.TexCoord(1f, 0f);
                    gl.Vertex(a.ToArray());
                    gl.TexCoord(1f, 1f);
                    gl.Vertex(b.ToArray());
                    gl.TexCoord(0f, 1f);
                    gl.Vertex(c.ToArray());
                    gl.TexCoord(0f, 0f);
                    gl.Vertex(d.ToArray());
                }
                gl.End();
            }


            gl.Translate(0, height + 0.01f * height, 0);
            if (chessFigure!=null)
                chessFigure.ForEach(x => x.Draw(gl));

            gl.PopClientAttrib();
            gl.PopAttrib();
            gl.PopMatrix();
        }
    }
}

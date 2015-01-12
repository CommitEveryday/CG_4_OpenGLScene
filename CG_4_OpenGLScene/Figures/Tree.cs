using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.Enumerations;
using SharpGL;

namespace CG_4_OpenGLScene
{
    class Tree : AbstractFigure
    {
        ColorF color;
        ColorF trunkColor;
        public float scaleKoef { get; protected set; }

        public Tree(ColorF mainColor, ColorF baseColor, Point3D position, float scaleKoef = 1)
            : base(position)
        {
            this.color = mainColor;
            this.scaleKoef = scaleKoef;
            this.trunkColor = baseColor;
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            //float defaultHeight = 0.3f * 3 + 0.2f;
            gl.PushMatrix();
            gl.Translate(position.x, position.y, position.z);
            gl.Rotate(-90, 1, 0, 0);
            gl.Scale(scaleKoef, scaleKoef, scaleKoef);
            //gl.Color(color.GetInArr());
            //float curHeight = 0.25f;

            //gl.Cylinder(gl.NewQuadric(), curHeight / 2, curHeight / 2, curHeight, 20, 20);
            //gl.Translate(0, 0, 0.25f);
            //curHeight = 5f / 14f;
            //gl.Cylinder(gl.NewQuadric(), curHeight, 0, curHeight, 20, 20);
            //gl.Translate(0, 0, 0.25f);
            //curHeight = 4f / 14f;
            //gl.Cylinder(gl.NewQuadric(), curHeight, 0, curHeight, 20, 20);
            //gl.Translate(0, 0, 0.25f);
            //curHeight = 3f / 14f;
            //gl.Cylinder(gl.NewQuadric(), curHeight, 0, curHeight, 20, 20);
            gl.Color(trunkColor.GetInArrWithAlpha());
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, trunkColor.GetInArrWithAlpha());
            gl.Cylinder(gl.NewQuadric(), 0.1, 0.1, 0.4, 20, 20);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, color.GetInArrWithAlpha());
            gl.Color(color.GetInArrWithAlpha());
            gl.Translate(0, 0, 0.2);
            gl.Cylinder(gl.NewQuadric(), 0.5, 0, 0.5, 20, 20);
            gl.Translate(0, 0, 0.3);
            gl.Cylinder(gl.NewQuadric(), 0.4, 0, 0.4, 20, 20);
            gl.Translate(0, 0, 0.3);
            gl.Cylinder(gl.NewQuadric(), 0.3, 0, 0.3, 20, 20);

            gl.PopMatrix();
        }
    }
}

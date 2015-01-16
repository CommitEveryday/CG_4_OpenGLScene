using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.SceneGraph.Assets;
using SharpGL.Enumerations;
using SharpGL;

namespace CG_4_OpenGLScene.Figures
{
    class Table : AbstractColorFigure
    {
        private float sizeX, sizeY, sizeZ;
        Texture texture;

        Parallelepiped top, n1, n2, n3, n4;

        public Table(OpenGL gl, ColorF color, Point3D position, float sizeX = 1, float sizeY = 1, float sizeZ = 1, Texture texture = null)
            : base(color, position)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.sizeZ = sizeZ;
            this.texture = texture;
            float scaleText = 1;
            TwoVal repXdir = new TwoVal(sizeZ / scaleText, 0.1f * sizeY / scaleText);
            TwoVal repYdir = new TwoVal(sizeX / scaleText, sizeZ / scaleText);
            TwoVal repZdir = new TwoVal(sizeX / scaleText, 0.1f * sizeY / scaleText);
            top = new ParallelepipedWithDiffTextures(color, new Point3D(0, sizeY * 0.9f, 0), sizeX, 0.1f * sizeY, sizeZ, texture,
                texture, texture, texture, texture, texture,
                new TwoVal[] { repZdir, repYdir, repZdir, repYdir, repXdir, repXdir });
            n1 = new Parallelepiped(color, new Point3D(0.4f * sizeX, 0, 0.4f * sizeZ), sizeX * 0.1f, 0.9f * sizeY, sizeZ * 0.1f, texture);
            n2 = new Parallelepiped(color, new Point3D(0.4f * sizeX, 0, -0.4f * sizeZ), sizeX * 0.1f, 0.9f * sizeY, sizeZ * 0.1f, texture);
            n3 = new Parallelepiped(color, new Point3D(-0.4f * sizeX, 0, -0.4f * sizeZ), sizeX * 0.1f, 0.9f * sizeY, sizeZ * 0.1f, texture);
            n4 = new Parallelepiped(color, new Point3D(-0.4f * sizeX, 0, 0.4f * sizeZ), sizeX * 0.1f, 0.9f * sizeY, sizeZ * 0.1f, texture);
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushMatrix();
            gl.PushAttrib(AttributeMask.All);
            gl.PushClientAttrib(OpenGL.GL_CLIENT_ALL_ATTRIB_BITS);

            gl.Translate(position.x, position.y, position.z);

            top.Draw(gl);
            n1.Draw(gl);
            n2.Draw(gl);
            n3.Draw(gl);
            n4.Draw(gl);

            gl.PopClientAttrib();
            gl.PopAttrib();
            gl.PopMatrix();
        }
    }
}


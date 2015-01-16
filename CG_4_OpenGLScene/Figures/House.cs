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
    class House : AbstractColorFigure
    {
        private float sizeX;
        private float sizeY;
        private float sizeZ;
        private uint ListInd;
        public House(OpenGL gl, ColorF color, Point3D position, float sizeX = 1, float sizeY = 1, float sizeZ = 1, Texture textureFloor = null,
            Texture textureWall = null, Texture textureWindow = null, Texture textureWallOuter = null, Texture textureDoor = null,
            Texture textInnerTop = null, Texture textureOuterTop = null)
            : base(color, position)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.sizeZ = sizeZ;

            ListInd = gl.GenLists(1);
            gl.NewList(ListInd, OpenGL.GL_COMPILE);
            {
                DrawFigure(gl, textureFloor, textureWall, textureWindow, textureWallOuter, textureDoor,
                    textInnerTop, textureOuterTop);
            }
            gl.EndList();
        }

        private void DrawFigure(OpenGL gl, Texture textureFloor, Texture textureWall, Texture textureWindow,
            Texture textureWallOuter, Texture textureDoor, Texture textInnerTop, Texture textureOuterTop)
        {
            gl.Color(color.GetInArrWithAlpha());
            float halfSizeX = sizeX / 2;
            float halfSizeY = sizeY / 2;
            float halfSizeZ = sizeZ / 2;
            float border = sizeY * 0.05f;
            float halfBorder = border/2;
            //пол
            TwoVal oneRep = new TwoVal();
            oneRep.x = 1;
            oneRep.y = 1;
            TwoVal repFloor = new TwoVal();
            repFloor.x = sizeX / 4;
            repFloor.y = sizeZ / 4;
            (new ParallelepipedWithDiffTextures(new ColorF(1, 1, 1, 1f),
                new Point3D(0, 0, 0), sizeX, border, sizeZ, null, null, textureFloor, null, null, null,
                new TwoVal[] { oneRep, repFloor, oneRep, oneRep, oneRep, oneRep })).Draw(gl);
            gl.Translate(0, border, 0);
            TwoVal repWall = new TwoVal();
            repWall.x = sizeZ / 10;
            repWall.y = sizeY / 10;
            //левая
            (new ParallelepipedWithDiffTextures(new ColorF(1, 1, 1, 1f),
                new Point3D(-halfSizeX + halfBorder, 0, 0), border, sizeY - 2 * border, sizeZ, textureWall,
                textureWallOuter, null,null,null,null,
                new TwoVal[] { oneRep, oneRep, oneRep, oneRep, repWall, repWall })).Draw(gl);
            repWall.x = sizeX / 10;
            //задняя
            (new ParallelepipedWithDiffTextures(new ColorF(1, 1, 1, 1f),
                new Point3D(0, 0, -halfSizeZ + halfBorder), sizeX-2*border, sizeY - 2 * border, border, null,
                null, null, null, textureWall, textureWallOuter,
                new TwoVal[] { repWall, oneRep, repWall, oneRep, oneRep, oneRep })).Draw(gl);
            //правая
            float windowsWidth = 0.15f * sizeZ;
            float curZs = (sizeZ - windowsWidth)/2;
            repWall.x = curZs / 10;
            (new ParallelepipedWithDiffTextures(new ColorF(1, 1, 1, 1f),
                new Point3D(halfSizeX - halfBorder, 0, -curZs/2 - windowsWidth / 2), border, sizeY - 2 * border, curZs, textureWallOuter,
                textureWall, null, null, null, null, new TwoVal[] { oneRep, oneRep, oneRep, oneRep, repWall, repWall })).Draw(gl);
            (new ParallelepipedWithDiffTextures(new ColorF(1, 1, 1, 1f),
                new Point3D(halfSizeX - halfBorder, 0, curZs / 2 + windowsWidth / 2), border, sizeY - 2 * border, curZs, textureWallOuter,
                textureWall, null, null, null, null, new TwoVal[] { oneRep, oneRep, oneRep, oneRep, repWall, repWall })).Draw(gl);
            
            //передняя
            float doorWidth = 0.15f * sizeX;
            float curXs = (sizeX-2*border - doorWidth) / 2;
            repWall.x = curXs / 10;
            (new ParallelepipedWithDiffTextures(new ColorF(1, 1, 1, 1f),
                new Point3D(curXs / 2 + doorWidth / 2, 0, halfSizeZ - halfBorder), curXs, sizeY - 2 * border, border, null,
                null, null, null, textureWallOuter, textureWall,
                new TwoVal[] { repWall, oneRep, repWall, oneRep, oneRep, oneRep })).Draw(gl);
            (new ParallelepipedWithDiffTextures(new ColorF(1, 1, 1, 1f),
                new Point3D(-curXs / 2 - doorWidth / 2, 0, halfSizeZ - halfBorder), curXs, sizeY - 2 * border, border, null,
                null, null, null, textureWallOuter, textureWall,
                new TwoVal[] { repWall, oneRep, repWall, oneRep, oneRep, oneRep })).Draw(gl);
            //дверь
            repWall.x = doorWidth / 10;
            (new ParallelepipedWithDiffTextures(new ColorF(1, 1, 1, 1f),
                new Point3D(0, 0, halfSizeZ - halfBorder), doorWidth, sizeY - 2 * border, border, null,
                null, null, null, textureDoor, textureDoor)).Draw(gl);
            //потолок
            gl.PushMatrix();
            gl.Translate(0, sizeY - 2 * border, 0);
            (new ParallelepipedWithDiffTextures(new ColorF(1, 1, 1, 1f),
                new Point3D(0, 0, 0), sizeX, border, sizeZ, null, null, textureOuterTop, textInnerTop, null, null,
                new TwoVal[] { oneRep, repFloor, oneRep, repFloor, oneRep, oneRep })).Draw(gl);
            gl.PopMatrix();
            //окно рисуем в конце, чтобы при смешивании просвечивались стены
            repWall.x = windowsWidth / 10;
            (new ParallelepipedWithDiffTextures(new ColorF(Color.FromArgb(100, Color.LightCyan)),
                new Point3D(halfSizeX - halfBorder, 0, 0), border, sizeY - 2 * border, windowsWidth, textureWindow,
                textureWindow, null, null, null, null)).Draw(gl);
        }

        public override void Draw(OpenGL gl)
        {
            gl.PushAttrib(AttributeMask.All);
            gl.PushMatrix();
            gl.Translate(position.x, position.y, position.z);

            gl.CallList(ListInd);

            gl.PopMatrix();
            gl.PopAttrib();
        }
    }
}

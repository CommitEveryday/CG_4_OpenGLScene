using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace CG_4_OpenGLScene.Figures
{
    class ChessFigures : AbstractFigure
    {
        private const float scale = 0.025f;

        private uint ListInd;

        private float boardSize;
        private ColorF colorWhite;
        private ColorF colorBlack;
        private Texture textureWhite;
        private Texture textureBlack;
        private FigureFromOBJSharpGL Bishop;
        private FigureFromOBJSharpGL King;
        private FigureFromOBJSharpGL Knight;
        private FigureFromOBJSharpGL Pawn;
        private FigureFromOBJSharpGL Queen;
        private FigureFromOBJSharpGL Rook;

        public ChessFigures(OpenGL gl, Point3D position, float boardSize, ColorF colorWhite, ColorF colorBlack, Texture textureWhite = null,
            Texture textureBlack = null)
            :base(position)
        {
            this.boardSize = boardSize;
            this.colorWhite = colorWhite;
            this.colorBlack = colorBlack;
            this.textureWhite = textureWhite;
            this.textureBlack = textureBlack;

            Bishop = new FigureFromOBJSharpGL(gl, new Point3D(),
                @"ModelOBJ\Bishop.obj", scale);
            King = new FigureFromOBJSharpGL(gl, new Point3D(),
                @"ModelOBJ\King.obj", scale);
            Knight = new FigureFromOBJSharpGL(gl, new Point3D(),
                @"ModelOBJ\Knight.obj", scale);
            Pawn = new FigureFromOBJSharpGL(gl, new Point3D(),
                @"ModelOBJ\Pawn.obj", scale);
            Queen = new FigureFromOBJSharpGL(gl, new Point3D(),
                @"ModelOBJ\Queen.obj", scale);
            Rook = new FigureFromOBJSharpGL(gl, new Point3D(),
                @"ModelOBJ\Rook.obj", scale);

            ListInd = gl.GenLists(1);
            gl.NewList(ListInd, OpenGL.GL_COMPILE);
            {
                gl.Translate(position.x, position.y, position.z);
                DrawFigures(gl, boardSize, colorWhite, colorBlack, textureWhite, textureBlack);
            }
            gl.EndList();
        }

        private void DrawFigures(OpenGL gl, float boardSize, ColorF colorWhite, ColorF colorBlack, Texture textureWhite, Texture textureBlack)
        {
            float[] specular1 = { 1, 1, 1, 1 };
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, specular1);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SHININESS, 10);

            gl.Color(colorWhite.GetInArrWithAlpha());
            if (textureWhite != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                textureWhite.Push(gl);
            }
            else
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            //белые
            for (int i=0; i<8; i++)
                DrawFigureInPosition(gl, Pawn, (char)('a'+i), 2);
            DrawFigureInPosition(gl, Rook, 'a', 1);
            DrawFigureInPosition(gl, Knight, 'b', 1);
            DrawFigureInPosition(gl, Bishop, 'c', 1);
            DrawFigureInPosition(gl, Queen, 'd', 1);
            DrawFigureInPosition(gl, King, 'e', 1);
            DrawFigureInPosition(gl, Bishop, 'f', 1);
            DrawFigureInPosition(gl, Knight, 'g', 1);
            DrawFigureInPosition(gl, Rook, 'h', 1);
            if (textureWhite != null)
            {
                textureWhite.Pop(gl);
            }

            gl.Color(colorBlack.GetInArrWithAlpha());
            if (textureBlack != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                textureBlack.Push(gl);
            }
            else
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            //чёрные
            for (int i = 0; i < 8; i++)
                DrawFigureInPosition(gl, Pawn, (char)('a' + i), 7);
            DrawFigureInPosition(gl, Rook, 'a', 8);
            DrawFigureInPosition(gl, Knight, 'b', 8);
            DrawFigureInPosition(gl, Bishop, 'c', 8);
            DrawFigureInPosition(gl, Queen, 'd', 8);
            DrawFigureInPosition(gl, King, 'e', 8);
            DrawFigureInPosition(gl, Bishop, 'f', 8);
            DrawFigureInPosition(gl, Knight, 'g', 8);
            DrawFigureInPosition(gl, Rook, 'h', 8);
            if (textureBlack != null)
            {
                textureBlack.Pop(gl);
            }

            
        }

        public override void Draw(OpenGL gl)
        {
            gl.PushAttrib(SharpGL.Enumerations.AttributeMask.All);
            gl.PushMatrix();

            //gl.Translate(position.x, position.y, position.z);
            //DrawFigures(gl, boardSize, colorWhite, colorBlack, textureWhite, textureBlack);
            gl.CallList(ListInd);

            gl.PopMatrix();
            gl.PopAttrib();
        }

        private void DrawFigureInPosition(OpenGL gl, FigureFromOBJSharpGL figure, char x, int y)
        {
            gl.PushMatrix();
            DoTranslateToPosition(gl, x, y);
            gl.Rotate(90, 0, 1, 0);
            figure.Draw(gl);
            gl.PopMatrix();
        }

        private void DoTranslateToPosition(OpenGL gl, char x, int y)
        {
            float quardSize = boardSize / 8;
            float halfQuard = quardSize / 2;
            float dx = quardSize * 3 + halfQuard;
            float dz = quardSize * 3 + halfQuard;
            int x_int = x.ToString().ToLower()[0]-'a';
            y--;
            int signX, signZ;
            int stepByX = GetCountFullStep(y, out signX);
            int stepByZ = GetCountFullStep(x_int, out signZ);
            gl.Translate(stepByX * quardSize + signX * halfQuard, 0,
                stepByZ * quardSize + signZ * halfQuard);
        }

        private int GetCountFullStep(int curInd, out int sign)
        {
            sign = Math.Sign(curInd - 3.5);
            int res = (int)(curInd - 3.5);
            return res;
        }
    }
}

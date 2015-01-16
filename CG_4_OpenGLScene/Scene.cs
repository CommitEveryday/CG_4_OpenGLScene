using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using System.Windows.Forms;
using System.Drawing;
using CG_4_OpenGLScene.Lighting;
using SharpGL.Enumerations;
using CG_4_OpenGLScene.Figures;
using SharpGL.SceneGraph.Assets;

namespace CG_4_OpenGLScene
{
    class Scene
    {
        public bool ShowAxis { get; set; }
        public bool ShowGrid { get; set; }
        Axis axis;
        Grid grid;

        /*
            glColor3f(0.0,0.0,0.0);      черный
            glColor3f(1.0,0.0,0.0);      красный
            glColor3f(0.0,1.0,0.0);      зеленый
            glColor3f(1.0,1.0,0.0);      желтый
            glColor3f(0.0,0.0,1.0);      синий
            glColor3f(1.0,0.0,1.0);      фиолетовый
            glColor3f(0.0,1.0,1.0);      голубой
            glColor3f(1.0,1.0,1.0);      белый 
             * */

        List<AbstractFigure> figs;

        MovingLight light0;
        SourceLight light1;

        public Scene(OpenGL gl)
        {
            ShowAxis = false;
            ShowGrid = false;
            axis = new Axis(new Point3D(), 10);
            grid = new Grid(new ColorF(0.5f, 0.5f, 0.5f), new Point3D());
            figs = new List<AbstractFigure>();

            Texture textGround = new Texture();
            textGround.Create(gl, @"Texture\grass_8.jpg");

            //для отражения рисуем в другом месте отдельно
            figs.Add(new Ground(new ColorF(0.5f, 0.5f, 0.5f), new Point3D(0, 0, 0), 200, 200, textGround));

            float[] greencolor = new float[] { 0.2f, 0.8f, 0.0f, 1f };//   # Зеленый цвет для иголок
            float[] treecolor = new float[] { 0.9f, 0.6f, 0.3f, 1f };//    # Коричневый цвет для ствола
            //figs.Add(new Tree(new ColorF(greencolor[0], greencolor[1], greencolor[2], greencolor[3]),
            //    new ColorF(treecolor[0], treecolor[1], treecolor[2], treecolor[3]),
            //    new Point3D(0, 0, 0), 1));

            //figs.Add(new Tree(new ColorF(greencolor[0], greencolor[1], greencolor[2], greencolor[3]),
            //    new ColorF(treecolor[0], treecolor[1], treecolor[2], treecolor[3]),
            //    new Point3D(3, 0, -3), 2));

            ColorSettingLight colorSet;
            colorSet.Ambient = new ColorF(0,0,0,1);
            colorSet.Specular = new ColorF(1f,1f,1f,1);
            colorSet.Diffuse = new ColorF(0f,0.8f,0,1);
            light0 = new MovingLight(gl, LightName.Light0, new HomogeneousCoordinates(7, 5, 7), colorSet);

            colorSet.Diffuse = new ColorF(Color.Yellow);
            light1 = new SourceLight(gl, LightName.Light1, new HomogeneousCoordinates(-1, 1, -1, 0), colorSet);
            
            Texture textWood = new Texture();
            textWood.Create(gl, @"Texture\wood.jpg");

            Texture textBoard = new Texture();
            textBoard.Create(gl, @"Texture\chess_board3.jpg");

            Texture textTable = new Texture();
            textTable.Create(gl, @"Texture\marble_table.jpg");
            float tableHeight = 3;
            float tableSize = 6;
            figs.Add(new Table(gl, new ColorF(Color.White), new Point3D(), tableSize, tableHeight, tableSize, textTable));

            //board and figure
            Board board;
            board = new Board(gl, new ColorF(Color.White), new Point3D(0, tableHeight, 0), tableSize*0.8f, 0.05f * tableHeight, textWood, textBoard);
            figs.Add(board);

            Texture text_white = new Texture();
            text_white.Create(gl, @"Texture\wood_white.jpg");
            Texture text_black = new Texture();
            text_black.Create(gl, @"Texture\wood_black.jpg");
            //figs.Add(new ChessFigures(gl, new Point3D(0, tableHeight + 0.05f * tableHeight, 0), tableSize * 0.8f, new ColorF(Color.White),
            //    new ColorF(Color.White), text_white, text_black));
            figs.Add(new ChessFigures(gl, new Point3D(0, tableHeight + 0.05f * tableHeight, 0), tableSize * 0.8f, 
                new ColorF(Color.FromArgb(242,213,167)),
                new ColorF(Color.FromArgb(39,27,8))));

            Texture textGlass = new Texture();
            textGlass.Create(gl, @"Texture\clear_glass.jpg");

            Texture textDoor = new Texture();
            textDoor.Create(gl, @"Texture\door.jpg");

            Texture textFloor = new Texture();
            textFloor.Create(gl, @"Texture\floor.jpg");

            Texture textOuterWall = new Texture();
            textOuterWall.Create(gl, @"Texture\brick_28.jpg");

            Texture textInnerWall = new Texture();
            textInnerWall.Create(gl, @"Texture\wallpaper_4.jpg");

            Texture textInnerTop = new Texture();
            textInnerTop.Create(gl, @"Texture\top.jpg");

            Texture textureOuterTop = new Texture();
            textureOuterTop.Create(gl, @"Texture\roof_12.jpg");

            figs.Add(new House(gl, new ColorF(1, 1, 0), new Point3D(), 40, 10, 30, textFloor, textInnerWall, textGlass, textOuterWall, textDoor,
                textInnerTop, textureOuterTop));

            
        }

        /// <summary>
        /// Предполагается, что текущая матрица видовая.
        /// (Modelview)
        /// </summary>
        /// <param name="gl"></param>
        public void Draw(SharpGL.OpenGL gl)
        {
            //! свет важно задавать после установки видовой матрицы!
            light0.Draw();
            light1.Draw();
            if (ShowAxis)
                axis.Draw(gl);
            if (ShowGrid)
                grid.Draw(gl);
            //версия с отражением от пола
            //gl.PushMatrix();
            //gl.PushAttrib(AttributeMask.All);
            //gl.Scale(1, -1, 1);
            //gl.FrontFace(OpenGL.GL_CW);
            //figs.ForEach(x => x.Draw(gl));
            //gl.PopMatrix();
            //gl.Enable(OpenGL.GL_BLEND);
            //gl.FrontFace(OpenGL.GL_CCW);
            //(new Ground(new ColorF(0.5f, 0.5f, 0.5f, 0.8f), new Point3D(0, 0, 0), 200, 200)).Draw(gl);
            //gl.PopAttrib();

            //без отражения
            figs.ForEach(x => x.Draw(gl));
            
        }

        public bool AddFigure(AbstractFigure fig)
        {
            if (figs.Contains(fig))
                return false;
            figs.Add(fig);
            return true;
        }

        public void MoveLight()
        {
            light0.Move();
        }

        public void SetColorForLight0(ColorSettingLight colorSet)
        {
            light0.SetColorSet(colorSet);
        }
    }
}

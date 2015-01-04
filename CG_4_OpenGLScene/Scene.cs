using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using System.Windows.Forms;
using System.Drawing;

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

        public Scene()
        {
            ShowAxis = false;
            axis = new Axis(new Point3D(), 10);
            grid = new Grid(new ColorF(0.5f, 0.5f, 0.5f), new Point3D());
            //TODO задание параметро объектов сцены
            figs = new List<AbstractFigure>();
            figs.Add(new Ground(new ColorF(0.5f, 0.5f, 0.5f), new Point3D(0, 0, 0), 20, 20));
            float[] greencolor = new float[] { 0.2f, 0.8f, 0.0f, 0.8f };//   # Зеленый цвет для иголок
            float[] treecolor = new float[] { 0.9f, 0.6f, 0.3f, 0.8f };//    # Коричневый цвет для ствола
            figs.Add(new Tree(new ColorF(greencolor[0], greencolor[1], greencolor[2], greencolor[3]),
                new ColorF(treecolor[0], treecolor[1], treecolor[2], treecolor[3]),
                new Point3D(0, 0, 0), 1));

            figs.Add(new Tree(new ColorF(greencolor[0], greencolor[1], greencolor[2], greencolor[3]),
                new ColorF(treecolor[0], treecolor[1], treecolor[2], treecolor[3]),
                new Point3D(3, 0, -3), 2));

            figs.Add(new Icosahedron(new ColorF(Color.Yellow), new Point3D(-5,0,5), 1));

            figs.Add(new Triangle(new Point3D(5, 0, 0), 1));

            figs.Add(new Pyramid(new Point3D(5,0,5)));

            //figs.Add(new Pyramid(new Point3D(5, 5, 5), 2));

            //figs.Add(new Pyramid(new Point3D(-5, 0, 5), 20, 2));

            figs.Add(new Cube(new ColorF(Color.LemonChiffon), new Point3D(-5,0,-5), 2));
        }

        /// <summary>
        /// Предполагается, что текущая матрица видовая.
        /// (Modelview)
        /// </summary>
        /// <param name="gl"></param>
        public void Draw(SharpGL.OpenGL gl)
        {
            if (ShowAxis)
                axis.Draw(gl);
            if (ShowGrid)
                grid.Draw(gl);
            figs.ForEach(x => x.Draw(gl));
        }
    }
}

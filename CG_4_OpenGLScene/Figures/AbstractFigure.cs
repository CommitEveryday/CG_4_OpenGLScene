using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using System.Drawing;

namespace CG_4_OpenGLScene
{
    /// <summary>
    /// Фигура. Позиция определяет координату нижней точки фигуры
    /// </summary>
    abstract class AbstractFigure
    {
        public Point3D position { get; protected set; }
        

        /// <summary>
        /// Позиция нижней точки фигуры
        /// </summary>
        /// <param name="position"></param>
        public AbstractFigure(Point3D position)
        {
            this.position = position;
        }

        public abstract void Draw(OpenGL gl);
    }
}

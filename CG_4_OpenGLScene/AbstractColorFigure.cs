using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG_4_OpenGLScene
{
    abstract class AbstractColorFigure : AbstractFigure
    {
        public ColorF color { get; protected set; }

        public AbstractColorFigure(ColorF color, Point3D position)
            :base(position)
        {
            this.color = color;
        }
    }
}

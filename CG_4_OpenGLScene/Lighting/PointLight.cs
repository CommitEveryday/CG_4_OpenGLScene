using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG_4_OpenGLScene.Lighting
{
    using CG_4_OpenGLScene;
    using SharpGL.Enumerations;

    class PointLight : AbstractFigure
    {
        public PointLight(Point3D position)
            :base(position)
        {
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushAttrib(AttributeMask.Point);
            gl.PointSize(10);
            gl.Color(1f, 1f, 1f, 1f);
            gl.Begin(BeginMode.Points);
            gl.Vertex(position.ToArray());
            gl.End();
            gl.PopAttrib();
        }
    }
}

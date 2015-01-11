using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.Enumerations;
using FileFormatWavefront;

namespace CG_4_OpenGLScene
{
    class FigureFromOBJ : AbstractColorFigure
    {
        private FileLoadResult<FileFormatWavefront.Model.Scene> result;

        public FigureFromOBJ(ColorF color, Point3D position, string fileName)
            : base(color, position)
        {
            result = FileFormatObj.Load(fileName);
        }

        public override void Draw(SharpGL.OpenGL gl)
        {
            gl.PushAttrib(AttributeMask.All);
            gl.PushMatrix();
            gl.Translate(position.x, position.y, position.z);
            gl.Scale(0.1f, 0.1f, 0.1f);
            gl.Color(color.GetInArrWithAlpha());

            foreach (var face in result.Model.Groups[0].Faces)
            {
                gl.Begin(BeginMode.Polygon);
                foreach (var inds in face.Indices)
                {
                   var vert  = result.Model.Vertices[inds.vertex];
                   gl.Vertex(vert.x, vert.y, vert.z);
                }
                gl.End();
            }

            gl.PopMatrix();
            gl.PopAttrib();
        }
    }
}

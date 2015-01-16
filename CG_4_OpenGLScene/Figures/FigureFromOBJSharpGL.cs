using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.Serialization.Wavefront;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Core;
using SharpGL.Enumerations;
using SharpGL.SceneGraph.Assets;

namespace CG_4_OpenGLScene.Figures
{
    /// <summary>
    /// Добавление текстуры вносит нереальные тормоза
    /// (исправлено обновлением драйвера)
    /// </summary>
    class FigureFromOBJSharpGL : AbstractFigure
    {
        private uint ListInd;

        public FigureFromOBJSharpGL(OpenGL gl, Point3D position, string fileName, float scale = 1)
            : base(position)
        {
            ObjFileFormat objFile = new ObjFileFormat();
            var res = objFile.LoadData(fileName);
            ListInd = gl.GenLists(1);
            gl.NewList(ListInd, OpenGL.GL_COMPILE);
            {
                gl.Translate(position.x, position.y, position.z);
                gl.Scale(scale, scale, scale);
                DrawFigure(gl, res.SceneContainer.Traverse<Polygon>().ElementAt(0));
            }
            gl.EndList();
        }

        private void DrawFigure(OpenGL gl, Polygon rootPolygon)
        {
            foreach (Face face in rootPolygon.Faces)
            {
                gl.Begin(BeginMode.Polygon);
                foreach (var inds in face.Indices)
                {
                    if (inds.Normal!=-1)
                    {
                        var norm = rootPolygon.Normals[inds.Normal];
                        gl.Normal(norm.X, norm.Y, norm.Z);
                    }
                    if (inds.UV != -1)
                    {
                        var textCoord = rootPolygon.UVs[inds.UV];
                        gl.TexCoord(textCoord.U, textCoord.V);
                    }
                    var vert = rootPolygon.Vertices[inds.Vertex];
                    gl.Vertex(vert.X, vert.Y, vert.Z);
                }
                gl.End();
            }
        }

        public override void Draw(OpenGL gl)
        {
            gl.PushAttrib(AttributeMask.All);
            gl.PushMatrix();

            gl.CallList(ListInd);

            gl.PopMatrix();
            gl.PopAttrib();
        }
    }
}

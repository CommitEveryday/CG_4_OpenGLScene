using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.Enumerations;
using FileFormatWavefront;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace CG_4_OpenGLScene
{
    class FigureFromOBJ : AbstractColorFigure
    {
        private FileLoadResult<FileFormatWavefront.Model.Scene> result;
        Texture texture;
        private float scale;
        uint ListInd;

        public FigureFromOBJ(OpenGL gl, ColorF color, Point3D position, string fileName, Texture texture = null, float scale = 1)
            : base(color, position)
        {
            result = FileFormatObj.Load(fileName);
            this.texture = texture;
            this.scale = scale;
            ListInd = gl.GenLists(1);
            gl.NewList(ListInd, OpenGL.GL_COMPILE);
            {
                DrawFigure(gl);
            }
            gl.EndList();
        }

        private void DrawFigure(OpenGL gl)
        {
            
            gl.Color(color.GetInArrWithAlpha());
            
            IEnumerable<FileFormatWavefront.Model.Face> enumerate = result.Model.UngroupedFaces;
            if (result.Model.Groups.Count > 0)
                enumerate = result.Model.Groups[0].Faces;
            foreach (var face in enumerate)
            {
                gl.Begin(BeginMode.Polygon);
                foreach (var inds in face.Indices)
                {
                    //совершенно запутался, почему индекс порой выходит за размер массива. То ли он не с нуля,
                    //то ли считываются не все данные. Лезут какие-то ошбики.
                    //возможно проблема в библиотеке FileFormatWavefront
                    //стоит рассмотреть библиотеку ObjLoader
                    //проблема решена: в самом SharpGL есть методы десериализации
                    //сцены из OBJ-файла
                    if (inds.normal.HasValue && (inds.normal.Value - 1) < result.Model.Normals.Count)
                    {
                        var norm = result.Model.Normals[inds.normal.Value - 1];
                        gl.Normal(norm.x, norm.y, norm.z);
                    }
                    if (inds.uv.HasValue && (inds.uv.Value - 1) < result.Model.Uvs.Count)
                    {
                        var textCoord = result.Model.Uvs[inds.uv.Value - 1];
                        gl.TexCoord(textCoord.u, textCoord.v);
                    }

                    if (inds.vertex < result.Model.Vertices.Count)
                    {
                        var vert = result.Model.Vertices[inds.vertex];
                        gl.Vertex(vert.x, vert.y, vert.z);
                    }

                }
                gl.End();
            }
            
        }

        public override void Draw(OpenGL gl)
        {
            gl.PushAttrib(AttributeMask.All);
            gl.PushMatrix();
            gl.Translate(position.x, position.y, position.z);
            gl.Scale(scale, scale, scale);

            if (texture != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                texture.Bind(gl);
            }

            gl.CallList(ListInd);

            gl.PopMatrix();
            gl.PopAttrib();
        }
    }
}

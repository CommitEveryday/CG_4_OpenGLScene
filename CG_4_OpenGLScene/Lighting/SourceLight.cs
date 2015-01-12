using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene.Lighting
{
    class SourceLight
    {
        protected ColorSettingLight colorSet;
        protected HomogeneousCoordinates position;
        protected LightName lightNum;
        protected OpenGL gl;

        public SourceLight(OpenGL gl, LightName lightNum, HomogeneousCoordinates position, ColorSettingLight colorSet)
        {
            this.position = position;
            this.colorSet = colorSet;
            this.gl = gl;
            this.lightNum = lightNum;
            SetColorSet(colorSet);
        }

        public virtual void Draw()
        {
            gl.Light(lightNum, LightParameter.Position, position.ToArray());
            if (position.h == 1)
                DrawLightCube();
        }

        protected void DrawLightCube()
        {
            gl.PushMatrix();
            float cubeSize = 0.2f;
            Point3D cubePos = position.ToPoint3D();
            float halfSize = cubeSize / 2;
            gl.Translate(cubePos.x, cubePos.y, cubePos.z);
            Point3D[] vertex = new Point3D[]
            {
                new Point3D(halfSize, halfSize, halfSize),
                new Point3D(-halfSize, halfSize, halfSize),
                new Point3D(-halfSize, -halfSize, halfSize),
                new Point3D(halfSize, -halfSize, halfSize),
                new Point3D(halfSize, halfSize, -halfSize),
                new Point3D(-halfSize, halfSize, -halfSize),
                new Point3D(-halfSize, -halfSize, -halfSize),
                new Point3D(halfSize, -halfSize, -halfSize)
            };
            gl.Color(1f, 1f, 1f);
            QuardWithInnerNormals(gl, vertex[0], vertex[1], vertex[2], vertex[3]);
            QuardWithInnerNormals(gl, vertex[0], vertex[4], vertex[5], vertex[1]);
            QuardWithInnerNormals(gl, vertex[7], vertex[6], vertex[5], vertex[4]);
            QuardWithInnerNormals(gl, vertex[3], vertex[2], vertex[6], vertex[7]);
            QuardWithInnerNormals(gl, vertex[1], vertex[5], vertex[6], vertex[2]);
            QuardWithInnerNormals(gl, vertex[0], vertex[3], vertex[7], vertex[4]);
            gl.PopMatrix();
        }

        public static void QuardWithInnerNormals(OpenGL gl, Point3D a, Point3D b, Point3D c, Point3D d)
        {
            gl.PushAttrib(AttributeMask.All);
            Vector3d d1, d2, norm;
            d1 = new Vector3d(a, b);
            d2 = new Vector3d(b, c);
            norm = Vector3d.Product(d2, d1).GetNormalize(); //! нормаль напралена по внутрь!
            gl.Begin(BeginMode.Quads);
            {
                gl.Normal(norm.ToArray());
                gl.Vertex(a.ToArray());
                gl.Vertex(b.ToArray());
                gl.Vertex(c.ToArray());
                gl.Vertex(d.ToArray());
            }
            gl.End();
            gl.PopAttrib();
        }

        public void SetColorSet(ColorSettingLight colorSet)
        {
            this.colorSet = colorSet;
            gl.Light(lightNum, LightParameter.Ambient, colorSet.Ambient.GetInArrWithAlpha());
            gl.Light(lightNum, LightParameter.Diffuse, colorSet.Diffuse.GetInArrWithAlpha());
            gl.Light(lightNum, LightParameter.Specular, colorSet.Specular.GetInArrWithAlpha());
        }
    }
}

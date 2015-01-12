using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene.Lighting
{
    class MovingLight : SourceLight
    {
        float angleRot;

        public MovingLight(OpenGL gl, LightName lightNum, HomogeneousCoordinates position, ColorSettingLight colorSet)
            :base(gl,lightNum,position,colorSet)
        {
            this.position = position;
            this.colorSet = colorSet;
            this.gl = gl;
            this.lightNum = lightNum;
            SetColorSet(colorSet);
            angleRot = 0;
        }

        public override void Draw()
        {
            gl.PushMatrix();
            gl.Rotate(angleRot, 0, 1, 0);
            base.Draw();
            gl.PopMatrix();
        }

        public void Move()
        {
            angleRot += 5;
            checkAngle(ref angleRot); 
        }

        private void checkAngle(ref float angle)
        {
            while (angle >= 360) angle -= 360;
            while (angle <= -360) angle += 360;
        }
    }
}

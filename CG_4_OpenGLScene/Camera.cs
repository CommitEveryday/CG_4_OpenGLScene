using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CG_4_OpenGLScene
{
    class Camera
    {
        private readonly float sensForGo = 0.5f;
        private readonly float sensForX = 360f / Screen.PrimaryScreen.WorkingArea.Width;
        private readonly float sensForY = 360f / Screen.PrimaryScreen.WorkingArea.Height;

        private float angleVisionHorizontal = 0; //в градусах
        private float angleVisionVertical = 0;
        Point3D position;
        Vector3d eyeTrace;

        public Camera()
        {
            this.position = new Point3D(0,6,20);
            this.eyeTrace = new Vector3d(0, 0, -1);
        }

        public void view(SharpGL.OpenGL gl)
        {
            Vector3d viewVector = GetRotatedByAngles(eyeTrace.GetNormalize());
            Vector3d fromEyeToRight = new Vector3d(
                ((new HomogeneousCoordinates(eyeTrace.GetAsPoint3D())) * ConversionMatrix.GetRotationY(-Math.PI / 2)).ToPoint3D());
            fromEyeToRight = GetRotatedByAngles(fromEyeToRight);
            Vector3d vectorUp = Vector3d.Product(fromEyeToRight, viewVector).GetNormalize();
            Point3D seeTo = (new Vector3d(position) + viewVector).GetAsPoint3D();
            gl.LookAt(
                position.x, position.y, position.z,
                seeTo.x, seeTo.y, seeTo.z,
                vectorUp.x, vectorUp.y, vectorUp.z
                );
        }

        private Vector3d GetRotatedByAngles(Vector3d vec)
        {
            Matrix rotateInVertical = ConversionMatrix.GetRotationX(angleVisionVertical * (Math.PI / 180));
            Matrix rotateInHorizontal = ConversionMatrix.GetRotationY(angleVisionHorizontal * (Math.PI / 180));
            //сначала поворот вертикально, т.к. горизонтально всегда вокруг Y
            Vector3d res = new Vector3d(
                ((new HomogeneousCoordinates(vec.GetAsPoint3D())) * rotateInVertical).ToPoint3D());
            res = new Vector3d(
                ((new HomogeneousCoordinates(res.GetAsPoint3D())) * rotateInHorizontal).ToPoint3D());
            res = res.GetNormalize();
            return res;
        }

        public void GoForward()
        {
            Vector3d viewVectorNorm = GetRotatedByAngles(eyeTrace.GetNormalize()).GetNormalize();
            position = (new Vector3d(position) + (sensForGo * viewVectorNorm)).GetAsPoint3D();
        }

        public void GoBack()
        {
            Vector3d viewVectorNorm = GetRotatedByAngles(eyeTrace.GetNormalize()).GetNormalize();
            position = (new Vector3d(position) + (sensForGo * (-1) * viewVectorNorm)).GetAsPoint3D();
        }

        public void GoLeft()
        {
            Vector3d fromEyeToRightNorm = new Vector3d(
                ((new HomogeneousCoordinates(eyeTrace.GetAsPoint3D())) * ConversionMatrix.GetRotationY(-Math.PI / 2)).ToPoint3D());
            fromEyeToRightNorm = GetRotatedByAngles(fromEyeToRightNorm).GetNormalize();
            position = (new Vector3d(position) + (sensForGo * (-1) * fromEyeToRightNorm)).GetAsPoint3D();
        }

        public void GoRight()
        {
            Vector3d fromEyeToRightNorm = new Vector3d(
                ((new HomogeneousCoordinates(eyeTrace.GetAsPoint3D())) * ConversionMatrix.GetRotationY(-Math.PI / 2)).ToPoint3D());
            fromEyeToRightNorm = GetRotatedByAngles(fromEyeToRightNorm).GetNormalize();
            position = (new Vector3d(position) + (sensForGo * fromEyeToRightNorm)).GetAsPoint3D();
        }

        /// <summary>
        /// Вращение камеры на основе движения мыши в экранных координатах
        /// </summary>
        /// <param name="pixelDX">изменение координат мыши по горизонтали</param>
        /// <param name="pixledDY"></param>
        public void Rotate(float pixelDX, float pixelDY)
        {
            angleVisionHorizontal += pixelDX * sensForX;
            checkAngle(ref angleVisionHorizontal);
            angleVisionVertical += pixelDY * sensForY;
            checkAngle(ref angleVisionVertical);
            if (angleVisionVertical > 89)
                angleVisionVertical = 89;
            if (angleVisionVertical < -89)
                angleVisionVertical = -89;
        }

        private void checkAngle(ref float angle)
        {
            while (angle >= 360) angle -= 360;
            while (angle <= -360) angle += 360;
        }
    }
}

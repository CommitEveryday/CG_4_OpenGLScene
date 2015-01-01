using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CG_4_OpenGLScene
{
    class CameraFP
    {
        float sensForX = 360f / Screen.PrimaryScreen.WorkingArea.Width;
        float sensForY = 360f / Screen.PrimaryScreen.WorkingArea.Height;

        private float angleVisionHorizontal = 0;
        private float angleVisionVertical = 0;
        Point3D position;
        Vector3d eyeTrace;

        public CameraFP()
        {
            this.position = new Point3D(0,0,10);
            this.eyeTrace = new Vector3d(0, 0, -1);

        }

        public void view(SharpGL.OpenGL gl)
        {
            Vector3d viewVector = GetEyeVector().GetNormalize();
            Vector3d fromEyeToRight = new Vector3d(
                ((new HomogeneousCoordinates(viewVector.GetAsPoint3D())) * ConversionMatrix.GetRotationY(-Math.PI / 2)).ToPoint3D());
            Vector3d vectorUp = Vector3d.Product(fromEyeToRight, viewVector).GetNormalize();
            Point3D seeTo = (new Vector3d(position) + viewVector).GetAsPoint3D();
            gl.LookAt(
                position.x, position.y, position.z,
                seeTo.x, seeTo.y, seeTo.z,
                vectorUp.x, vectorUp.y, vectorUp.z
                );
        }

        private Vector3d GetEyeVector()
        {
            Matrix rotateInHorizontal = ConversionMatrix.GetRotationY(angleVisionHorizontal*(Math.PI/180));
            Matrix rotateInVertical = ConversionMatrix.GetRotationX(angleVisionVertical*(Math.PI/180));
            Vector3d eyeVectorXY = new Vector3d(
                ((new HomogeneousCoordinates(eyeTrace.GetAsPoint3D())) * rotateInHorizontal).ToPoint3D());
            Vector3d eyeVectorZ = new Vector3d(
                ((new HomogeneousCoordinates(eyeTrace.GetAsPoint3D())) * rotateInVertical).ToPoint3D());
            Vector3d eyeVector = new Vector3d(eyeVectorXY.x, eyeVectorXY.y, eyeVectorZ.z);
            eyeVector = eyeVector.GetNormalize();
            return eyeVector;
        }

        public void left(float pixel)
        {
            angleVisionHorizontal += pixel*sensForX;
            checkAngle(ref angleVisionHorizontal);
        }
        public void right(float pixel)
        {
            angleVisionHorizontal -= pixel * sensForX;
            checkAngle(ref angleVisionHorizontal);
        }
        public void up(float pixel)
        {
            angleVisionVertical -= pixel * sensForY;
            checkAngle(ref angleVisionVertical);
        }
        public void down(float pixel)
        {
            angleVisionVertical += pixel * sensForY;
            checkAngle(ref angleVisionVertical);
        }

        private void checkAngle(ref float angle)
        {
            if (angle >= 360) angle -= 360;
            if (angle < 0) angle += 360;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CG_4_OpenGLScene
{
    /// <summary>
    /// Интенсивность компонент от 0 до 1
    /// </summary>
    class ColorF
    {
        public float r, g, b, alpha;

        public ColorF(float r, float g, float b, float alpha = 1f)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.alpha = alpha;
        }

        public ColorF(Color colorDr)
        {
            this.r = colorDr.R / 255f;
            this.g = colorDr.G / 255f;
            this.b = colorDr.B / 255f;
            alpha = 1f;
        }

        public float[] GetInArr()
        {
            return new float[] { r, g, b };
        }

        public float[] GetInArrWithAlpha()
        {
            return new float[] { r, g, b, alpha};
        }
    }
}

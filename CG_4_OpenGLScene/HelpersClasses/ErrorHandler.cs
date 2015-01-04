using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using System.Windows.Forms;

namespace CG_4_OpenGLScene
{
    static class ErrorHandler
    {
        public static void TestError(OpenGL gl, RichTextBox log)
        {
            uint code;
            StringBuilder str = new StringBuilder();
            while ((code = gl.GetError()) != OpenGL.GL_NO_ERROR)
            {
                str.AppendLine(gl.GetErrorDescription(code));
            }
            if (str.Length > 0)
            {
                log.AppendText(str.ToString() + Environment.NewLine);
            }
        }
    }
}

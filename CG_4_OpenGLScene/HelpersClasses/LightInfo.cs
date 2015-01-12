using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene
{
    static class LightInfo
    {
        public static string GetInfo(OpenGL gl, uint lightNum)
        {
            StringBuilder str = new StringBuilder();
            float[] float4 = new float[4];
            gl.GetLight(lightNum, OpenGL.GL_AMBIENT, float4);
            str.AppendFormat("GL_AMBIENT: ({0}) (initial value is (0, 0, 0, 1))\r\n", String.Join(", ", float4));
            gl.GetLight(lightNum, OpenGL.GL_DIFFUSE, float4);
            str.AppendFormat("GL_DIFFUSE: ({0}) (initial value for GL_LIGHT0 is (1, 1, 1, 1); for other lights, the initial value is (0, 0, 0, 0))\r\n",
                String.Join(", ", float4));
            gl.GetLight(lightNum, OpenGL.GL_SPECULAR, float4);
            str.AppendFormat("GL_SPECULAR: ({0}) (initial value for GL_LIGHT0 is (1, 1, 1, 1); for other lights, the initial value is (0, 0, 0, 0))\r\n",
                String.Join(", ", float4));
            gl.GetLight(lightNum, OpenGL.GL_POSITION, float4);
            str.AppendFormat("GL_POSITION: ({0}) (initial value is (0, 0, 1, 0))\r\n",
                String.Join(", ", float4));
            float[] float3 = new float[3];
            gl.GetLight(lightNum, OpenGL.GL_SPOT_DIRECTION, float3);
            str.AppendFormat("GL_SPOT_DIRECTION: ({0}) (initial value is (0, 0, -1))\r\n",
                String.Join(", ", float3));
            float[] float1 = new float[1];
            gl.GetLight(lightNum, OpenGL.GL_SPOT_EXPONENT, float1);
            str.AppendFormat("GL_SPOT_EXPONENT: ({0}) (initial value is (0))\r\n",
                String.Join(", ", float1));
            gl.GetLight(lightNum, OpenGL.GL_SPOT_CUTOFF, float1);
            str.AppendFormat("GL_SPOT_CUTOFF: ({0}) (initial value is (180))\r\n",
                String.Join(", ", float1));
            gl.GetLight(lightNum, OpenGL.GL_CONSTANT_ATTENUATION, float1);
            str.AppendFormat("GL_CONSTANT_ATTENUATION: ({0}) (initial value is (1))\r\n",
                String.Join(", ", float1));
            gl.GetLight(lightNum, OpenGL.GL_LINEAR_ATTENUATION, float1);
            str.AppendFormat("GL_LINEAR_ATTENUATION: ({0}) (initial value is (0))\r\n",
                String.Join(", ", float1));
            gl.GetLight(lightNum, OpenGL.GL_QUADRATIC_ATTENUATION, float1);
            str.AppendFormat("GL_QUADRATIC_ATTENUATION: ({0}) (initial value is (0))\r\n",
                String.Join(", ", float1));
            return str.ToString();
        }

        public static string GetInfoLightModel(OpenGL gl)
        {
            StringBuilder str = new StringBuilder();
            float[] float4 = new float[4];
            gl.GetFloat(GetTarget.LightModelAmbient, float4);
            str.AppendFormat("GL_LIGHT_MODEL_AMBIENT: ({0}) (initial value is (0.2, 0.2, 0.2, 1.0))\r\n", String.Join(", ", float4));
            byte[] byte1 = new byte[1];
            gl.GetBooleanv(GetTarget.LightModelLocalViewer, byte1);
            str.AppendFormat("GL_LIGHT_MODEL_LOCAL_VIEWER: ({0}) (initial value is (FALSE))\r\n", String.Join(", ", byte1));
            gl.GetBooleanv(GetTarget.LightModelTwoSide, byte1);
            str.AppendFormat("GL_LIGHT_MODEL_TWO_SIDE: ({0}) (initial value is (FALSE))\r\n", String.Join(", ", byte1));
            
            return str.ToString();
        }
    }
}

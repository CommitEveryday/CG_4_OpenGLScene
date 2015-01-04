using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CG_4_OpenGLScene
{
    /// <summary>
    /// TODO если нужен, доделать и внедрить
    /// </summary>
    class Log
    {
        RichTextBox richTextBoxLog;
        public Log(RichTextBox rtb)
        {
            richTextBoxLog = rtb;
        }

        public void Print(string msg)
        {
            richTextBoxLog.AppendText(msg + Environment.NewLine);
        }

        public void Clear()
        {
            richTextBoxLog.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CG_4_OpenGLScene
{
    public partial class FormPerspectiveAngle : Form
    {
        public FormPerspectiveAngle()
        {
            InitializeComponent();
        }

        private void trackBarAngle_ValueChanged(object sender, EventArgs e)
        {
            labelCurAngle.Text = trackBarAngle.Value.ToString() + " °";
        }
    }
}

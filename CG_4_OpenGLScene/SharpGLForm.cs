using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using SharpGL.Enumerations;

namespace CG_4_OpenGLScene
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        Scene scene;
        bool changeAngleByMouse;
        Camera cam;
        Point prevMousePos;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RenderEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            richTextBoxLog.AppendText("openGLControl_OpenGLDraw\r\n");
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            gl.Light(LightName.Light1, LightParameter.Diffuse, new float[] { 1f, 1f, 0, 0 });
            gl.Light(LightName.Light1, LightParameter.Position, new float[] { 5f, 5f, 5f });

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //видовые проеобразования (установка камеры)
            gl.MatrixMode(MatrixMode.Modelview);
            gl.LoadIdentity();
            cam.view(gl);
            //camFP.view(gl);
            //далее модельные

            //отрисовка сцены
            scene.Draw(gl);

            //gl.Flush();
        }

        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            richTextBoxLog.AppendText("openGLControl_OpenGLInitialized\r\n");
            //  TODO: Initialise OpenGL here.
            scene = new Scene();
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            //gl.Enable(OpenGL.GL_CULL_FACE);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.PolygonMode(FaceMode.Back, PolygonMode.Filled);
            //gl.PolygonMode(FaceMode.Front, PolygonMode.Lines);
            gl.Enable(OpenGL.GL_NORMALIZE); //нормализация нормалей после масштабирования
            //  Set the clear color.
            gl.ClearColor(0, 0, 0, 1);

            cam = new Camera(new Point3D(), new Point3D());

            InitLight(gl);
        }

        private void InitLight(OpenGL gl)
        {
            float[] mat_specular = new float[]{1.0f,1.0f,1.0f,1.0f};
            float[]  mat_shininess = new float[]{50.0f};
            float[]  light_position = new float[]{0.0f,10.0f,0.0f,0.0f};
            float[]  white_light = new float[]{1.0f,1.0f,1.0f,1.0f};
            //gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SPECULAR, mat_specular);
            //gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, mat_shininess);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light_position);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, white_light);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, white_light);
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);

            gl.LightModel(LightModelParameter.LocalViewer, OpenGL.GL_TRUE);
            gl.LightModel(LightModelParameter.TwoSide, OpenGL.GL_TRUE);
            float[] lmodel_ambient = new float[]{1.2f,1.2f,1.2f,1.0f};
            //gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.Light(LightName.Light1, LightParameter.Diffuse, new float[]{1f, 1f, 0, 1f});
            gl.Light(LightName.Light1, LightParameter.Position, new float[] { 5f, 5f, 5f, 0 });
            //gl.Enable(OpenGL.GL_LIGHT1);

            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.ColorMaterial(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT_AND_DIFFUSE);
        }

        /// <summary>
        /// Handles the Resized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            richTextBoxLog.AppendText("openGLControl_Resized\r\n");
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            int w = openGLControl.ClientSize.Width;
            int h = openGLControl.ClientSize.Height;
            if (h == 0)
                h = 1;
            float aspectRatio = (float)w / (float)h;
            //gl.Viewport(0, 0, w, h); //SharpGP уже видимо настроил окно вывоад на весь openGLControl

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            PrintCurrentProjectionMatrix();
            //  Load the identity.
            gl.LoadIdentity();
            //gl.Ortho2D(-2, 2, -2, 2);
            PrintCurrentProjectionMatrix();
            //  Create a perspective transformation.
            gl.Perspective(60.0f, aspectRatio, 0.01, 100.0);

            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();

        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                prevMousePos = e.Location;
                changeAngleByMouse = true;
            }
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            changeAngleByMouse = false;
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (changeAngleByMouse)
            {
                float angle = -(prevMousePos.X - e.Location.X) / 2;
                cam.moveh(angle);
                angle = (e.Location.Y - prevMousePos.Y) / 2;
                cam.movev(-angle);
                prevMousePos = e.Location;
                openGLControl.DoRender();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            OpenGL Gl = openGLControl.OpenGL;
            if (keyData == Keys.Left)
            {
                cam.left();
            }
            else if (keyData == Keys.Right)
            {
                cam.right();
            }
            else if (keyData == Keys.Up)
            {
                cam.up();
            }
            else if (keyData == Keys.Down)
            {
                cam.down();
            }
            else if (keyData == Keys.Z)
            {
                cam++;
            }
            else if (keyData == Keys.X)
            {
                cam--;
            }
            else if (keyData == Keys.Q)
            {
                Gl.Enable(OpenGL.GL_LIGHT0);
            }
            else if (keyData == Keys.W)
            {
                Gl.Disable(OpenGL.GL_LIGHT0);
            }
            else if (keyData == Keys.A)
            {
                Gl.Enable(OpenGL.GL_LIGHT1);
            }
            else if (keyData == Keys.S)
            {
                Gl.Disable(OpenGL.GL_LIGHT1);
            }
            openGLControl.DoRender();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void показыватьОсиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            scene.ShowAxis = item.Checked;
            openGLControl.DoRender();
        }

        private void показыватьСеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            scene.ShowGrid = item.Checked;
            openGLControl.DoRender();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    cam++;
                }
                else if (e.Delta < 0)
                {
                    cam--;
                }
            }
            base.OnMouseWheel(e);
        }

        private void плоскаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            плоскаяToolStripMenuItem.Checked = true;
            плаваняToolStripMenuItem.Checked = false;
            openGLControl.OpenGL.ShadeModel(ShadeModel.Flat);
            openGLControl.DoRender();
        }

        private void плаваняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            плоскаяToolStripMenuItem.Checked = false;
            плаваняToolStripMenuItem.Checked = true;
            openGLControl.OpenGL.ShadeModel(ShadeModel.Smooth);
            openGLControl.DoRender();
        }

        private void логToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            richTextBoxLog.Visible = item.Checked;
        }

        private void PrintCurrentProjectionMatrix()
        {
            OpenGL gl = openGLControl.OpenGL;
            float[] matrix = new float[16];
            gl.GetFloat(GetTarget.ProjectionMatrix, matrix);
            double[] matrD = new double[16];
            for (int i = 0; i < matrix.Length; i++)
                matrD[i] = matrix[i];
            richTextBoxLog.AppendText(new Matrix(4, 4, matrD).ToString());
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
        }
    }
}

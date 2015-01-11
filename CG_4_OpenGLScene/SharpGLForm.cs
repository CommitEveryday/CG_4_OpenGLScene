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
using SharpGL.SceneGraph.Primitives;
using FileFormatWavefront;
using FileFormatWavefront.Model;
using System.Globalization;
using System.Threading;

namespace CG_4_OpenGLScene
{
    public partial class SharpGLForm : Form
    {
        Scene scene;
        bool changeAngleByMouse;
        Point prevMousePos;
        Camera camera;
        ColorF clearColor;

        public SharpGLForm()
        {
            InitializeComponent();
            //! в библиотеке FileFormatWavefront использутеся float.parse без указания CultureInfo
            //используется системный разделитель в вещественном числе, который в русской локале запятая
            //в obj файле разделителем является точка
            string theCultureString = "en-US";
            CultureInfo ci = new CultureInfo(theCultureString);
            Thread.CurrentThread.CurrentCulture = ci;
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

            InitSettings(gl);

            gl.CullFace(OpenGL.GL_BACK); //для верности. по умолчанию и так при включении удаления граней, удаляются задние поверхности

            gl.FrontFace(OpenGL.GL_CCW); //для верности. по умолчанию и так обход вершин против часовой для лицевых граней
            gl.Enable(OpenGL.GL_NORMALIZE); //нормализация нормалей (после масштабирования и не только)
            //нормализовать самому, масштабировать только на одинаковые коэффициенты по осям,
            //тогда можно использовать вместо GL_NORMALIZE - GL_RESCALE_NORMAL

            camera = new Camera();

            InitLight(gl);
        }

        private void InitSettings(OpenGL gl)
        {
            логToolStripMenuItem.Checked = true;
            richTextBoxLog.Visible = логToolStripMenuItem.Checked;

            плоскаяToolStripMenuItem.Checked = false;
            плаваняToolStripMenuItem.Checked = true;
            gl.ShadeModel(ShadeModel.Smooth);

            показыватьОсиToolStripMenuItem.Checked = true;
            scene.ShowAxis = показыватьОсиToolStripMenuItem.Checked;

            показыватьСеткуToolStripMenuItem.Checked = false;
            scene.ShowGrid = показыватьСеткуToolStripMenuItem.Checked;

            //colorDialogClear.Color = Color.FromArgb(255, 0, 0, 0);
            colorDialogClear.Color = Color.Black;
            clearColor = new ColorF(colorDialogClear.Color);
            gl.ClearColor(clearColor.r, clearColor.g, clearColor.b, clearColor.alpha);

            //контролирует сравнение по глубине и обновление буфера глубины
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            буферГлубиныToolStripMenuItem.Checked = true;

            gl.Disable(OpenGL.GL_LIGHTING);
            освещениеToolStripMenuItem.Checked = false;

            линейныйToolStripMenuItem.Checked = false;
            точечныйToolStripMenuItem.Checked = false;
            сплошнойToolStripMenuItem.Checked = true;
            openGLControl.OpenGL.PolygonMode(FaceMode.Front, PolygonMode.Filled);

            линейныйToolStripMenuItem1.Checked = true;
            точечныйToolStripMenuItem1.Checked = false;
            сплошнойToolStripMenuItem1.Checked = false;
            openGLControl.OpenGL.PolygonMode(FaceMode.Back, PolygonMode.Lines);

            gl.Disable(OpenGL.GL_CULL_FACE);
            удалятьНелицевыеГраниToolStripMenuItem.Checked = false;
            //TODO:
            //GL_BLEND (контролирует наложение RGBA величин)
            //Gl.glEnable(Gl.GL_BLEND);
        }

        private void InitLight(OpenGL gl)
        {
            float[] mat_specular = new float[]{1.0f,1.0f,1.0f,1.0f};
            float[]  mat_shininess = new float[]{50.0f};
            float[]  light_position = new float[]{10.0f,10.0f,10.0f,0.0f};
            float[]  white_light = new float[]{1.0f,1.0f,1.0f,1.0f};
            //gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SPECULAR, mat_specular);
            //gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, mat_shininess);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light_position);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, white_light);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, white_light);
            //gl.Enable(OpenGL.GL_LIGHTING);
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
            //gl.Viewport(0, 0, w, h); //SharpGP уже видимо настроил окно вывода на весь openGLControl

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
            camera.view(gl);
            //далее модельные
            scene.Draw(gl);

            ErrorHandler.TestError(gl, richTextBoxLog);
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
                camera.Rotate((prevMousePos.X - e.Location.X),
                    prevMousePos.Y - e.Location.Y);
                prevMousePos = e.Location;
                openGLControl.DoRender();
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            OpenGL Gl = openGLControl.OpenGL;
            if (keyData == Keys.Left || keyData == Keys.A)
            {
                camera.GoLeft();
            }
            else if (keyData == Keys.Right || keyData == Keys.D)
            {
                camera.GoRight();
            }
            else if (keyData == Keys.Up || keyData == Keys.W)
            {
                camera.GoForward();
            }
            else if (keyData == Keys.Down || keyData == Keys.S)
            {
                camera.GoBack();
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
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

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "OBJ|*.obj";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                scene.AddFigure(new FigureFromOBJ(new ColorF(Color.DarkOliveGreen), new Point3D(),
                    openDialog.FileName));
                openGLControl.DoRender();
                return;
                var result = FileFormatObj.Load(openDialog.FileName);
                //  Show each vertex.
                richTextBoxLog.AppendText(String.Format("Show each vertex.") + Environment.NewLine);
                foreach (Vertex v in result.Model.Vertices)
                {
                    richTextBoxLog.AppendText(String.Format("{0} {1} {2}", v.x, v.y, v.z) + Environment.NewLine);
                }

                richTextBoxLog.AppendText(String.Format("Groups") + Environment.NewLine);
                result.Model.Groups.ToList().ForEach(x => x.Faces.ToList().ForEach(f=>{string s = "";
                f.Indices.ToList().ForEach(i => s = s+i.vertex + " "); richTextBoxLog.AppendText(s + Environment.NewLine);
                }));

                richTextBoxLog.AppendText(String.Format("UngroupedFaces") + Environment.NewLine);
                result.Model.UngroupedFaces.ToList().ForEach(f =>
                {
                    string s = "";
                    f.Indices.ToList().ForEach(i => s = s + i.vertex + " "); richTextBoxLog.AppendText(s + Environment.NewLine);
                });
                result.Model.UngroupedFaces.ToList().ForEach(f =>
                    richTextBoxLog.AppendText(String.Join(", ", f.Indices) + Environment.NewLine));
                //  Show each message.
                richTextBoxLog.AppendText(String.Format("Show each message.") + Environment.NewLine);
                foreach (var message in result.Messages)
                {
                    richTextBoxLog.AppendText(String.Format("{0}: {1}", message.MessageType, message.Details) + Environment.NewLine);
                    richTextBoxLog.AppendText(String.Format("{0}: {1}", message.FileName, message.LineNumber) + Environment.NewLine);
                }
            }
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialogClear.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //MessageBox.Show("R:" + colorDialogClear.Color.R.ToString()
                //    +"G:" + colorDialogClear.Color.G.ToString()
                //    +"B:" + colorDialogClear.Color.B.ToString()
                //+ "A:" + colorDialogClear.Color.A.ToString());
                clearColor = new ColorF(colorDialogClear.Color);
                OpenGL gl = openGLControl.OpenGL;
                gl.ClearColor(clearColor.r, clearColor.g, clearColor.b, clearColor.alpha);
                openGLControl.DoRender();
            }
        }

        private void буферГлубиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            if (item.Checked)
                openGLControl.OpenGL.Enable(OpenGL.GL_DEPTH_TEST);
            else
                openGLControl.OpenGL.Disable(OpenGL.GL_DEPTH_TEST);
            openGLControl.DoRender();
        }

        private void включитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            if (item.Checked)
                openGLControl.OpenGL.Enable(OpenGL.GL_LIGHTING);
            else
                openGLControl.OpenGL.Disable(OpenGL.GL_LIGHTING);
            openGLControl.DoRender();
        }

        private void сплошнойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            линейныйToolStripMenuItem.Checked = false;
            точечныйToolStripMenuItem.Checked = false;
            сплошнойToolStripMenuItem.Checked = true;
            openGLControl.OpenGL.PolygonMode(FaceMode.Front, PolygonMode.Filled);
            openGLControl.DoRender();
        }

        private void линейныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            линейныйToolStripMenuItem.Checked = true;
            точечныйToolStripMenuItem.Checked = false;
            сплошнойToolStripMenuItem.Checked = false;
            openGLControl.OpenGL.PolygonMode(FaceMode.Front, PolygonMode.Lines);
            openGLControl.DoRender();
        }

        private void точечныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            линейныйToolStripMenuItem.Checked = false;
            точечныйToolStripMenuItem.Checked = true;
            сплошнойToolStripMenuItem.Checked = false;
            openGLControl.OpenGL.PolygonMode(FaceMode.Front, PolygonMode.Points);
            openGLControl.DoRender();
        }

        private void сплошнойToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            линейныйToolStripMenuItem1.Checked = false;
            точечныйToolStripMenuItem1.Checked = false;
            сплошнойToolStripMenuItem1.Checked = true;
            openGLControl.OpenGL.PolygonMode(FaceMode.Back, PolygonMode.Filled);
            openGLControl.DoRender();
        }

        private void линейныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            линейныйToolStripMenuItem1.Checked = true;
            точечныйToolStripMenuItem1.Checked = false;
            сплошнойToolStripMenuItem1.Checked = false;
            openGLControl.OpenGL.PolygonMode(FaceMode.Back, PolygonMode.Lines);
            openGLControl.DoRender();
        }

        private void точечныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            линейныйToolStripMenuItem1.Checked = false;
            точечныйToolStripMenuItem1.Checked = true;
            сплошнойToolStripMenuItem1.Checked = false;
            openGLControl.OpenGL.PolygonMode(FaceMode.Back, PolygonMode.Points);
            openGLControl.DoRender();
        }

        private void удалятьНелицевыеГраниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            if (item.Checked)
                openGLControl.OpenGL.Enable(OpenGL.GL_CULL_FACE);
            else
                openGLControl.OpenGL.Disable(OpenGL.GL_CULL_FACE);
            openGLControl.DoRender();
        }
    }
}

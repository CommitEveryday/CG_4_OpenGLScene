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
        double fovy = 60.0f; //угол обзора камеры
        FormPerspectiveAngle formPers;

        public SharpGLForm()
        {
            InitializeComponent();
            //! в библиотеке FileFormatWavefront использутеся float.parse без указания CultureInfo
            //используется системный разделитель в вещественном числе, который в русской локале запятая
            //в obj файле разделителем является точка
            string theCultureString = "en-US";
            CultureInfo ci = new CultureInfo(theCultureString);
            Thread.CurrentThread.CurrentCulture = ci;

            formPers = new FormPerspectiveAngle();
            formPers.trackBarAngle.ValueChanged += new EventHandler(trackBarAngle_ValueChanged);
        }

        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            scene = new Scene(gl);         

            InitSettings(gl);

            gl.CullFace(OpenGL.GL_BACK); //для верности. по умолчанию и так при включении удаления граней, удаляются задние поверхности

            gl.FrontFace(OpenGL.GL_CCW); //для верности. по умолчанию и так обход вершин против часовой для лицевых граней
            gl.Enable(OpenGL.GL_NORMALIZE); //нормализация нормалей (после масштабирования и не только)
            //нормализовать самому, масштабировать только на одинаковые коэффициенты по осям,
            //тогда можно использовать вместо GL_NORMALIZE - GL_RESCALE_NORMAL

            //согласование цветов материала
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.ColorMaterial(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT_AND_DIFFUSE);

            //TODO:
            //GL_BLEND (контролирует наложение RGBA величин)
            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            camera = new Camera();
        }

        private void InitSettings(OpenGL gl)
        {
            логToolStripMenuItem.Checked = false;
            richTextBoxLog.Visible = логToolStripMenuItem.Checked;

            плоскаяToolStripMenuItem.Checked = false;
            плаваняToolStripMenuItem.Checked = true;
            gl.ShadeModel(ShadeModel.Smooth);

            показыватьОсиToolStripMenuItem.Checked = false;
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

            gl.Enable(OpenGL.GL_CULL_FACE);
            удалятьНелицевыеГраниToolStripMenuItem.Checked = true;

            локальныйНаблюдательToolStripMenuItem.Checked = true;
            gl.LightModel(LightModelParameter.LocalViewer, 1);

            двустороннееОсвещениеToolStripMenuItem.Checked = false;
            gl.LightModel(LightModelParameter.TwoSide, 0);

            включитьИсточник0toolStripMenuItem.Checked = false;
            gl.Disable(OpenGL.GL_LIGHT0);

            включитьИсточник1ToolStripMenuItem.Checked = false;
            gl.Disable(OpenGL.GL_LIGHT1);

            включитьИсточник2ToolStripMenuItem.Checked = false;
            gl.Disable(OpenGL.GL_LIGHT2);

            timerMoveLight.Enabled = false;
            движениеИсточника0ToolStripMenuItem.Checked = false;
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
            gl.LoadIdentity();
            //  Create a perspective transformation.
            gl.Perspective(fovy, aspectRatio, 0.01, 100.0);

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
            //richTextBoxLog.AppendText("openGLControl_OpenGLDraw\r\n");
            //richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            //richTextBoxLog.ScrollToCaret();
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //видовые проеобразования (установка камеры)
            gl.MatrixMode(MatrixMode.Modelview);
            gl.LoadIdentity();
            camera.view(gl);

            //gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, new float[] {10,2,10,1});
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

        private void уголОбзораКамерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!formPers.Visible)
            {
                formPers.trackBarAngle.Value = (int)fovy;
                formPers.Show(this);
            }
        }

        void trackBarAngle_ValueChanged(object sender, EventArgs e)
        {
            fovy = formPers.trackBarAngle.Value;
            openGLControl_Resized(null, null);
            openGLControl.DoRender();
        }

        private void информацияОбИсточникеСвета0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LightInfo.GetInfo(openGLControl.OpenGL, OpenGL.GL_LIGHT0));
        }

        private void информацияОбИсточникеСвета1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LightInfo.GetInfo(openGLControl.OpenGL, OpenGL.GL_LIGHT1));
        }

        private void информацияОбИсточникеСвета2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LightInfo.GetInfo(openGLControl.OpenGL, OpenGL.GL_LIGHT2));
        }

        private void информацияОМоделиОсвещенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LightInfo.GetInfoLightModel(openGLControl.OpenGL));
        }

        private void фоновыйЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            float[] float4 = new float[4];
            gl.GetFloat(GetTarget.LightModelAmbient, float4);
            colorDialogAmbient.Color = Color.FromArgb((int)(float4[3] * 255),
                (int)(float4[0] * 255), (int)(float4[1] * 255), (int)(float4[2] * 255));
            if (colorDialogAmbient.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ColorF newAmbientColor = new ColorF(colorDialogAmbient.Color);
                gl.LightModel(LightModelParameter.Ambient, newAmbientColor.GetInArrWithAlpha());
                openGLControl.DoRender();
            }
        }

        private void локальныйНаблюдательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            if (item.Checked)
                openGLControl.OpenGL.LightModel(LightModelParameter.LocalViewer, 1);
            else
                openGLControl.OpenGL.LightModel(LightModelParameter.LocalViewer, 0);
            openGLControl.DoRender();
        }

        private void включитьИсточник1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            if (item.Checked)
                openGLControl.OpenGL.Enable(OpenGL.GL_LIGHT1);
            else
                openGLControl.OpenGL.Disable(OpenGL.GL_LIGHT1);
            openGLControl.DoRender();
        }

        private void включитьИсточник2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            if (item.Checked)
                openGLControl.OpenGL.Enable(OpenGL.GL_LIGHT2);
            else
                openGLControl.OpenGL.Disable(OpenGL.GL_LIGHT2);
            openGLControl.DoRender();
        }

        private void включитьИсточник0toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            if (item.Checked)
                openGLControl.OpenGL.Enable(OpenGL.GL_LIGHT0);
            else
                openGLControl.OpenGL.Disable(OpenGL.GL_LIGHT0);
            openGLControl.DoRender();
        }

        private void двустороннееОсвещениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            if (item.Checked)
                openGLControl.OpenGL.LightModel(LightModelParameter.TwoSide, 1);
            else
                openGLControl.OpenGL.LightModel(LightModelParameter.TwoSide, 0);
            openGLControl.DoRender();
        }

        private void timerMoveLight_Tick(object sender, EventArgs e)
        {
            scene.MoveLight();
            openGLControl.DoRender();
        }

        private void движениеИсточника0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
                return;
            item.Checked = !item.Checked;
            if (item.Checked)
                timerMoveLight.Enabled = true;
            else
                timerMoveLight.Enabled = false;
            openGLControl.DoRender();
        }
    }
}

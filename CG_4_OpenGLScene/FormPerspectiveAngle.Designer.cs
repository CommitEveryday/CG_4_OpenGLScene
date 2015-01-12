namespace CG_4_OpenGLScene
{
    partial class FormPerspectiveAngle
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCurAngle = new System.Windows.Forms.Label();
            this.trackBarAngle = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCurAngle
            // 
            this.labelCurAngle.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelCurAngle.Location = new System.Drawing.Point(0, 0);
            this.labelCurAngle.Name = "labelCurAngle";
            this.labelCurAngle.Size = new System.Drawing.Size(100, 44);
            this.labelCurAngle.TabIndex = 0;
            this.labelCurAngle.Text = "labelCurAngle";
            this.labelCurAngle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trackBarAngle
            // 
            this.trackBarAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarAngle.Location = new System.Drawing.Point(100, 0);
            this.trackBarAngle.Maximum = 180;
            this.trackBarAngle.Name = "trackBarAngle";
            this.trackBarAngle.Size = new System.Drawing.Size(336, 44);
            this.trackBarAngle.TabIndex = 1;
            this.trackBarAngle.TickFrequency = 10;
            this.trackBarAngle.ValueChanged += new System.EventHandler(this.trackBarAngle_ValueChanged);
            // 
            // FormPerspectiveAngle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 44);
            this.Controls.Add(this.trackBarAngle);
            this.Controls.Add(this.labelCurAngle);
            this.Name = "FormPerspectiveAngle";
            this.Text = "Угол охвата взора";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelCurAngle;
        public System.Windows.Forms.TrackBar trackBarAngle;
    }
}
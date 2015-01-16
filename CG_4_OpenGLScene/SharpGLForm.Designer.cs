namespace CG_4_OpenGLScene
{
    partial class SharpGLForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openGLControl = new SharpGL.OpenGLControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показыватьОсиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показыватьСеткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заливкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плаваняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.плоскаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветФонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.буферГлубиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимОтображенияЛицевыхГранейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сплошнойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линейныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.точечныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимОтображенияОбратныхГранейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сплошнойToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.линейныйToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.точечныйToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалятьНелицевыеГраниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уголОбзораКамерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.смещиваниеЦветовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.логToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.освещениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьИсточник0toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьИсточник1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьИсточник2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.движениеИсточника0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.диффузныйСветИсточника0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отладкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОбИсточникеСвета0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОбИсточникеСвета1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОбИсточникеСвета2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОМоделиОсвещенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.модельОсвещенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фоновыйЦветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.локальныйНаблюдательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.двустороннееОсвещениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зеркальноеОтражениеНаТекстурахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialogClear = new System.Windows.Forms.ColorDialog();
            this.colorDialogAmbient = new System.Windows.Forms.ColorDialog();
            this.timerMoveLight = new System.Windows.Forms.Timer(this.components);
            this.colorDialogLight0Diffuse = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl.DrawFPS = true;
            this.openGLControl.Location = new System.Drawing.Point(0, 24);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControl.Size = new System.Drawing.Size(624, 271);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыToolStripMenuItem,
            this.видToolStripMenuItem,
            this.файлToolStripMenuItem,
            this.освещениеToolStripMenuItem,
            this.отладкаToolStripMenuItem,
            this.модельОсвещенияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показыватьОсиToolStripMenuItem,
            this.показыватьСеткуToolStripMenuItem,
            this.заливкаToolStripMenuItem,
            this.цветФонаToolStripMenuItem,
            this.буферГлубиныToolStripMenuItem,
            this.режимОтображенияЛицевыхГранейToolStripMenuItem,
            this.режимОтображенияОбратныхГранейToolStripMenuItem,
            this.удалятьНелицевыеГраниToolStripMenuItem,
            this.уголОбзораКамерыToolStripMenuItem,
            this.смещиваниеЦветовToolStripMenuItem});
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // показыватьОсиToolStripMenuItem
            // 
            this.показыватьОсиToolStripMenuItem.Name = "показыватьОсиToolStripMenuItem";
            this.показыватьОсиToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.показыватьОсиToolStripMenuItem.Text = "Показывать оси";
            this.показыватьОсиToolStripMenuItem.Click += new System.EventHandler(this.показыватьОсиToolStripMenuItem_Click);
            // 
            // показыватьСеткуToolStripMenuItem
            // 
            this.показыватьСеткуToolStripMenuItem.Name = "показыватьСеткуToolStripMenuItem";
            this.показыватьСеткуToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.показыватьСеткуToolStripMenuItem.Text = "Показывать сетку";
            this.показыватьСеткуToolStripMenuItem.Click += new System.EventHandler(this.показыватьСеткуToolStripMenuItem_Click);
            // 
            // заливкаToolStripMenuItem
            // 
            this.заливкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.плаваняToolStripMenuItem,
            this.плоскаяToolStripMenuItem});
            this.заливкаToolStripMenuItem.Name = "заливкаToolStripMenuItem";
            this.заливкаToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.заливкаToolStripMenuItem.Text = "Заливка";
            // 
            // плаваняToolStripMenuItem
            // 
            this.плаваняToolStripMenuItem.Checked = true;
            this.плаваняToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.плаваняToolStripMenuItem.Name = "плаваняToolStripMenuItem";
            this.плаваняToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.плаваняToolStripMenuItem.Text = "Плавная";
            this.плаваняToolStripMenuItem.Click += new System.EventHandler(this.плаваняToolStripMenuItem_Click);
            // 
            // плоскаяToolStripMenuItem
            // 
            this.плоскаяToolStripMenuItem.Name = "плоскаяToolStripMenuItem";
            this.плоскаяToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.плоскаяToolStripMenuItem.Text = "Плоская";
            this.плоскаяToolStripMenuItem.Click += new System.EventHandler(this.плоскаяToolStripMenuItem_Click);
            // 
            // цветФонаToolStripMenuItem
            // 
            this.цветФонаToolStripMenuItem.Name = "цветФонаToolStripMenuItem";
            this.цветФонаToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.цветФонаToolStripMenuItem.Text = "Цвет фона...";
            this.цветФонаToolStripMenuItem.Click += new System.EventHandler(this.цветФонаToolStripMenuItem_Click);
            // 
            // буферГлубиныToolStripMenuItem
            // 
            this.буферГлубиныToolStripMenuItem.Name = "буферГлубиныToolStripMenuItem";
            this.буферГлубиныToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.буферГлубиныToolStripMenuItem.Text = "Буфер глубины";
            this.буферГлубиныToolStripMenuItem.Click += new System.EventHandler(this.буферГлубиныToolStripMenuItem_Click);
            // 
            // режимОтображенияЛицевыхГранейToolStripMenuItem
            // 
            this.режимОтображенияЛицевыхГранейToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сплошнойToolStripMenuItem,
            this.линейныйToolStripMenuItem,
            this.точечныйToolStripMenuItem});
            this.режимОтображенияЛицевыхГранейToolStripMenuItem.Name = "режимОтображенияЛицевыхГранейToolStripMenuItem";
            this.режимОтображенияЛицевыхГранейToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.режимОтображенияЛицевыхГранейToolStripMenuItem.Text = "Режим отображения лицевых граней";
            // 
            // сплошнойToolStripMenuItem
            // 
            this.сплошнойToolStripMenuItem.Name = "сплошнойToolStripMenuItem";
            this.сплошнойToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сплошнойToolStripMenuItem.Text = "Заполненный";
            this.сплошнойToolStripMenuItem.Click += new System.EventHandler(this.сплошнойToolStripMenuItem_Click);
            // 
            // линейныйToolStripMenuItem
            // 
            this.линейныйToolStripMenuItem.Name = "линейныйToolStripMenuItem";
            this.линейныйToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.линейныйToolStripMenuItem.Text = "Линейный";
            this.линейныйToolStripMenuItem.Click += new System.EventHandler(this.линейныйToolStripMenuItem_Click);
            // 
            // точечныйToolStripMenuItem
            // 
            this.точечныйToolStripMenuItem.Name = "точечныйToolStripMenuItem";
            this.точечныйToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.точечныйToolStripMenuItem.Text = "Точечный";
            this.точечныйToolStripMenuItem.Click += new System.EventHandler(this.точечныйToolStripMenuItem_Click);
            // 
            // режимОтображенияОбратныхГранейToolStripMenuItem
            // 
            this.режимОтображенияОбратныхГранейToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сплошнойToolStripMenuItem1,
            this.линейныйToolStripMenuItem1,
            this.точечныйToolStripMenuItem1});
            this.режимОтображенияОбратныхГранейToolStripMenuItem.Name = "режимОтображенияОбратныхГранейToolStripMenuItem";
            this.режимОтображенияОбратныхГранейToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.режимОтображенияОбратныхГранейToolStripMenuItem.Text = "Режим отображения обратных граней";
            // 
            // сплошнойToolStripMenuItem1
            // 
            this.сплошнойToolStripMenuItem1.Name = "сплошнойToolStripMenuItem1";
            this.сплошнойToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.сплошнойToolStripMenuItem1.Text = "Заполненный";
            this.сплошнойToolStripMenuItem1.Click += new System.EventHandler(this.сплошнойToolStripMenuItem1_Click);
            // 
            // линейныйToolStripMenuItem1
            // 
            this.линейныйToolStripMenuItem1.Name = "линейныйToolStripMenuItem1";
            this.линейныйToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.линейныйToolStripMenuItem1.Text = "Линейный";
            this.линейныйToolStripMenuItem1.Click += new System.EventHandler(this.линейныйToolStripMenuItem1_Click);
            // 
            // точечныйToolStripMenuItem1
            // 
            this.точечныйToolStripMenuItem1.Name = "точечныйToolStripMenuItem1";
            this.точечныйToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.точечныйToolStripMenuItem1.Text = "Точечный";
            this.точечныйToolStripMenuItem1.Click += new System.EventHandler(this.точечныйToolStripMenuItem1_Click);
            // 
            // удалятьНелицевыеГраниToolStripMenuItem
            // 
            this.удалятьНелицевыеГраниToolStripMenuItem.Name = "удалятьНелицевыеГраниToolStripMenuItem";
            this.удалятьНелицевыеГраниToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.удалятьНелицевыеГраниToolStripMenuItem.Text = "Удалять нелицевые грани";
            this.удалятьНелицевыеГраниToolStripMenuItem.Click += new System.EventHandler(this.удалятьНелицевыеГраниToolStripMenuItem_Click);
            // 
            // уголОбзораКамерыToolStripMenuItem
            // 
            this.уголОбзораКамерыToolStripMenuItem.Name = "уголОбзораКамерыToolStripMenuItem";
            this.уголОбзораКамерыToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.уголОбзораКамерыToolStripMenuItem.Text = "Угол обзора камеры...";
            this.уголОбзораКамерыToolStripMenuItem.Click += new System.EventHandler(this.уголОбзораКамерыToolStripMenuItem_Click);
            // 
            // смещиваниеЦветовToolStripMenuItem
            // 
            this.смещиваниеЦветовToolStripMenuItem.Name = "смещиваниеЦветовToolStripMenuItem";
            this.смещиваниеЦветовToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.смещиваниеЦветовToolStripMenuItem.Text = "Смещивание цветов";
            this.смещиваниеЦветовToolStripMenuItem.Click += new System.EventHandler(this.смещиваниеЦветовToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.логToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // логToolStripMenuItem
            // 
            this.логToolStripMenuItem.Checked = true;
            this.логToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.логToolStripMenuItem.Name = "логToolStripMenuItem";
            this.логToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.логToolStripMenuItem.Text = "Лог";
            this.логToolStripMenuItem.Click += new System.EventHandler(this.логToolStripMenuItem_Click);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // освещениеToolStripMenuItem
            // 
            this.освещениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьToolStripMenuItem,
            this.включитьИсточник0toolStripMenuItem,
            this.включитьИсточник1ToolStripMenuItem,
            this.включитьИсточник2ToolStripMenuItem,
            this.движениеИсточника0ToolStripMenuItem,
            this.диффузныйСветИсточника0ToolStripMenuItem});
            this.освещениеToolStripMenuItem.Name = "освещениеToolStripMenuItem";
            this.освещениеToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.освещениеToolStripMenuItem.Text = "Освещение";
            // 
            // включитьToolStripMenuItem
            // 
            this.включитьToolStripMenuItem.Name = "включитьToolStripMenuItem";
            this.включитьToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.включитьToolStripMenuItem.Text = "Включить";
            this.включитьToolStripMenuItem.Click += new System.EventHandler(this.включитьToolStripMenuItem_Click);
            // 
            // включитьИсточник0toolStripMenuItem
            // 
            this.включитьИсточник0toolStripMenuItem.Name = "включитьИсточник0toolStripMenuItem";
            this.включитьИсточник0toolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.включитьИсточник0toolStripMenuItem.Text = "Включить источник 0";
            this.включитьИсточник0toolStripMenuItem.Click += new System.EventHandler(this.включитьИсточник0toolStripMenuItem_Click);
            // 
            // включитьИсточник1ToolStripMenuItem
            // 
            this.включитьИсточник1ToolStripMenuItem.Name = "включитьИсточник1ToolStripMenuItem";
            this.включитьИсточник1ToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.включитьИсточник1ToolStripMenuItem.Text = "Включить источник 1";
            this.включитьИсточник1ToolStripMenuItem.Click += new System.EventHandler(this.включитьИсточник1ToolStripMenuItem_Click);
            // 
            // включитьИсточник2ToolStripMenuItem
            // 
            this.включитьИсточник2ToolStripMenuItem.Name = "включитьИсточник2ToolStripMenuItem";
            this.включитьИсточник2ToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.включитьИсточник2ToolStripMenuItem.Text = "Включить источник 2";
            this.включитьИсточник2ToolStripMenuItem.Click += new System.EventHandler(this.включитьИсточник2ToolStripMenuItem_Click);
            // 
            // движениеИсточника0ToolStripMenuItem
            // 
            this.движениеИсточника0ToolStripMenuItem.Name = "движениеИсточника0ToolStripMenuItem";
            this.движениеИсточника0ToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.движениеИсточника0ToolStripMenuItem.Text = "Движение источника 0";
            this.движениеИсточника0ToolStripMenuItem.Click += new System.EventHandler(this.движениеИсточника0ToolStripMenuItem_Click);
            // 
            // диффузныйСветИсточника0ToolStripMenuItem
            // 
            this.диффузныйСветИсточника0ToolStripMenuItem.Name = "диффузныйСветИсточника0ToolStripMenuItem";
            this.диффузныйСветИсточника0ToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.диффузныйСветИсточника0ToolStripMenuItem.Text = "Диффузный свет источника 0...";
            this.диффузныйСветИсточника0ToolStripMenuItem.Click += new System.EventHandler(this.диффузныйСветИсточника0ToolStripMenuItem_Click);
            // 
            // отладкаToolStripMenuItem
            // 
            this.отладкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.информацияОбИсточникеСвета0ToolStripMenuItem,
            this.информацияОбИсточникеСвета1ToolStripMenuItem,
            this.информацияОбИсточникеСвета2ToolStripMenuItem,
            this.информацияОМоделиОсвещенияToolStripMenuItem});
            this.отладкаToolStripMenuItem.Name = "отладкаToolStripMenuItem";
            this.отладкаToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.отладкаToolStripMenuItem.Text = "Отладка";
            // 
            // информацияОбИсточникеСвета0ToolStripMenuItem
            // 
            this.информацияОбИсточникеСвета0ToolStripMenuItem.Name = "информацияОбИсточникеСвета0ToolStripMenuItem";
            this.информацияОбИсточникеСвета0ToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.информацияОбИсточникеСвета0ToolStripMenuItem.Text = "Информация об источнике света 0...";
            this.информацияОбИсточникеСвета0ToolStripMenuItem.Click += new System.EventHandler(this.информацияОбИсточникеСвета0ToolStripMenuItem_Click);
            // 
            // информацияОбИсточникеСвета1ToolStripMenuItem
            // 
            this.информацияОбИсточникеСвета1ToolStripMenuItem.Name = "информацияОбИсточникеСвета1ToolStripMenuItem";
            this.информацияОбИсточникеСвета1ToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.информацияОбИсточникеСвета1ToolStripMenuItem.Text = "Информация об источнике света 1...";
            this.информацияОбИсточникеСвета1ToolStripMenuItem.Click += new System.EventHandler(this.информацияОбИсточникеСвета1ToolStripMenuItem_Click);
            // 
            // информацияОбИсточникеСвета2ToolStripMenuItem
            // 
            this.информацияОбИсточникеСвета2ToolStripMenuItem.Name = "информацияОбИсточникеСвета2ToolStripMenuItem";
            this.информацияОбИсточникеСвета2ToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.информацияОбИсточникеСвета2ToolStripMenuItem.Text = "Информация об источнике света 2...";
            this.информацияОбИсточникеСвета2ToolStripMenuItem.Click += new System.EventHandler(this.информацияОбИсточникеСвета2ToolStripMenuItem_Click);
            // 
            // информацияОМоделиОсвещенияToolStripMenuItem
            // 
            this.информацияОМоделиОсвещенияToolStripMenuItem.Name = "информацияОМоделиОсвещенияToolStripMenuItem";
            this.информацияОМоделиОсвещенияToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.информацияОМоделиОсвещенияToolStripMenuItem.Text = "Информация о модели освещения";
            this.информацияОМоделиОсвещенияToolStripMenuItem.Click += new System.EventHandler(this.информацияОМоделиОсвещенияToolStripMenuItem_Click);
            // 
            // модельОсвещенияToolStripMenuItem
            // 
            this.модельОсвещенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фоновыйЦветToolStripMenuItem,
            this.локальныйНаблюдательToolStripMenuItem,
            this.двустороннееОсвещениеToolStripMenuItem,
            this.зеркальноеОтражениеНаТекстурахToolStripMenuItem});
            this.модельОсвещенияToolStripMenuItem.Name = "модельОсвещенияToolStripMenuItem";
            this.модельОсвещенияToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.модельОсвещенияToolStripMenuItem.Text = "Модель освещения";
            // 
            // фоновыйЦветToolStripMenuItem
            // 
            this.фоновыйЦветToolStripMenuItem.Name = "фоновыйЦветToolStripMenuItem";
            this.фоновыйЦветToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.фоновыйЦветToolStripMenuItem.Text = "Фоновый свет...";
            this.фоновыйЦветToolStripMenuItem.Click += new System.EventHandler(this.фоновыйЦветToolStripMenuItem_Click);
            // 
            // локальныйНаблюдательToolStripMenuItem
            // 
            this.локальныйНаблюдательToolStripMenuItem.Name = "локальныйНаблюдательToolStripMenuItem";
            this.локальныйНаблюдательToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.локальныйНаблюдательToolStripMenuItem.Text = "Локальный наблюдатель";
            this.локальныйНаблюдательToolStripMenuItem.Click += new System.EventHandler(this.локальныйНаблюдательToolStripMenuItem_Click);
            // 
            // двустороннееОсвещениеToolStripMenuItem
            // 
            this.двустороннееОсвещениеToolStripMenuItem.Name = "двустороннееОсвещениеToolStripMenuItem";
            this.двустороннееОсвещениеToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.двустороннееОсвещениеToolStripMenuItem.Text = "Двустороннее освещение";
            this.двустороннееОсвещениеToolStripMenuItem.Click += new System.EventHandler(this.двустороннееОсвещениеToolStripMenuItem_Click);
            // 
            // зеркальноеОтражениеНаТекстурахToolStripMenuItem
            // 
            this.зеркальноеОтражениеНаТекстурахToolStripMenuItem.Name = "зеркальноеОтражениеНаТекстурахToolStripMenuItem";
            this.зеркальноеОтражениеНаТекстурахToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.зеркальноеОтражениеНаТекстурахToolStripMenuItem.Text = "Зеркальное отражение на текстурах";
            this.зеркальноеОтражениеНаТекстурахToolStripMenuItem.Click += new System.EventHandler(this.зеркальноеОтражениеНаТекстурахToolStripMenuItem_Click);
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.ContextMenuStrip = this.contextMenuStripLog;
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 295);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(624, 96);
            this.richTextBoxLog.TabIndex = 2;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.WordWrap = false;
            // 
            // contextMenuStripLog
            // 
            this.contextMenuStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem});
            this.contextMenuStripLog.Name = "contextMenuStripLog";
            this.contextMenuStripLog.ShowImageMargin = false;
            this.contextMenuStripLog.Size = new System.Drawing.Size(110, 26);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // colorDialogClear
            // 
            this.colorDialogClear.FullOpen = true;
            // 
            // colorDialogAmbient
            // 
            this.colorDialogAmbient.FullOpen = true;
            // 
            // timerMoveLight
            // 
            this.timerMoveLight.Interval = 200;
            this.timerMoveLight.Tick += new System.EventHandler(this.timerMoveLight_Tick);
            // 
            // colorDialogLight0Diffuse
            // 
            this.colorDialogLight0Diffuse.FullOpen = true;
            // 
            // SharpGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 391);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SharpGLForm";
            this.Text = "Компьютерная графика";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показыватьОсиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показыватьСеткуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заливкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плаваняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem плоскаяToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem логToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLog;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветФонаToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialogClear;
        private System.Windows.Forms.ToolStripMenuItem буферГлубиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem освещениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem включитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимОтображенияЛицевыхГранейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сплошнойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линейныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem точечныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимОтображенияОбратныхГранейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сплошнойToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem линейныйToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem точечныйToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалятьНелицевыеГраниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уголОбзораКамерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отладкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияОбИсточникеСвета0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияОбИсточникеСвета1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияОбИсточникеСвета2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияОМоделиОсвещенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem модельОсвещенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фоновыйЦветToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialogAmbient;
        private System.Windows.Forms.ToolStripMenuItem локальныйНаблюдательToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem включитьИсточник1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem включитьИсточник2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem включитьИсточник0toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem двустороннееОсвещениеToolStripMenuItem;
        private System.Windows.Forms.Timer timerMoveLight;
        private System.Windows.Forms.ToolStripMenuItem движениеИсточника0ToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialogLight0Diffuse;
        private System.Windows.Forms.ToolStripMenuItem диффузныйСветИсточника0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem смещиваниеЦветовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зеркальноеОтражениеНаТекстурахToolStripMenuItem;
    }
}


namespace AutoBackground
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonSetWallpaper = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonDownloadWallpapers = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.buttonChangeFolder = new System.Windows.Forms.Button();
            this.labelFolder = new System.Windows.Forms.Label();
            this.labelImageInfo = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonStartTimer = new System.Windows.Forms.Button();
            this.textBoxTimer = new System.Windows.Forms.TextBox();
            this.checkBoxDownloadOnRandom = new System.Windows.Forms.CheckBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRandomMulti = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxScreens = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSetWallpaper
            // 
            this.buttonSetWallpaper.Location = new System.Drawing.Point(10, 99);
            this.buttonSetWallpaper.Name = "buttonSetWallpaper";
            this.buttonSetWallpaper.Size = new System.Drawing.Size(93, 46);
            this.buttonSetWallpaper.TabIndex = 0;
            this.buttonSetWallpaper.Text = "Set Wallpaper";
            this.buttonSetWallpaper.UseVisualStyleBackColor = true;
            this.buttonSetWallpaper.Click += new System.EventHandler(this.buttonSetWallpaper_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonDownloadWallpapers
            // 
            this.buttonDownloadWallpapers.Location = new System.Drawing.Point(10, 41);
            this.buttonDownloadWallpapers.Name = "buttonDownloadWallpapers";
            this.buttonDownloadWallpapers.Size = new System.Drawing.Size(93, 23);
            this.buttonDownloadWallpapers.TabIndex = 1;
            this.buttonDownloadWallpapers.Text = "Download Wallpapers";
            this.buttonDownloadWallpapers.UseVisualStyleBackColor = true;
            this.buttonDownloadWallpapers.Click += new System.EventHandler(this.buttonDownloadWallpapers_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(9, 289);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 13);
            this.InfoLabel.TabIndex = 2;
            // 
            // buttonChangeFolder
            // 
            this.buttonChangeFolder.Location = new System.Drawing.Point(10, 12);
            this.buttonChangeFolder.Name = "buttonChangeFolder";
            this.buttonChangeFolder.Size = new System.Drawing.Size(93, 23);
            this.buttonChangeFolder.TabIndex = 3;
            this.buttonChangeFolder.Text = "Change Folder";
            this.buttonChangeFolder.UseVisualStyleBackColor = true;
            this.buttonChangeFolder.Click += new System.EventHandler(this.buttonChangeFolder_Click);
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(114, 15);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(0, 13);
            this.labelFolder.TabIndex = 4;
            // 
            // labelImageInfo
            // 
            this.labelImageInfo.AutoSize = true;
            this.labelImageInfo.Location = new System.Drawing.Point(10, 235);
            this.labelImageInfo.Name = "labelImageInfo";
            this.labelImageInfo.Size = new System.Drawing.Size(0, 13);
            this.labelImageInfo.TabIndex = 8;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(556, 15);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(0, 13);
            this.labelNumber.TabIndex = 9;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "WallManager";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonStartTimer
            // 
            this.buttonStartTimer.Location = new System.Drawing.Point(10, 551);
            this.buttonStartTimer.Name = "buttonStartTimer";
            this.buttonStartTimer.Size = new System.Drawing.Size(93, 37);
            this.buttonStartTimer.TabIndex = 11;
            this.buttonStartTimer.Text = "Start Timer";
            this.buttonStartTimer.UseVisualStyleBackColor = true;
            this.buttonStartTimer.Click += new System.EventHandler(this.buttonStartTimer_Click);
            // 
            // textBoxTimer
            // 
            this.textBoxTimer.Location = new System.Drawing.Point(10, 525);
            this.textBoxTimer.Name = "textBoxTimer";
            this.textBoxTimer.Size = new System.Drawing.Size(93, 20);
            this.textBoxTimer.TabIndex = 12;
            this.textBoxTimer.Text = "Time in Minutes";
            this.textBoxTimer.TextChanged += new System.EventHandler(this.textBoxTimer_TextChanged);
            // 
            // checkBoxDownloadOnRandom
            // 
            this.checkBoxDownloadOnRandom.AutoSize = true;
            this.checkBoxDownloadOnRandom.Location = new System.Drawing.Point(10, 489);
            this.checkBoxDownloadOnRandom.Name = "checkBoxDownloadOnRandom";
            this.checkBoxDownloadOnRandom.Size = new System.Drawing.Size(76, 30);
            this.checkBoxDownloadOnRandom.TabIndex = 13;
            this.checkBoxDownloadOnRandom.Text = "Download\r\non random";
            this.checkBoxDownloadOnRandom.UseVisualStyleBackColor = true;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(19, 444);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(0, 13);
            this.labelTimer.TabIndex = 14;
            this.labelTimer.Click += new System.EventHandler(this.labelTimer_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonRandomMulti
            // 
            this.buttonRandomMulti.Location = new System.Drawing.Point(10, 151);
            this.buttonRandomMulti.Name = "buttonRandomMulti";
            this.buttonRandomMulti.Size = new System.Drawing.Size(93, 49);
            this.buttonRandomMulti.TabIndex = 23;
            this.buttonRandomMulti.Text = "Random Wallpapers";
            this.buttonRandomMulti.UseVisualStyleBackColor = true;
            this.buttonRandomMulti.Click += new System.EventHandler(this.buttonRandomMulti_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Current Image";
            // 
            // comboBoxScreens
            // 
            this.comboBoxScreens.FormattingEnabled = true;
            this.comboBoxScreens.Location = new System.Drawing.Point(426, 10);
            this.comboBoxScreens.Name = "comboBoxScreens";
            this.comboBoxScreens.Size = new System.Drawing.Size(121, 21);
            this.comboBoxScreens.TabIndex = 28;
            this.comboBoxScreens.SelectedIndexChanged += new System.EventHandler(this.comboBoxScreens_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 473);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Random Timer";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(117, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(825, 550);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(10, 263);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(93, 23);
            this.buttonDelete.TabIndex = 31;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 602);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxScreens);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonRandomMulti);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.labelImageInfo);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.checkBoxDownloadOnRandom);
            this.Controls.Add(this.buttonChangeFolder);
            this.Controls.Add(this.textBoxTimer);
            this.Controls.Add(this.buttonStartTimer);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonSetWallpaper);
            this.Controls.Add(this.buttonDownloadWallpapers);
            this.Controls.Add(this.InfoLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSetWallpaper;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonDownloadWallpapers;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Button buttonChangeFolder;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.Label labelImageInfo;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonStartTimer;
        private System.Windows.Forms.TextBox textBoxTimer;
        private System.Windows.Forms.CheckBox checkBoxDownloadOnRandom;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonRandomMulti;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxScreens;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonDelete;
    }
}


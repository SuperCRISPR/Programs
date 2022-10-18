namespace 大作业
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.check = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Label();
            this.LoadingTip = new System.Windows.Forms.Label();
            this.TextshowingTimer = new System.Windows.Forms.Timer(this.components);
            this.BarTimerMa = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LimitingTimer = new System.Windows.Forms.Timer(this.components);
            this.TimetipMa = new System.Windows.Forms.Label();
            this.BarHPofMa = new System.Windows.Forms.ProgressBar();
            this.BarHPofDa = new System.Windows.Forms.ProgressBar();
            this.BarTimerDa = new System.Windows.Forms.Timer(this.components);
            this.HPofMaLabel = new System.Windows.Forms.Label();
            this.HPofDaLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TimetipDa = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.存档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.悔棋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.投降ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.游戏规则ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoTrueButton = new System.Windows.Forms.RadioButton();
            this.AutoFalseButton = new System.Windows.Forms.RadioButton();
            this.AutoCheck = new System.Windows.Forms.Timer(this.components);
            this.BGMplayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.ReshowTimer = new System.Windows.Forms.Timer(this.components);
            this.boardcheck = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BGMplayer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1397, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "最后落子：";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1397, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "已有棋子：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1397, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "下一手为";
            // 
            // check
            // 
            this.check.AutoSize = true;
            this.check.Location = new System.Drawing.Point(1401, 147);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(15, 15);
            this.check.TabIndex = 3;
            this.check.Text = "0";
            this.check.Visible = false;
            // 
            // Back
            // 
            this.Back.AutoSize = true;
            this.Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back.Font = new System.Drawing.Font("华光准圆_CNKI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Back.ForeColor = System.Drawing.Color.Red;
            this.Back.Location = new System.Drawing.Point(19, 38);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(74, 23);
            this.Back.TabIndex = 4;
            this.Back.Text = "<<主页";
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // LoadingTip
            // 
            this.LoadingTip.AutoSize = true;
            this.LoadingTip.Font = new System.Drawing.Font("华光准圆_CNKI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoadingTip.ForeColor = System.Drawing.Color.Lime;
            this.LoadingTip.Location = new System.Drawing.Point(521, 38);
            this.LoadingTip.Name = "LoadingTip";
            this.LoadingTip.Size = new System.Drawing.Size(136, 23);
            this.LoadingTip.TabIndex = 5;
            this.LoadingTip.Text = "存档读取成功";
            // 
            // TextshowingTimer
            // 
            this.TextshowingTimer.Tick += new System.EventHandler(this.TextshowingTimer_Tick);
            // 
            // BarTimerMa
            // 
            this.BarTimerMa.Tick += new System.EventHandler(this.BarTimerMa_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(321, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(631, 582);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1401, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "1234567";
            // 
            // LimitingTimer
            // 
            this.LimitingTimer.Interval = 1000;
            this.LimitingTimer.Tick += new System.EventHandler(this.LimitingTimer_Tick);
            // 
            // TimetipMa
            // 
            this.TimetipMa.AutoSize = true;
            this.TimetipMa.Font = new System.Drawing.Font("华光准圆_CNKI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimetipMa.ForeColor = System.Drawing.Color.Red;
            this.TimetipMa.Location = new System.Drawing.Point(1047, 44);
            this.TimetipMa.Name = "TimetipMa";
            this.TimetipMa.Size = new System.Drawing.Size(61, 28);
            this.TimetipMa.TabIndex = 8;
            this.TimetipMa.Text = "       ";
            // 
            // BarHPofMa
            // 
            this.BarHPofMa.BackColor = System.Drawing.SystemColors.Control;
            this.BarHPofMa.Location = new System.Drawing.Point(958, 75);
            this.BarHPofMa.Name = "BarHPofMa";
            this.BarHPofMa.Size = new System.Drawing.Size(302, 23);
            this.BarHPofMa.TabIndex = 9;
            // 
            // BarHPofDa
            // 
            this.BarHPofDa.Location = new System.Drawing.Point(13, 75);
            this.BarHPofDa.Name = "BarHPofDa";
            this.BarHPofDa.Size = new System.Drawing.Size(307, 23);
            this.BarHPofDa.TabIndex = 10;
            // 
            // BarTimerDa
            // 
            this.BarTimerDa.Tick += new System.EventHandler(this.BarTimerDa_Tick);
            // 
            // HPofMaLabel
            // 
            this.HPofMaLabel.AutoSize = true;
            this.HPofMaLabel.Font = new System.Drawing.Font("华光准圆_CNKI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HPofMaLabel.ForeColor = System.Drawing.Color.Red;
            this.HPofMaLabel.Location = new System.Drawing.Point(954, 49);
            this.HPofMaLabel.Name = "HPofMaLabel";
            this.HPofMaLabel.Size = new System.Drawing.Size(28, 23);
            this.HPofMaLabel.TabIndex = 11;
            this.HPofMaLabel.Text = "   ";
            // 
            // HPofDaLabel
            // 
            this.HPofDaLabel.AutoSize = true;
            this.HPofDaLabel.Font = new System.Drawing.Font("华光准圆_CNKI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HPofDaLabel.ForeColor = System.Drawing.Color.Red;
            this.HPofDaLabel.Location = new System.Drawing.Point(292, 49);
            this.HPofDaLabel.Name = "HPofDaLabel";
            this.HPofDaLabel.Size = new System.Drawing.Size(28, 23);
            this.HPofDaLabel.TabIndex = 12;
            this.HPofDaLabel.Text = "   ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(958, 104);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(302, 512);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(13, 104);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(307, 512);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("华光综艺_CNKI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 619);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 44);
            this.label5.TabIndex = 15;
            this.label5.Text = "英国大力士";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("华光综艺_CNKI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(974, 619);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(286, 44);
            this.label6.TabIndex = 16;
            this.label6.Text = "浑元形意掌门人";
            // 
            // TimetipDa
            // 
            this.TimetipDa.AutoSize = true;
            this.TimetipDa.Font = new System.Drawing.Font("华光准圆_CNKI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimetipDa.ForeColor = System.Drawing.Color.Red;
            this.TimetipDa.Location = new System.Drawing.Point(131, 44);
            this.TimetipDa.Name = "TimetipDa";
            this.TimetipDa.Size = new System.Drawing.Size(61, 28);
            this.TimetipDa.TabIndex = 17;
            this.TimetipDa.Text = "       ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1273, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.存档ToolStripMenuItem,
            this.悔棋ToolStripMenuItem,
            this.投降ToolStripMenuItem,
            this.复盘ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.游戏ToolStripMenuItem.Text = "对战";
            // 
            // 存档ToolStripMenuItem
            // 
            this.存档ToolStripMenuItem.Name = "存档ToolStripMenuItem";
            this.存档ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.存档ToolStripMenuItem.Text = "休战";
            this.存档ToolStripMenuItem.Click += new System.EventHandler(this.存档ToolStripMenuItem_Click);
            // 
            // 悔棋ToolStripMenuItem
            // 
            this.悔棋ToolStripMenuItem.Name = "悔棋ToolStripMenuItem";
            this.悔棋ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.悔棋ToolStripMenuItem.Text = "偷袭";
            this.悔棋ToolStripMenuItem.Click += new System.EventHandler(this.悔棋ToolStripMenuItem_Click);
            // 
            // 投降ToolStripMenuItem
            // 
            this.投降ToolStripMenuItem.Name = "投降ToolStripMenuItem";
            this.投降ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.投降ToolStripMenuItem.Text = "投降";
            this.投降ToolStripMenuItem.Click += new System.EventHandler(this.投降ToolStripMenuItem_Click);
            // 
            // 复盘ToolStripMenuItem
            // 
            this.复盘ToolStripMenuItem.Name = "复盘ToolStripMenuItem";
            this.复盘ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.复盘ToolStripMenuItem.Text = "反思";
            this.复盘ToolStripMenuItem.Click += new System.EventHandler(this.复盘ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏规则ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 游戏规则ToolStripMenuItem
            // 
            this.游戏规则ToolStripMenuItem.Name = "游戏规则ToolStripMenuItem";
            this.游戏规则ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.游戏规则ToolStripMenuItem.Text = "游戏规则";
            this.游戏规则ToolStripMenuItem.Click += new System.EventHandler(this.游戏规则ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // AutoTrueButton
            // 
            this.AutoTrueButton.AutoSize = true;
            this.AutoTrueButton.Font = new System.Drawing.Font("华光准圆_CNKI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AutoTrueButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.AutoTrueButton.Location = new System.Drawing.Point(841, 44);
            this.AutoTrueButton.Name = "AutoTrueButton";
            this.AutoTrueButton.Size = new System.Drawing.Size(111, 27);
            this.AutoTrueButton.TabIndex = 19;
            this.AutoTrueButton.TabStop = true;
            this.AutoTrueButton.Text = "原力操控";
            this.AutoTrueButton.UseVisualStyleBackColor = true;
            this.AutoTrueButton.CheckedChanged += new System.EventHandler(this.AutoTrueButton_CheckedChanged);
            // 
            // AutoFalseButton
            // 
            this.AutoFalseButton.AutoSize = true;
            this.AutoFalseButton.Font = new System.Drawing.Font("华光准圆_CNKI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AutoFalseButton.ForeColor = System.Drawing.Color.Green;
            this.AutoFalseButton.Location = new System.Drawing.Point(718, 44);
            this.AutoFalseButton.Name = "AutoFalseButton";
            this.AutoFalseButton.Size = new System.Drawing.Size(111, 27);
            this.AutoFalseButton.TabIndex = 20;
            this.AutoFalseButton.TabStop = true;
            this.AutoFalseButton.Text = "本尊降临";
            this.AutoFalseButton.UseVisualStyleBackColor = true;
            // 
            // AutoCheck
            // 
            this.AutoCheck.Enabled = true;
            this.AutoCheck.Interval = 10;
            this.AutoCheck.Tick += new System.EventHandler(this.AutoCheck_Tick);
            // 
            // BGMplayer
            // 
            this.BGMplayer.Enabled = true;
            this.BGMplayer.Location = new System.Drawing.Point(1311, 165);
            this.BGMplayer.Name = "BGMplayer";
            this.BGMplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("BGMplayer.OcxState")));
            this.BGMplayer.Size = new System.Drawing.Size(212, 183);
            this.BGMplayer.TabIndex = 21;
            this.BGMplayer.Visible = false;
            // 
            // ReshowTimer
            // 
            this.ReshowTimer.Interval = 800;
            this.ReshowTimer.Tick += new System.EventHandler(this.ReshowTimer_Tick);
            // 
            // boardcheck
            // 
            this.boardcheck.AutoSize = true;
            this.boardcheck.Location = new System.Drawing.Point(1311, 383);
            this.boardcheck.Name = "boardcheck";
            this.boardcheck.Size = new System.Drawing.Size(55, 15);
            this.boardcheck.TabIndex = 22;
            this.boardcheck.Text = "label7";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1273, 691);
            this.Controls.Add(this.boardcheck);
            this.Controls.Add(this.BGMplayer);
            this.Controls.Add(this.AutoFalseButton);
            this.Controls.Add(this.AutoTrueButton);
            this.Controls.Add(this.TimetipDa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HPofDaLabel);
            this.Controls.Add(this.HPofMaLabel);
            this.Controls.Add(this.BarHPofDa);
            this.Controls.Add(this.BarHPofMa);
            this.Controls.Add(this.TimetipMa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoadingTip);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.check);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "浑元形意五子棋";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BGMplayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label check;
        private System.Windows.Forms.Label Back;
        private System.Windows.Forms.Label LoadingTip;
        private System.Windows.Forms.Timer TextshowingTimer;
        private System.Windows.Forms.Timer BarTimerMa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer LimitingTimer;
        private System.Windows.Forms.Label TimetipMa;
        private System.Windows.Forms.ProgressBar BarHPofMa;
        private System.Windows.Forms.ProgressBar BarHPofDa;
        private System.Windows.Forms.Timer BarTimerDa;
        private System.Windows.Forms.Label HPofMaLabel;
        private System.Windows.Forms.Label HPofDaLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label TimetipDa;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 存档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 悔棋ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 投降ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 游戏规则ToolStripMenuItem;
        private System.Windows.Forms.RadioButton AutoTrueButton;
        private System.Windows.Forms.RadioButton AutoFalseButton;
        private System.Windows.Forms.Timer AutoCheck;
        private AxWMPLib.AxWindowsMediaPlayer BGMplayer;
        private System.Windows.Forms.ToolStripMenuItem 复盘ToolStripMenuItem;
        private System.Windows.Forms.Timer ReshowTimer;
        private System.Windows.Forms.Label boardcheck;
    }
}
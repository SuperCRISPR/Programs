namespace 大作业
{
    partial class Story
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Story));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Label();
            this.Skip = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Label();
            this.XfilePlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.Suprise = new System.Windows.Forms.PictureBox();
            this.Elec = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.XfilePlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Suprise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Elec)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华光魏体_CNKI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(107, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 0;
            // 
            // Start
            // 
            this.Start.AutoSize = true;
            this.Start.BackColor = System.Drawing.Color.Black;
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.Font = new System.Drawing.Font("华光魏体_CNKI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start.Location = new System.Drawing.Point(600, 444);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(143, 45);
            this.Start.TabIndex = 1;
            this.Start.Text = "迎战！";
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Skip
            // 
            this.Skip.AutoSize = true;
            this.Skip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Skip.Font = new System.Drawing.Font("华光准圆_CNKI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Skip.Location = new System.Drawing.Point(1275, 5);
            this.Skip.Name = "Skip";
            this.Skip.Size = new System.Drawing.Size(74, 23);
            this.Skip.TabIndex = 2;
            this.Skip.Text = "跳过>>";
            this.Skip.Click += new System.EventHandler(this.Skip_Click);
            // 
            // Back
            // 
            this.Back.AutoSize = true;
            this.Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back.Font = new System.Drawing.Font("华光准圆_CNKI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Back.Location = new System.Drawing.Point(12, 5);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(74, 23);
            this.Back.TabIndex = 3;
            this.Back.Text = "<<返回";
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // XfilePlayer
            // 
            this.XfilePlayer.Enabled = true;
            this.XfilePlayer.Location = new System.Drawing.Point(1129, 478);
            this.XfilePlayer.Name = "XfilePlayer";
            this.XfilePlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("XfilePlayer.OcxState")));
            this.XfilePlayer.Size = new System.Drawing.Size(75, 23);
            this.XfilePlayer.TabIndex = 4;
            this.XfilePlayer.Visible = false;
            // 
            // Suprise
            // 
            this.Suprise.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Suprise.BackgroundImage")));
            this.Suprise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Suprise.Location = new System.Drawing.Point(375, 5);
            this.Suprise.Name = "Suprise";
            this.Suprise.Size = new System.Drawing.Size(498, 496);
            this.Suprise.TabIndex = 5;
            this.Suprise.TabStop = false;
            this.Suprise.Visible = false;
            // 
            // Elec
            // 
            this.Elec.Enabled = true;
            this.Elec.Location = new System.Drawing.Point(1210, 478);
            this.Elec.Name = "Elec";
            this.Elec.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Elec.OcxState")));
            this.Elec.Size = new System.Drawing.Size(75, 23);
            this.Elec.TabIndex = 6;
            this.Elec.Visible = false;
            // 
            // Story
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1361, 539);
            this.Controls.Add(this.Elec);
            this.Controls.Add(this.Suprise);
            this.Controls.Add(this.XfilePlayer);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Skip);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Story";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.XfilePlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Suprise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Elec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Start;
        private System.Windows.Forms.Label Skip;
        private System.Windows.Forms.Label Back;
        private AxWMPLib.AxWindowsMediaPlayer XfilePlayer;
        private System.Windows.Forms.PictureBox Suprise;
        private AxWMPLib.AxWindowsMediaPlayer Elec;
    }
}
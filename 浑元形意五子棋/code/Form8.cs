using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 大作业
{
    public partial class MalaoshiWin : Form
    {
        public MalaoshiWin()
        {
            InitializeComponent();
            Video.URL = "马马保马.mp4";
            Video.settings.setMode("loop", true);
            Video.Ctlcontrols.play();
            //this.Size = new Size(1129, 521);
        }
        
        private void MalaoshiWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

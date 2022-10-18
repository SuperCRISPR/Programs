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
    public partial class DalishiWin : Form
    {
        public DalishiWin()
        {
            InitializeComponent();
            Video.URL = "穷开鞭.mp4";
            Video.settings.setMode("loop", true);
            Video.Ctlcontrols.play();
            //this.Size = new Size(1351, 576);
        }
        
        private void DalishiWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

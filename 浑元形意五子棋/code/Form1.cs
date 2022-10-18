using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

namespace 大作业
{
    public partial class Homepage : Form
    {
        SoundPlayer shandianbian;
        void ShowForm2()
        {
            Story form2 = new Story();
            form2.Show();
            Hide();
            Start.Enabled = false;
            Stopshandianbian();
        }
        void LoadGame()
        {
            bool dataexist;
            StreamReader check = new StreamReader("saveddata.txt");
            dataexist = (check.Peek() == '%');
            if (dataexist == true)
            {
                Game game = new Game();
                game.Show();
                game.LoadData();
                Hide();
                Stopshandianbian();
            }
            else
            {
                MessageBox.Show("马老师不见了！");
            }
            check.Close();
        }
        public Homepage()
        {
            InitializeComponent();
            shandianbian = new SoundPlayer();
            Playshandianbian();
        }
        private void Start_Click(object sender, EventArgs e)
        {
            StreamReader check = new StreamReader("saveddata.txt");
            if (check.Peek() == '%')
            {
                DialogResult result = MessageBox.Show("已经有马老师在比武，是否覆盖原先的马老师并创造新的马老师", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    check.Close();
                    ShowForm2();
                    StreamWriter newgame = new StreamWriter("saveddata.txt",false);
                    newgame.WriteLine("New"+DateTime.Now.ToString());
                    newgame.Close();
                }
                else
                {
                    check.Close();
                }
            }
            else
            {
                check.Close();
                ShowForm2();
            }
            check.Close();
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            Stopshandianbian();
            LoadGame();
        }
        public void Playshandianbian()
        {
            shandianbian.SoundLocation = "闪电鞭.wav";
            shandianbian.Load();
            shandianbian.PlayLooping();
        }
        public void Stopshandianbian()
        {
            shandianbian.Stop();
        }
    }
}

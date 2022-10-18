using System;
using System.Media;
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
    public partial class Story : Form
    {
        int time=0;
        string story;
        Random r = new Random();
        char[] words;
        public Story()
        {
            InitializeComponent();
            Createstory();
            timer1.Start();
            time = 0;
            Start.Enabled=Start.Visible= false;
            Skip.Enabled=Skip.Visible= true;
            Back.Enabled=Back.Visible= false;
            Playxfile();
            Suprise.Visible = false;
        }
        
        void Createstory()
        {
            story= "大家好，我是浑元形意太极门掌门人马保国。     \r\n刚才有个朋友问我：马老师发生肾么事了     \r\n";
            story+= "我说怎么回事，给我发了几张截图，我一看，        \r\n嗷~     \r\n原来是昨天，有两个年轻人，三四来岁，一个体重，九十多公斤，一个体重八十多公斤     \r\n";
            story += "他说，马老师我在图书馆偷学把脑子学坏了，你能不能教一教我混元五子棋法帮助治疗一下我的脑病      \r\n";
            story += "我说你在图书馆卷死劲，不好用    \r\n他不服气，非要和我试试     \r\n我说可以    \r\n我一说他啪就站起来了，很快啊     ";
            words = story.ToCharArray();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            timer1.Interval = r.Next(60,250);
            if (time > 5 && time < words.Count()+6)
            {
                label1.Text = label1.Text + words[time - 6];
            }
            else if(time>= words.Count() + 6)
            {
                Start.Enabled =Start.Visible = true;
                Back.Enabled =Back.Visible = true;
                Skip.Enabled =Skip.Visible = false;
                timer1.Stop();
            }
            if(time==109||time==111||time==27||time==28||time==183||time==185||time==60||time==62||time==63||time==79||time==82||time==200||time==205)
            {
                Suprise.Visible = true;
                Elec.Ctlcontrols.play();
            }
            else
            {
                Suprise.Visible = false;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Show();
            timer1.Stop();
            XfilePlayer.Ctlcontrols.stop();
            Elec.Ctlcontrols.stop();
            Close();
        }

        private void Skip_Click(object sender, EventArgs e)
        {
            time = words.Count() + 6;
            label1.Text = story;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            new Homepage().Show();
            timer1.Stop();
            XfilePlayer.Ctlcontrols.stop();
            Elec.Ctlcontrols.stop();
            Close();
        }
        void Playxfile()
        {
            XfilePlayer.URL = "X file.wav";
            XfilePlayer.Ctlcontrols.play();
            XfilePlayer.settings.setMode("loop",true);
        }
    }
}

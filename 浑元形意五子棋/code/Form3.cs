using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 大作业
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            LoadingTip.Enabled = false;
            LoadingTip.Visible = false;
            for(int i1=0; i1<15; i1++)
            {
                for(int i2=0;i2<15;i2++)
                {
                    board[i1,i2] = 0;
                }
            }//初始化board
            LimitingTimer.Stop();
            BarHPofDa.Value = Convert.ToInt32(HPofDalishi * BarHPofDa.Maximum);
            BarHPofMa.Value = Convert.ToInt32(HPofMa * BarHPofDa.Maximum);
            HPofMaLabel.Visible = false;
            HPofDaLabel.Visible = false;
            AutoTrueButton.Checked = false;
            AutoFalseButton.Checked = true;
            AutoCheck.Start();
            BGMplayer.URL = "BGM.wav";
            BGMplayer.settings.setMode("loop",true);
            BGMplayer.Ctlcontrols.play();
        }
        /*初始化值*/
        List<Check> points = new List<Check>(1000);//不是实际坐标，表示在棋盘交点的坐标
        List<Point> Blackpoints = new List<Point>(1000);
        List<Point> Whitepoints = new List<Point>(1000);
        List<int[,]> Boardstate = new List<int[,]>();//存储棋盘状态,每个元素为一张棋盘
        int[,] board = new int[15,15];
        int ColorisBlack = 1;//当前下一个棋子颜色,1=black,-1=white
        float HPofMa = 1;//马老师生命值百分比
        float HPofDalishi = 1;//大力士生命值百分比
        bool ModeisAuto = false;
        int textshowingtime = 0;
        bool isexist = false;
        int limitingtime = 0;
        int bartime = 0;
        int autotime=0;
        bool isreshow=false;
        int reshowtime = 0;
        /**********/
        /*参数设定*/
        int unit = 25;//网格间距
        int top = 58;//顶间距
        int side = 64;//侧间距
        int rsize = 10;//棋子半径
        float timeoverpunishment=0.01175f;
        /**********/
        public bool LoadData()//载入存档，在父窗口中调用
        {
            TextshowingTimer.Start();
            textshowingtime = 0;
            StreamReader load = new StreamReader("saveddata.txt");
            if (load.Peek() == '%')
            {
                load.ReadLine();
                string[] cHPofMa = load.ReadLine().Split('%');
                HPofMa = Convert.ToSingle(cHPofMa[1]);
                BarHPofMa.Value = Convert.ToInt32(HPofMa * BarHPofMa.Maximum);
                string[] cHPofDalishi = load.ReadLine().Split('%');
                HPofDalishi = Convert.ToSingle(cHPofDalishi[1]);
                BarHPofDa.Value = Convert.ToInt32(HPofDalishi * BarHPofDa.Maximum);
                string[] cColor = load.ReadLine().Split('%');
                ColorisBlack = Convert.ToInt32(cColor[1]);
                string[] cCount = load.ReadLine().Split('%');
                int count= Convert.ToInt32(cCount[1]);
                load.ReadLine();
                load.ReadLine();
                points.Clear();
                for(int i = 0; i < count; i++)
                {
                    string[] ccheck=load.ReadLine().Split(',');
                    points.Add(new Check(Convert.ToInt32 (ccheck[0]), Convert.ToInt32(ccheck[1]), Convert.ToInt32(ccheck[2])));
                }
                Divide();
                StoreinBoard();
                pictureBox1.Invalidate();
                load.Close();
                return true;
            }
            else
            {
                load.Close();
                return false;
            }
        }
        public void Save()
        {
            StreamWriter save = new StreamWriter("saveddata.txt",false);
            save.WriteLine("%"+DateTime.Now.ToString());
            save.WriteLine("HPofMa%"+HPofMa.ToString()+"%time"+DateTime.Now.ToString());
            save.WriteLine("HPofDalishi%" + HPofDalishi.ToString() + "%time" + DateTime.Now.ToString());
            save.WriteLine("Color%" + ColorisBlack.ToString() + "%time" + DateTime.Now.ToString());
            save.WriteLine("points.Count%" + points.Count + "%time" + DateTime.Now.ToString());
            save.WriteLine("points");
            save.WriteLine("%%%");
            for (int i = 0; i < points.Count; i++)
            {
                save.WriteLine("{0},{1},{2}", points[i].X, points[i].Y, points[i].C);
            }
            save.WriteLine("%%%" + "time" + DateTime.Now.ToString());
            save.Close();
        }
        void Divide()//将棋子储存为黑棋与白棋两组数据
        {
            Blackpoints.Clear();
            Whitepoints.Clear();
            if(points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i].C==1)//black
                    {
                        Blackpoints.Add(new Point(points[i].X,points[i].Y));
                    }
                    else
                    {
                        Whitepoints.Add(new Point(points[i].X, points[i].Y));
                    }
                }
            }
            else { }
        }
        void StoreinBoard()//将棋子数组储存到棋盘数组，0为无棋子，1为黑棋，-1为白棋，索引值为（x，y）
        {
            Boardstate.Add(new int[15,15]);
            for (int x=0;x<15;x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    Boardstate[Boardstate.Count-1][x, y] = 0;
                }
            }
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].C==1)
                {
                    Boardstate[Boardstate.Count - 1][points[i].X, points[i].Y] = 1;
                }
                else if(points[i].C==-1)
                {
                    Boardstate[Boardstate.Count - 1][points[i].X, points[i].Y] = -1;
                }
                else
                {
                    Boardstate[Boardstate.Count - 1][points[i].X, points[i].Y] = 0;
                }
            }
            Checkboard(Boardstate.Count -1);
            board = Boardstate[Boardstate.Count - 1];
        }
        void IsWin(Check p)//检查p点处同花色相连棋子数并判断后扣血；c为最后落子颜色，p为最后落子坐标
        {
            int WE=0;//横向同色连子数
            int NS=0;//纵向同色连子数
            int WN=0;//正斜向同色连子数
            int ES=0;//反斜向同色连子数
            //横向
            for (int i = 0; p.X - i >= 0; i++) 
            {
                if(board[p.X -i,p.Y] == p.C)
                {
                    WE++;
                }
                else
                {
                    break;
                }
            }//计入自身
            for (int i = -1; p.X - i <= 14; i--)
            {
                if (board[p.X - i, p.Y] == p.C)
                {
                    WE++;
                }
                else
                {
                    break;
                }
            }//不计入自身
            //纵向
            for (int i = 0; p.Y - i >= 0; i++)
            {
                if (board[p.X, p.Y-i] == p.C)
                {
                    NS++;
                }
                else
                {
                    break;
                }
            }//计入自身
            for (int i = -1; p.Y - i <= 14; i--)
            {
                if (board[p.X, p.Y - i] == p.C)
                {
                    NS++;
                }
                else
                {
                    break;
                }
            }//不计入自身
            //斜向
            for (int i = 0; p.X - i >= 0 && p.Y - i >= 0; i++) 
            {
                if (board[p.X-i, p.Y - i] == p.C)
                {
                    WN++;
                }
                else
                {
                    break;
                }
            }//计入自身
            for (int i = -1; p.X - i <= 14 && p.Y - i <= 14; i--)
            {
                if (board[p.X - i, p.Y - i] == p.C)
                {
                    WN++;
                }
                else
                {
                    break;
                }
            }//不计入自身
            for (int i = 0; p.X - i >= 0 && p.Y + i <= 14; i++)
            {
                if (board[p.X - i, p.Y + i] == p.C)
                {
                    ES++;
                }
                else
                {
                    break;
                }
            }//计入自身
            for (int i = -1; p.X - i <= 14 && p.Y + i >= 0; i--)
            {
                if (board[p.X - i, p.Y + i] == p.C)
                {
                    ES++;
                }
                else
                {
                    break;
                }
            }//不计入自身
            label4.Text = "横向有：" + WE.ToString() + "\r\n纵向有" + NS.ToString() + "\r\n正斜向有" + WN.ToString() + "\r\n反斜向有：" + ES.ToString();
            int max=0;//最大值
            max = Math.Max(Math.Max(WE, NS), Math.Max(WN, ES));
            if (max >= 5)
            {
                DeleteCheckinLine(p);
                Damage(0.01f*max*(max-4),-1*p.C);
                StoreinBoard();
            }
        }
        void DeleteCheckinLine(Check p)//删除与p点同色且相连的同色棋子，1为黑棋，-1为白棋
        {
            int c = p.C;
            for (int i = 1; p.X - i >= 0; i++)
            {
                if (board[p.X - i, p.Y] == c)
                {
                    DeletePoint(p.X - i, p.Y);
                }
                else
                {
                    break;
                }
            }
            for (int i = -1; p.X - i <= 14; i--)
            {
                if (board[p.X - i, p.Y] == c)
                {
                    DeletePoint(p.X - i, p.Y);
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; p.Y - i >= 0; i++)
            {
                if (board[p.X, p.Y - i] == c)
                {
                    DeletePoint(p.X, p.Y - i);
                }
                else
                {
                    break;
                }
            }
            for (int i = -1; p.Y - i <= 14; i--)
            {
                if (board[p.X, p.Y - i] == c)
                {
                    DeletePoint(p.X, p.Y - i);
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; p.X - i >= 0 && p.Y - i >= 0; i++)
            {
                if (board[p.X - i, p.Y - i] == c)
                {
                    DeletePoint(p.X - i, p.Y - i);
                }
                else
                {
                    break;
                }
            }
            for (int i = -1; p.X - i <= 14 && p.Y - i <= 14; i--)
            {
                if (board[p.X - i, p.Y - i] == c)
                {
                    DeletePoint(p.X - i, p.Y - i);
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; p.X - i >= 0 && p.Y + i <= 14; i++)
            {
                if (board[p.X - i, p.Y + i] == c)
                {
                    DeletePoint(p.X - i, p.Y + i);
                }
                else
                {
                    break;
                }
            }
            for (int i = -1; p.X - i <= 14 && p.Y + i >= 0; i--)
            {
                if (board[p.X - i, p.Y + i] == c)
                {
                    DeletePoint(p.X - i, p.Y + i);
                }
                else
                {
                    break;
                }
            }
            DeletePoint(p.X, p.Y);
        }
        void DeletePoint(int x,int y)//在points数组和board数组中删除棋盘上(x,y)处的棋子
        {
            for(int i=0;i<points .Count; i++)
            {
                if (points[i].X == x && points[i].Y == y)
                {
                    points.RemoveAt(i);
                }
            }
            board[x, y] = 0;
        }
        void Damage(float d,int c)//对持颜色c的玩家造成d伤害
        {
            if(HPofMa >d && HPofDalishi >d)
            {
                if (c == 1)
                {
                    HPofDalishi -= d;
                    BarHPofDa.Value = Convert.ToInt32(HPofDalishi * BarHPofDa.Maximum);
                    HPofDaLabel.Text = "-" + Convert.ToInt32(d * BarHPofDa.Maximum);
                    HPofDaLabel.Visible = true;
                    BarTimerDa.Start();
                }
                else
                {
                    HPofMa -= d;
                    BarHPofMa.Value = Convert.ToInt32(HPofMa * BarHPofMa.Maximum);
                    HPofMaLabel.Text = "-" + Convert.ToInt32(d * BarHPofDa.Maximum);
                    HPofMaLabel.Visible = true;
                    BarTimerMa.Start();
                }
            }
            else if(HPofMa >0&&HPofDalishi <=d && c==1)
            {
                MaWin();
            }
            else if(HPofDalishi >0&&HPofMa <= d && c==-1)
            {
                DaWin();
            }
        }
        void AutoPlay() //白棋自动走棋一步。自动选取相连数最多的可能位置落子
        {
            int bestx = 0;
            int besty = 0;
            int score = 0;
            int bestscore = 0;
            for(int x = 0; x < 15; x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    score=TestBest(x,y);
                    if (score > bestscore)
                    {
                        bestx = x;
                        besty = y;
                        bestscore = score;
                    }
                    else { }
                }
            }
            points.Add(new Check(bestx, besty, -1));
            ColorisBlack = 1;
            pictureBox1.Invalidate();
        }
        void Checkboard(int max)
        {
            StreamWriter checker00 = new StreamWriter("checker.txt", false);
            checker00.WriteLine(DateTime.Now.ToString());
            checker00.Close();
            int i;
            for (i=0; i <= max; i++)
            {
                string s = null;
                s += "当前棋盘：" + i.ToString() + "\r\n";
                for (int y = 0; y < 14; y++)
                {
                    for (int x = 0; x < 14; x++)
                    {
                        s += "(" + x.ToString() + "," + y.ToString() + ")" + "=" + Boardstate[i][x, y].ToString() + " ";
                    }
                    s += "\r\n";
                }
                boardcheck.Text = s;
                StreamWriter checker = new StreamWriter("checker.txt", true);
                checker.WriteLine(s);
                checker.Close();
            }
        }
        int TestBest(int x,int y)//对board中x,y点生成白棋并返回相连数目。若有子，返回-1
        {
            if (board[x, y] == 1 || board[x, y] == -1)
            {
                return -1;
            }
            else
            {
                int WE = 0;//横向同色连子数
                int NS = 0;//纵向同色连子数
                int WN = 0;//正斜向同色连子数
                int ES = 0;//反斜向同色连子数
                for (int i = 1; x - i >= 0; i++)
                {
                    if (board[x - i, y] == -1)
                    {
                        WE++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = -1; x - i <= 14; i--)
                {
                    if (board[x - i, y] == -1)
                    {
                        WE++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 1; y - i >= 0; i++)
                {
                    if (board[x, y - i] == -1)
                    {
                        NS++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = -1; y - i <= 14; i--)
                {
                    if (board[x, y - i] == -1)
                    {
                        NS++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 1; x - i >= 0 && y - i >= 0; i++)
                {
                    if (board[x - i, y - i] == -1)
                    {
                        WN++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = -1; x - i <= 14 && y - i <= 14; i--)
                {
                    if (board[x - i, y - i] == -1)
                    {
                        WN++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 1; x - i >= 0 && y + i <= 14; i++)
                {
                    if (board[x - i, y + i] == -1)
                    {
                        ES++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = -1; x - i <= 14 && y + i >= 0; i--)
                {
                    if (board[x - i, y + i] == -1)
                    {
                        ES++;
                    }
                    else
                    {
                        break;
                    }
                }
                return 1 + WE + NS + WN + ES;
            }
        }
        void DaWin()//大力士赢
        {
            DalishiWin dalishiWin = new DalishiWin();
            dalishiWin.Show();
            BGMplayer.Ctlcontrols.stop();
            StreamWriter win = new StreamWriter("saveddata.txt", false);
            win.WriteLine("dawin");
            win.Close();
            Hide();
            LimitingTimer.Stop();
            AutoCheck.Stop();
            HPofDalishi = 1f;
            HPofMa = 1f;
        }
        void MaWin()//马老师赢
        {
            MalaoshiWin malaoshiWin = new MalaoshiWin();
            malaoshiWin.Show();
            BGMplayer.Ctlcontrols.stop();
            StreamWriter win = new StreamWriter("saveddata.txt", false);
            win.WriteLine("mawin");
            win.Close();
            Hide();
            LimitingTimer.Stop();
            AutoCheck.Stop();
            HPofDalishi = 1f;
            HPofMa = 1f;
        }
        void ShowLoadingTip()
        {
            if (textshowingtime < 15)
            {
                LoadingTip.Enabled = true;
                LoadingTip.Visible = true;
            }
            else
            {
                LoadingTip.Enabled = false;
                LoadingTip.Visible = false;
                TextshowingTimer.Stop();
                textshowingtime = 0;
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            BGMplayer.Ctlcontrols.stop();
            Save();
            Hide();
            new Homepage().Show();
        }
        private void TextshowingTimer_Tick(object sender, EventArgs e)
        {
            if (textshowingtime < 10000)
            {
                textshowingtime++;
            }
            else
            {
                textshowingtime = 1;
            }
            ShowLoadingTip();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen blackpen = new Pen(Color.Black);
            SolidBrush whitebrush = new SolidBrush(Color.White);
            SolidBrush blackbrush = new SolidBrush(Color.Black);
            SolidBrush redbrush = new SolidBrush(Color.Red);

            for (int i = 0; i < 15; i++)
            {
                g.DrawLine(blackpen, side, top + unit * i, side + unit * 14, top + unit * i);//横线
                g.DrawLine(blackpen, side + unit * i, top, side + unit * i, top + unit * 14);//竖线
            }//画棋盘
            if(isreshow == false)
            {
                if (Blackpoints.Count > 0)
                {
                    g.FillEllipse(redbrush, unit * Blackpoints[Blackpoints.Count - 1].X + side - rsize - 2, unit * Blackpoints[Blackpoints.Count - 1].Y + top - rsize - 2, 2 * rsize + 4, 2 * rsize + 4);
                }
                else { }
                if (Whitepoints.Count > 0)
                {
                    g.FillEllipse(redbrush, unit * Whitepoints[Whitepoints.Count - 1].X + side - rsize - 2, unit * Whitepoints[Whitepoints.Count - 1].Y + top - rsize - 2, 2 * rsize + 4, 2 * rsize + 4);
                }
                else { }
                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i].C == 1)//black
                    {
                        g.FillEllipse(blackbrush, unit * points[i].X + side - rsize, unit * points[i].Y + top - rsize, 2 * rsize, 2 * rsize);
                    }
                    else//white
                    {
                        g.FillEllipse(whitebrush, unit * points[i].X + side - rsize, unit * points[i].Y + top - rsize, 2 * rsize, 2 * rsize);
                    }
                }//画棋子
                if (ColorisBlack == 1)
                {
                    label3.Text = "下一手为黑";
                }
                else
                {
                    label3.Text = "下一手为白";
                }
            }
            else if(isreshow == true&&reshowtime>=0&& reshowtime < Boardstate.Count)
            {
                Checkboard(reshowtime);
                for (int y = 0; y < 15; y++)
                {
                    for (int x = 0; x < 15; x++)
                    {
                        if (Boardstate[reshowtime][x, y] == 0)
                        {
                            ;
                        }
                        else if (Boardstate[reshowtime][x, y] == 1)
                        {
                            g.FillEllipse(blackbrush, unit * x + side - rsize, unit * y + top - rsize, 2 * rsize, 2 * rsize);
                        }
                        else if (Boardstate[reshowtime][x, y] == -1)
                        {
                            g.FillEllipse(whitebrush, unit * x + side - rsize, unit * y + top - rsize, 2 * rsize, 2 * rsize);
                        }
                    }
                }
            }
            else
            {
                ;
            }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(isreshow == false)
            {
                double tempx = (Convert.ToDouble(e.X) - side) / unit;
                int x = Convert.ToInt32(Math.Round(tempx));
                double tempy = (Convert.ToDouble(e.Y - top)) / unit;
                int y = Convert.ToInt32(Math.Round(tempy));
                check.Text = e.X.ToString() + "," + e.Y.ToString() + "\r\n" + tempx.ToString() + "," + tempy.ToString() + "\r\n" + x.ToString() + "," + y.ToString();
                /*判断是否为人机*/
                if (ModeisAuto == false)
                {
                    if (x < 0 || x > 14 || y < 0 || y > 14)
                    {
                        label1.Text = "请置于棋盘内";
                    }
                    else
                    {
                        for (int i = 0; i < points.Count; i++)
                        {
                            if (-0.01 < (x - points[i].X) && 0.01 > (x - points[i].X) && -0.01 < (y - points[i].Y) && 0.01 > (y - points[i].Y))
                            {
                                isexist = true;
                                label1.Text = "请勿重复落棋！";
                                break;
                            }
                            else
                            {
                                isexist = false;
                            }
                        }
                        if (isexist == false)
                        {
                            points.Add(new Check(x, y, ColorisBlack));
                            label1.Text = "最后落子：(" + Convert.ToString(points[points.Count - 1].X) + "," + Convert.ToString(points[points.Count - 1].Y) + ")";
                            ColorisBlack = -1 * ColorisBlack;
                            limitingtime = 0;
                            LimitingTimer.Start();
                            StoreinBoard();
                            IsWin(points[points.Count - 1]);
                        }
                        label2.Text = "已有棋子：" + points.Count.ToString();
                    }
                    Divide();
                }//手动模式
                else//自动模式
                {
                    if (x < 0 || x > 14 || y < 0 || y > 14)
                    {
                        label1.Text = "请置于棋盘内";
                    }
                    else
                    {
                        for (int i = 0; i < points.Count; i++)
                        {
                            if (-0.01 < (x - points[i].X) && 0.01 > (x - points[i].X) && -0.01 < (y - points[i].Y) && 0.01 > (y - points[i].Y))
                            {
                                isexist = true;
                                label1.Text = "请勿重复落棋！";
                                break;
                            }
                            else
                            {
                                isexist = false;
                            }
                        }
                        if (isexist == false)
                        {
                            points.Add(new Check(x, y, 1));
                            StoreinBoard();
                            pictureBox1.Invalidate();
                            IsWin(points[points.Count - 1]);
                            pictureBox1.Invalidate();
                            label1.Text = "最后落子：(" + Convert.ToString(points[points.Count - 1].X) + "," + Convert.ToString(points[points.Count - 1].Y) + ")";
                            AutoPlay();
                            StoreinBoard();
                            pictureBox1.Invalidate();
                            IsWin(points[points.Count - 1]);
                            pictureBox1.Invalidate();
                            ColorisBlack = 1;
                            limitingtime = 0;
                            LimitingTimer.Start();
                        }
                        label2.Text = "已有棋子：" + points.Count.ToString();
                    }
                    Divide();
                }
                pictureBox1.Invalidate();

                if (points.Count >= 225)
                {
                    DialogResult opt = MessageBox.Show("棋盘已满，是否清空？", "提示", MessageBoxButtons.YesNo);
                    if (opt == DialogResult.Yes)
                    {
                        points.Clear();
                        Whitepoints.Clear();
                        Blackpoints.Clear();
                        label1.Text = "最后落子：";
                        label2.Text = "已有棋子：0";
                        label3.Text = "下一手为黑";
                        pictureBox1.Invalidate();
                        ColorisBlack = 1;
                        StoreinBoard();
                    }
                }
                else { }//清空已满棋盘

            }
            else { }
        }
        private void LimitingTimer_Tick(object sender, EventArgs e)
        {
            limitingtime++;
            int lefttime = 10 - limitingtime;
            if (ColorisBlack == -1)
            {
                if (lefttime > 0)
                {
                    TimetipMa.Text = "剩余时间：" + lefttime.ToString();
                }
                else
                {
                    TimetipMa.Text = "时间到";
                    Damage(timeoverpunishment, ColorisBlack);
                }
                TimetipMa.Visible=true;
                TimetipDa.Visible = false;
            }
            else
            {
                if (lefttime > 0)
                {
                    TimetipDa.Text = "剩余时间：" + lefttime.ToString();
                }
                else
                {
                    TimetipDa.Text = "时间到";
                    Damage(0.01f, ColorisBlack);
                }
                TimetipDa.Visible = true;
                TimetipMa.Visible = false;
            }
        }
        private void BarTimerMa_Tick(object sender, EventArgs e)
        {
            if (bartime < 6)
            {
               bartime++;
            }
            else
            {
                HPofMaLabel.Visible = false;
                BarTimerMa.Stop();
            }
        }
        private void BarTimerDa_Tick(object sender, EventArgs e)
        {
            if (bartime < 6)
            {
                bartime++;
            }
            else
            {
                HPofDaLabel.Visible = false;
                BarTimerDa.Stop();
            }
        }

        private void 游戏规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rule rule=new Rule();
            rule.Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acknowledgement acknowledgement = new Acknowledgement();
            acknowledgement.Show();
        }

        private void 悔棋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(points.Count > 4)
            {
                LimitingTimer.Stop();
                if (ColorisBlack == 1)
                {
                    DialogResult result = MessageBox.Show("你确定要舍弃自己的20点武德来偷袭马老师吗", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Damage(20.00f / BarHPofDa.Maximum, ColorisBlack);
                        Touxi touxi = new Touxi();
                        touxi.Show();
                        points.RemoveAt(points.Count-1);
                        points.RemoveAt(points.Count-1);
                        Divide();
                        StoreinBoard();
                        pictureBox1.Invalidate();
                        TimetipDa.Text = "偷袭成功，对马老师造成额外效果：瘫痪";
                    }
                    else
                    {
                        LimitingTimer.Start();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("武林要以和为贵，不能搞窝里斗（马老师是有武德的人）", "偷袭失败", MessageBoxButtons.OK);
                    LimitingTimer.Start();
                }
            }
            else
            {
                MessageBox.Show("先过几招才能偷袭","偷袭失败",MessageBoxButtons.OK );
            }
        }

        private void 投降ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimitingTimer.Stop();
            if (ColorisBlack == 1)
            {
                DialogResult result = MessageBox.Show("你已经好好反省,要做一个有武德的人吗？", "来自马老师的拷问", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    MaWin();
                }
                else
                {
                    LimitingTimer.Start();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("马老师你要退出武林了吗", "来自大力士的疑惑", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    DaWin();
                }
                else
                {
                    LimitingTimer.Start();
                }
            }
        }

        private void AutoCheck_Tick(object sender, EventArgs e)
        {
            if (AutoTrueButton.Checked == true && AutoFalseButton.Checked == false)
            {
                ModeisAuto = true;
            }
            else
            {
                ModeisAuto = false;
            }
            autotime++;
            if (autotime >= 100)
            {
                autotime = 0;
                Save();
            }
        }

        private void AutoTrueButton_CheckedChanged(object sender, EventArgs e)
        {
            if(AutoTrueButton.Checked == true)
            {
                if (ColorisBlack == -1)
                {
                    AutoPlay();
                }
            }
        }

        private void 存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimitingTimer.Stop();
            DialogResult result = MessageBox.Show("来日再战？", "打累了？", MessageBoxButtons.YesNo);
            if(result ==DialogResult.Yes)
            {
                Save();
                Close();
                Application.Exit();
            }
            else
            {
                LimitingTimer.Start();
            }
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 复盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimitingTimer.Stop();
            DialogResult result = MessageBox.Show("确定要开始好好反思了吗？", "", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                reshowtime = -3;
                isreshow = true; 
                TimetipDa.Text = TimetipMa.Text = "反思中";
                TimetipMa.Enabled = TimetipDa.Enabled = true;
                pictureBox1.Invalidate();
                ReshowTimer.Start();
            }
            else
            {
                LimitingTimer.Start();
            }
        }

        private void ReshowTimer_Tick(object sender, EventArgs e)
        {
            if(reshowtime < Boardstate.Count&&reshowtime >=0)
            {
                pictureBox1.Invalidate();
                reshowtime++;
            }
            else if(reshowtime >= Boardstate.Count)
            {
                ReshowTimer.Stop();
                TimetipDa.Text = TimetipMa.Text = "反思好了";
                pictureBox1.Invalidate();
                isreshow = false;
            }
            else
            {
                reshowtime++;
            }
        }
    }
    public class Check
    {
        public int X;
        public int Y;
        public int C;
        public Check(int x, int y, int c)
        {
            X = x;
            Y = y;
            C = c;
        }
    }
    public class Board
    {
        public int[,] PointInBoard = new int[15, 15];
        public Board(int[,] rev)
        {
            PointInBoard = rev;
        }
    }
}

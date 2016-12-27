using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        string Duong_Dan = System.IO.Directory.GetCurrentDirectory() + "\\Diem\\";
        int diem = 0;
        int[] xephang=new int[10];
        int so;
        bool dung = false;
        bool moi = true;
        Random ranfood = new Random();
        //Random ranfood;
        Random huong = new Random();
        food food;
        Graphics paper;
        snake snake = new snake();
        //snake snake;
        snakeAI snakeai = new snakeAI();
        Boolean left = false, right = false, up = false, down = false, l = false, r = false, u = false, d = false;
        Boolean leftai = false, rightai = false, upai = false, downai = false, lai = false, rai = false, uai = false, dai = false;
        public Form1()
        {
            InitializeComponent();
            food = new food(ranfood);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            snake.drawSnake(paper);
            food.drawFood(paper);
            snakeai.drawSnake(paper);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {                
                
                if (moi == false)
                {
                    if (dung == false)
                    {
                        left = false; right = false; up = false; down = false;
                        leftai = false; rightai = false; upai = false; downai = false;
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        dung = true;
                    }
                    else
                    {
                        timer1.Enabled = true;
                        timer2.Enabled = true;
                        left = l; right = r; up = u; down = d;
                        leftai = lai; rightai = rai; upai = uai; downai = dai;
                        dung = false;
                    }

                }
                else
                { 
                    timer1.Enabled = true;
                    timer2.Enabled = true;
                    //snake = new snake();
                    //ranfood = new Random();
                    //food = new food(ranfood);
                    left = false; right = true; up = false; down = false;
                    l = false; r = true; u = false; d = false;
                    leftai = false; rightai = false; upai = false; downai = true;
                    lai = false; rai = false; uai = false; dai = true;
                    moi = false;
                }
                label1.Text = "";
            }
            if (e.KeyData==Keys.Up && down==false)
            {
                up = true; u = true;
                left = false; l = false;
                right = false; r= false;
                down = false; d = false;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                up = false; u = false;
                left = false; l = false;
                right = false; r = false;
                down = true; d = true;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                up = false; u = false;
                left = true; l = true;
                right = false; r = false;
                down = false; d = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                up = false; u = false;
                left = false; l = false;
                right = true; r = true;
                down = false; d = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (down == true) { snake.movedown(); }
            if (up == true) { snake.moveup(); }
            if (left == true) { snake.moveleft(); }
            if (right == true) { snake.moveright(); }

            if (downai == true) 
            {
                if (snakeai.SnakeRecAI[0].Y < 290)
                {
                    snakeai.movedown();
                }

                else 
                {
                    downai = false;
                    dai = false;
                    if (snakeai.SnakeRecAI[0].X > 140)
                    {
                        leftai = true;
                        lai = true;
                        snakeai.moveleft();
                    }
                    else
                    {
                        rightai = true;
                        rai = true;
                        snakeai.moveright();
                    }
                    
                }
            }
            if (upai == true) 
            {
                if (snakeai.SnakeRecAI[0].Y > 0)
                {
                    snakeai.moveup();
                }
                else 
                {
                    upai = false;
                    uai = false;
                    if (snakeai.SnakeRecAI[0].X > 140)
                    {
                        leftai = true;
                        lai = true;
                        snakeai.moveleft();
                    }
                    else
                    {
                        rightai = true;
                        rai = true;
                        snakeai.moveright();
                    }
                    
                }
            }
            if (leftai == true) 
            {
                if (snakeai.SnakeRecAI[0].X > 0)
                {
                    snakeai.moveleft();
                }
                else
                {
                    leftai = false;
                    lai = false;
                    if (snakeai.SnakeRecAI[0].Y > 140)
                    {
                        upai = true;
                        uai = true;
                        snakeai.moveup();
                    }
                    else
                    {
                        downai = true;
                        dai = true;
                        snakeai.movedown();
                    }
                    
                }
            }
            if (rightai == true) 
            {
                if (snakeai.SnakeRecAI[0].X < 290)
                {
                    snakeai.moveright();
                }
                else
                {
                    rightai = false;
                    rai = false;
                    if (snakeai.SnakeRecAI[0].Y > 140)
                    {
                        upai = true;
                        uai = true;
                        snakeai.moveup();
                    }
                    else
                    {
                        downai = true;
                        dai = true;
                        snakeai.movedown();
                    } 
                    
                }
                //uai1.Text = uai.ToString();
                //dai1.Text = dai.ToString();
                //lai1.Text = lai.ToString();
                //rai1.Text = rai.ToString();
            }

            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(food.foodRec))
                {
                    snake.growSnake();
                    food.foodLocation(ranfood);
                    diem += 1;
                    toolStripStatusLabel2.Text = diem.ToString();
                    //if (diem < 60)
                    //{
                    //    timer1.Interval -= 2;
                    //}
                }
            }
            for (int i = 0; i < snakeai.SnakeRecAI.Length; i++)
            {
                if (snakeai.SnakeRecAI[i].IntersectsWith(food.foodRec))
                {
                    snakeai.growSnake();
                    food.foodLocation(ranfood);                    
                }
            }
            game_over();
            this.Invalidate();
        }
        public void game_over()
        {
            //Đụng tường chết
            if (snake.SnakeRec[0].X > 290 || snake.SnakeRec[0].X < 0)
            {
                restart();
            }
            if (snake.SnakeRec[0].Y > 290 || snake.SnakeRec[0].Y < 0)
            {
                restart();
            }
            for (int i = 1; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[i]))
                {
                    restart();
                }
            }
            for (int i = 1; i < snakeai.SnakeRecAI.Length; i++)
            {
                if (snakeai.SnakeRecAI[i].IntersectsWith(snake.SnakeRec[0]))
                {
                    restart();
                }
            }

        }

        private void Doc_diem()
        {
            FileStream File_Docdiem = new FileStream(Duong_Dan + "diem.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader Dong_Docdiem = new StreamReader(File_Docdiem);
            string D_Doc_TT = Dong_Docdiem.ReadLine(); xephang[0] = Convert.ToInt32(D_Doc_TT.Trim());
            D_Doc_TT = Dong_Docdiem.ReadLine(); xephang[1] = Convert.ToInt32(D_Doc_TT.Trim());
            D_Doc_TT = Dong_Docdiem.ReadLine(); xephang[2] = Convert.ToInt32(D_Doc_TT.Trim());
            D_Doc_TT = Dong_Docdiem.ReadLine(); xephang[3] = Convert.ToInt32(D_Doc_TT.Trim());
            D_Doc_TT = Dong_Docdiem.ReadLine(); xephang[4] = Convert.ToInt32(D_Doc_TT.Trim());
            D_Doc_TT = Dong_Docdiem.ReadLine(); xephang[5] = Convert.ToInt32(D_Doc_TT.Trim());
            D_Doc_TT = Dong_Docdiem.ReadLine(); xephang[6] = Convert.ToInt32(D_Doc_TT.Trim());
            D_Doc_TT = Dong_Docdiem.ReadLine(); xephang[7] = Convert.ToInt32(D_Doc_TT.Trim());
            D_Doc_TT = Dong_Docdiem.ReadLine(); xephang[8] = Convert.ToInt32(D_Doc_TT.Trim());
            D_Doc_TT = Dong_Docdiem.ReadLine(); xephang[9] = Convert.ToInt32(D_Doc_TT.Trim());
            Dong_Docdiem.Close(); 
            File_Docdiem.Close();
        }
        private void Xep_hang()
        {
            for (int i = 0; i < 9; i++)
            {
                if (diem == xephang[i]) { break; }
                else
                {
                    if (diem > xephang[i])
                    {
                        for (int j =9; j >i; j--)
                        { xephang[j] = xephang[j - 1]; }
                        xephang[i] = diem;
                        break;
                    }
                }
            }
        }
        private void Ghi_diem()
        {

            FileStream File_Ghidiem = new FileStream(Duong_Dan + "diem.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            StreamWriter Dong_Ghidiem = new StreamWriter(File_Ghidiem);
            //Dong_Ghidiem.WriteLine(diemcaonhat);
            for (int t = 0; t < 10; t++)
            {
                Dong_Ghidiem.WriteLine(xephang[t]);
            }
            Dong_Ghidiem.Flush();
            Dong_Ghidiem.Close() ;
            File_Ghidiem.Close();
        }
        private void restart()
        {
            Doc_diem();
            Xep_hang();
            Ghi_diem();
            string a = diem.ToString() ;
            timer1.Enabled = false;
            timer2.Enabled = false;

            MessageBox.Show("            Điểm của bạn:" + diem + "\n            Bảng xếp hạng\n           |       #1       |             " + xephang[0].ToString() + "\n           |       #2       |             " + xephang[1].ToString() + "\n           |       #3       |             " + xephang[2].ToString() + "\n           |       #4       |             " + xephang[3].ToString() + "\n           |       #5       |             " + xephang[4].ToString() + "\n           |       #6       |             " + xephang[5].ToString() + "\n           |       #7       |             " + xephang[6].ToString() + "\n           |       #8       |             " + xephang[7].ToString() + "\n           |       #9       |             " + xephang[8].ToString() + "\n           |       #10     |             " + xephang[9].ToString() + "\n", "Trò chơi kết thúc");
            moi = true;
            dung = false;
            //timer1.Interval = 120;
            toolStripStatusLabel2.Text = "0";
            diem = 0;
            label1.Text = "Bấm cách để bắt đầu";
            food = new food(ranfood);
            snake = new snake();
            snakeai = new snakeAI();
            left = false; right = false; up = false; down = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
                if (upai == true && snakeai.SnakeRecAI[0].X == 0)
                {
                    so = 4;
                }

                if (upai == true && snakeai.SnakeRecAI[0].X == 290)
                {
                    so = 3;
                    dieukhien(so);
                }
                if (downai == true && snakeai.SnakeRecAI[0].X == 0)
                {
                    so = 4;
                }
                if (downai == true && snakeai.SnakeRecAI[0].X == 290)
                {
                    so = 3;
                    dieukhien(so);
                }
                if (leftai == true && snakeai.SnakeRecAI[0].Y == 0)
                {
                    so = 2;
                    
                }
                if (leftai == true && snakeai.SnakeRecAI[0].Y == 290)
                {
                    so = 1;
                    dieukhien(so);
                }
                if (rightai == true && snakeai.SnakeRecAI[0].Y == 0)
                {
                    so = 2;
                }

                if (rightai == true && snakeai.SnakeRecAI[0].Y == 290)
                {
                    so = 1;
                    dieukhien(so);
                }
                else
                {
                    so = huong.Next(1, 4);
                }
            
        }
          private void dieukhien(int so)
          {
              if (so == 1 && downai == false)
              {
                    upai = true; uai = true;
                    leftai = false; lai = false;
                    rightai = false; rai = false;
                    downai = false; dai = false;
               }

               if (so==2 && upai == false)
               {
                upai = false; uai = false;
                leftai = false; lai = false;
                rightai = false; rai = false;
                downai = true; dai = true;
               }

               if (so==3 && rightai == false)
               {
                upai = false; uai = false;
                leftai = true; lai = true;
                rightai = false; rai = false;
                downai = false; dai = false;
               }

               if (so==4 && leftai == false)
               {
                upai = false; uai = false;
                leftai = false; lai = false;
                rightai = true; rai = true;
                downai = false; dai = false;
               }
          }
 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication8
{
    class snake
    {
        private Random rd = new Random();
        private Rectangle[] snakeRec;
        public Rectangle[] SnakeRec
        {
            get { return snakeRec; }
        }
        private SolidBrush brush;
        //private SolidBrush head;
        private int x, y, width, height;

        public snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Green);
            //head = new SolidBrush(Color.Red);
            x = rd.Next(0, 29) * 10; y = rd.Next(0, 29) * 10; width = 10; height = 10;
            //snakeRec[0] = new Rectangle(30, 0, 10, 10);
            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }
        public void drawSnake(Graphics paper)
        {
            //paper.FillRectangle(brush, snakeRec[0]);
            //paper.FillRectangle(brush, snakeRec[1]);
            //paper.FillRectangle(brush, snakeRec[2]);
            foreach (Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }
        }
               public void Drawsnakerun()
        {
            for (int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }
               public void movedown()
               {                   
                       Drawsnakerun();
                       snakeRec[0].Y += 10;
 
               }
               public void moveup()
               {
                       Drawsnakerun();
                       snakeRec[0].Y -= 10;
                   
               }
               public void moveright()
               {
                       Drawsnakerun();
                       snakeRec[0].X += 10;
                   
               }
               public void moveleft()
               {
                       Drawsnakerun();
                       snakeRec[0].X -= 10;

               }               

               public void growSnake()
               {
                   List<Rectangle> rec = snakeRec.ToList();
                   rec.Add(new Rectangle(snakeRec[snakeRec.Length-1].X,snakeRec[snakeRec.Length-1].Y,width,height));
                   snakeRec = rec.ToArray();
               }
              
    }
}

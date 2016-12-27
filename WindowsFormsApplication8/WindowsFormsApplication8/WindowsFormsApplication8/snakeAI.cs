using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication8
{
    class snakeAI
    {
        private Rectangle[] snakeRecAI;
        public Rectangle[] SnakeRecAI
        {
            get { return snakeRecAI; }
        }
        private SolidBrush brush;
        //private SolidBrush head;
        private int x, y, width, height;
        public snakeAI()
        {
            snakeRecAI = new Rectangle[15];
            brush = new SolidBrush(Color.Red);
            //head = new SolidBrush(Color.Black);
            x = 150; y = 70; width = 10; height = 10;
            //snakeRec[1] = new Rectangle(x, y, width, height);
            for (int i = 0; i < snakeRecAI.Length; i++)
            {
                snakeRecAI[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }
        public void drawSnake(Graphics paper)
        {
            foreach (Rectangle rec in snakeRecAI)
            {
                paper.FillRectangle(brush, rec);
            }
        }
        public void Drawsnakerun()
        {
            for (int i = snakeRecAI.Length - 1; i > 0; i--)
            {
                snakeRecAI[i] = snakeRecAI[i - 1];
            }
        }
        public void movedown()
        {
            //if (snakeRecAI[0].Y < 290)
            //{
                Drawsnakerun();
                snakeRecAI[0].Y += 10;
            //}
            //else
            //{
            //    if (snakeRecAI[0].X > 140)
            //    {
            //        Drawsnakerun();
            //        moveleft();
            //    }
            //    else 
            //    {
            //        Drawsnakerun();
            //        moveright(); 
            //    }

            //}
        }
        public void moveup()
        {
            //if (snakeRecAI[0].Y > 0)
            //{
            Drawsnakerun();
            snakeRecAI[0].Y -= 10;
            //}
            //else
            //{
            //    if (snakeRecAI[0].X > 140)
            //    {
            //        Drawsnakerun();
            //        moveleft();
            //    }
            //    else
            //    { Drawsnakerun(); moveright(); }
            //}

        }
        public void moveright()
        {
            //if (snakeRecAI[0].X < 290)
            //{
            Drawsnakerun();
            snakeRecAI[0].X += 10;
            //}
            //else
            //{
            //    if (snakeRecAI[0].Y > 140)
            //    {
            //        Drawsnakerun();
            //        moveup();
            //    }
            //    else { Drawsnakerun(); movedown(); }
            //}
        }
        public void moveleft()
        {
            //if (snakeRecAI[0].X > 0)
            //{
            Drawsnakerun();
            snakeRecAI[0].X -= 10;
            //}
            //else
            //{
            //    if (snakeRecAI[0].Y > 140)
            //    {
            //        Drawsnakerun(); moveup();
            //    }
            //    else { Drawsnakerun(); movedown(); }
            //}
        }

        public void growSnake()
        {
            List<Rectangle> rec = snakeRecAI.ToList();
            rec.Add(new Rectangle(snakeRecAI[snakeRecAI.Length - 1].X, snakeRecAI[snakeRecAI.Length - 1].Y, width, height));
            snakeRecAI = rec.ToArray();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace WindowsFormsApplication8
{
    class food
    {
        private int x, y, width, height;
        private SolidBrush brush;
        public Rectangle foodRec;
        public food(Random ranFood)
        {
            x = ranFood.Next(0, 29) * 10;
            y = ranFood.Next(0, 29) * 10;
            brush = new SolidBrush(Color.Black);
            width = 10;
            height = 10;
            foodRec = new Rectangle(x, y, width, height);
        }
        public void drawFood(Graphics paper)
        {
            foodRec.X = x;
            foodRec.Y = y;
            paper.FillRectangle(brush, foodRec);
        }
          public void foodLocation(Random ranFood)
        {
            x = ranFood.Next(0, 29) * 10;
            y = ranFood.Next(0, 29) * 10;
         }
    }
}

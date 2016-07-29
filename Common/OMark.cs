using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Points;


namespace Commons
{
    public class OMark : Common
    {
        public OMark(myPoint coordinate, int width, int height) : base(coordinate, width, height)
        {   }
        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.CornflowerBlue), Coordinate.X, Coordinate.Y, Width, Height);
            g.FillRectangle(new SolidBrush(Color.Blue), Coordinate.X + 2, Coordinate.Y + 2, Width - 4, Height - 4);
            g.DrawEllipse(new Pen(Color.White, 4), Coordinate.X + 2, Coordinate.Y + 2, Width - 4,  Height - 4);
            
        }
        public void Delete(List<OMark> list)
        {
            list.Remove(this);
        }
    }
}

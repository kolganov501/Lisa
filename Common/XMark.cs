using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Points;

namespace Commons
{
    public class XMark : Common
    {
        public XMark(myPoint coordinate, int width, int height) : base(coordinate, width, height)
        {

        }
        public void Draw(Graphics g)//функция по отрисовке
        {
            g.FillRectangle(new SolidBrush(Color.CornflowerBlue), Coordinate.X, Coordinate.Y, Width, Height);
            g.FillRectangle(new SolidBrush(Color.Blue), Coordinate.X + 2, Coordinate.Y + 2, Width - 4, Height - 4);
            g.DrawLine(new Pen(Color.White, 4), Coordinate.X + 2, Coordinate.Y + 2, Coordinate.X + Width - 4, Coordinate.Y + Height - 4);
            g.DrawLine(new Pen(Color.White, 4), Coordinate.X + Width - 4, Coordinate.Y + 2, Coordinate.X + 2, Coordinate.Y + Height - 4);
        }
        public void Delete(List<XMark> list)
        {
            list.Remove(this);
        }
    }
}

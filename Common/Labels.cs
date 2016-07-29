using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Points;
using System.Drawing;


namespace Commons
{
    public class Labels : Common
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public Labels(myPoint coordinate, int width, int height, string text) : base(coordinate, width, height)
        {
            _text = text;
        }
        public void Draw(Graphics g)//функция по отрисовке
        {
            g.DrawString(Text, new Font("Simplex_IV50", 16, FontStyle.Bold), new SolidBrush(Color.MidnightBlue), new Point(Coordinate.X + 5, Coordinate.Y + Height - 5));
        }
        public void Delete(List<Labels> list)
        {
            list.Remove(this);
        }
    }
}

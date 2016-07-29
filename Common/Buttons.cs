using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Points;
using System.Drawing;
using Logic;
using System.Windows.Forms;

namespace Commons
{
    public class Buttons : Common
    {

        public delegate void FormClick(); //при отклике получаем объекты класса форм1
        public event FormClick Activate;
        public delegate void MarkClick(int number, int type); // отклик при щелчке по игровой кнопке
        public event MarkClick ActivateMark;
        private bool _clicked = false;
        private string _text;
        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public bool Clicked
        {
            get { return _clicked; }
            set { _clicked = value; }
        }
        public Buttons(myPoint coordinate, int width, int height, string text, int number = -1) : base(coordinate, width, height) // добавил int number = -1 по умолчанию, необходимо для того чтобы передать будем ли мы ставить Х или О 
        {
            _number = number;
            _text = text;
        }
        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.CornflowerBlue), Coordinate.X, Coordinate.Y, Width, Height);
            g.FillRectangle(new SolidBrush(Color.Blue), Coordinate.X + 2, Coordinate.Y + 2, Width - 4, Height - 4);
            g.DrawString(Text, new Font("Simplex_IV50", 16, FontStyle.Bold), new SolidBrush(Color.White), new Point(Coordinate.X, Coordinate.Y + Height - 45));

        }
        public void Click(myPoint Coord)
        {
            if ((this.Coordinate.X <= Coord.X) && (this.Coordinate.X + this.Width >= Coord.X) && (this.Coordinate.Y <= Coord.Y) && (this.Coordinate.Y + this.Height >= Coord.Y))
            {
                if (this.Number != -1)      
                    ActivateMark(this.Number, 1); // если кнопка игровая, то мы передаем порядковый номер кнопки и тип символа, если поставить 2 - будут нолики
                if (Activate != null)//событие игнорится если его не вызывают
                    Activate();
            }
        }

        public void Delete(List<Buttons> list)
        {
            list.Remove(this);
        }
    }
}

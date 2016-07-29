using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Points;
using System.Drawing;

namespace Commons
{
    public class TextBoxes : Common
    {
        private string _field;
        private bool _clicked;
        public string Field
        {
            get { return _field; }
            set { _field = value; }
        }
        public TextBoxes(myPoint coordinate, int width, int height, string field) : base(coordinate, width, height)
        {
            _field = field;
        }
        public void Draw(Graphics g)
        {
            if (_clicked)
            {
                g.FillRectangle(new SolidBrush(Color.DarkBlue), this.Coordinate.X, this.Coordinate.Y, this.Width, this.Height);
                g.FillRectangle(new SolidBrush(Color.Azure), this.Coordinate.X + 2, this.Coordinate.Y + 2, this.Width - 4, this.Height - 4);
                g.DrawString(this.Field, new Font("Buxton Sketch", 19, FontStyle.Bold), Brushes.Black, new Point(this.Coordinate.X + 5, this.Coordinate.Y + this.Height - 25));
            }
            else
            {
                g.FillRectangle(new SolidBrush(Color.DarkBlue), this.Coordinate.X, this.Coordinate.Y, this.Width, this.Height);
                g.FillRectangle(new SolidBrush(Color.LightBlue), this.Coordinate.X + 2, this.Coordinate.Y + 2, this.Width - 4, this.Height - 4);
                g.DrawString(this.Field, new Font("Buxton Sketch", 19, FontStyle.Bold), Brushes.Black, new Point(this.Coordinate.X + 5, this.Coordinate.Y + this.Height - 25));
            }
        }

        public void Click(myPoint clickCoordinate)
        {
            if ((clickCoordinate.X >= this.Coordinate.X) && (clickCoordinate.X <= this.Coordinate.X + this.Width) && (clickCoordinate.Y >= this.Coordinate.Y) && (clickCoordinate.Y <= this.Coordinate.Y + this.Height))
                this._clicked = true;
            else
                this._clicked = false;
        }

        public void EnterName(char keyChar)
        {
            if (this._clicked)
            {
                if (this.Field.Length < 10)
                    if ((keyChar >= 'А') && (keyChar <= 'я'))
                    {
                        this.Field += keyChar;
                    }
                if (this.Field.Length != 0)
                    if (keyChar == '\b')
                        this.Field = this.Field.Substring(0, this.Field.Length - 1);
            }
        }
        public void EnterSize(char keyChar)
        {
            if (this._clicked)
            {
                if (this.Field.Length < 10)
                    if ((keyChar >= '0') && (keyChar <= '9'))
                    {
                        this.Field += keyChar;
                    }
                if (this.Field.Length != 0)
                    if (keyChar == '\b')
                        this.Field = this.Field.Substring(0, this.Field.Length - 1);
            }
        }
        public void Delete(List<TextBoxes> list)
        {
            list.Remove(this);
        }
    }
}
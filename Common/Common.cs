using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Points;

namespace Commons
{
    public class Common
    {
        private myPoint _coordinate;
        private int _width;
        private int _height;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public myPoint Coordinate
        {
            get { return _coordinate; }
            set { _coordinate = value; }
        }
        public Common(myPoint coordinate, int width, int height)//описание
        {
            _coordinate = coordinate;
            _width = width;
            _height = height;
        }
    }
}

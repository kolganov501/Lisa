using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    public class myPoint
    {
        private int _x;
        private int _y;
        
        public int X
        {
            get { return _x;}
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }//инкапсуляция
     
       public myPoint(int x,int y)//конструктор для инициализации объекта
        {
            _x = x;
            _y = y;
        }
    }
}

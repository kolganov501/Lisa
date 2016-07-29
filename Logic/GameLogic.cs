using System.Collections.Generic;
using System.Windows.Forms;

namespace Logic
{
    public class GameLogic
    {
        private int i, j;
        private int _size;
        private bool _difficulty;
        public List<int> field = new List<int>();
        public int playersMark = 0;
        public int compMark = 0;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                while (field.Count < _size*_size)
                    field.Add(0);
            }
        }
        public bool Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }
        public GameLogic()
        {

        }
        public void ChangeSymbol(int number, int type)
        {
            field[number] = type;
            CheckGameOver();
        }
        public void CheckGameOver()
        {
            for (i = 0; i < Size; i++)
            {
                playersMark = 0;
                compMark = 0;
                for (j = 0; j < Size; j++)
                {
                    if (field[i * Size + j] == 1)
                        playersMark++;
                    if (field[i * Size + j] == 2)
                        compMark++;
                }
                if (playersMark == Size || compMark == 5)
                {
                    MessageBox.Show("1");//вертик
                    for (j = 0; j < Size * Size; j++)
                        field[j] = 0;
                    break;
                }
                playersMark = 0;
                compMark = 0;
                for (j = 0; j < Size; j++)
                {
                    if (field[j * Size + i] == 1)
                        playersMark++;
                    if (field[j * Size + i] == 2)
                        compMark++;
                }
                if (playersMark == Size || compMark == 5)
                {
                    MessageBox.Show("2");//горизонт
                    for (j = 0; j < Size * Size; j++)
                        field[j] = 0;
                    break;
                }
            }
            playersMark = 0;
            compMark = 0;
            for (i = 0; i < Size; i++)
            {
                if (field[i * Size + i] == 1)
                    playersMark++;
                if (field[i * Size + i] == 2)
                    compMark++;
                if (playersMark == Size || compMark == 5)
                {
                    MessageBox.Show("3");//горизонт
                    for (j = 0; j < Size * Size; j++)
                        field[j] = 0;
                    break;
                }
            }
            playersMark = 0;
            compMark = 0;
            for (i = 1; i < Size+1; i++)
            {
                if (field[i * Size - i] == 1)
                    playersMark++;
                if (field[i * Size - i] == 2)
                    compMark++;
                if (playersMark == Size || compMark == 5)
                {
                    MessageBox.Show("4");//горизонт
                    for (j = 0; j < Size * Size; j++)
                        field[j] = 0;
                    break;
                }
            }
        }
    }
}

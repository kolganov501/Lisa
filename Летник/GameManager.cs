using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Points;
using Commons;
using System.Windows.Forms;
using System.Drawing;
using Logic;

namespace Летник
{
    public class GameManager//не можем создать объекты, но можем использовать функции, нет локальных переменных
    {
        public delegate void MyMouseClick(myPoint point);
        public event MyMouseClick MyClick; 
        
        public delegate void MyDraw(Graphics g);
        public event MyDraw MySketch;

        public delegate void MyEnter(char letter);
        public event MyEnter Enter;

        private Form1 _form;
        private List<Buttons> buttonsList = new List<Buttons>();
        private List<Labels> labelsList = new List<Labels>();
        private List<XMark> Xbutt = new List<XMark>();
        private List<OMark> Obutt = new List<OMark>();
        private List<TextBoxes> textBoxList = new List<TextBoxes>();
        private GameLogic logic = new GameLogic();
        private int i, j;

        public Form1 MyForm
        {
            get { return _form; }
            set { _form = value; }
        }
        public GameManager(Form1 form)
        {
            MyForm = form;
            MyForm.BackColor = Color.White;
            MyForm.Height = 600;
            MyForm.Width = 700;
            MyForm.Paint += FormPaint;
            MyForm.MouseClick += FormClick;
            MyForm.KeyPress += MyPress;
            Menu();
        }

        private void FormPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (MySketch != null)
                MySketch(g);
        }
        private void FormClick(object sender, MouseEventArgs e)
        {
            if (MyClick != null)
                MyClick(new myPoint(e.X, e.Y));// передача координат
            MyForm.Invalidate();
        }
        private void MyPress(object sender, KeyPressEventArgs e)
        {
            if (Enter != null)
                Enter(e.KeyChar);
            MyForm.Invalidate();
        }

        public void Menu()
        {
            for (i = labelsList.Count - 1; i >= 0; i--)
            {
                MySketch -= labelsList[i].Draw;
                labelsList[i].Delete(labelsList);
            }
            for (i = buttonsList.Count - 1; i >= 0; i--)
            {
                MySketch -= buttonsList[i].Draw;
                MyClick -= buttonsList[i].Click;
                buttonsList[i].Delete(buttonsList);
            }
            for (i = Xbutt.Count - 1; i >= 0; i--)
            {
                MySketch -= Xbutt[i].Draw;
                Xbutt[i].Delete(Xbutt);
            }
            for (i = textBoxList.Count - 1; i >= 0; i--)
            {
                MyClick -= textBoxList[i].Click;//каждая кнопка подписана на событие
                MySketch -= textBoxList[i].Draw;
                Enter -= textBoxList[i].EnterSize;
                textBoxList[i].Delete(textBoxList);
            }
            buttonsList.Add(new Buttons(new myPoint(220, 100), 180, 60, "Начать игру"));
            buttonsList.Add(new Buttons(new myPoint(220, 200), 180, 60, "Инструкция"));
            buttonsList.Add(new Buttons(new myPoint(220, 300), 180, 60, "Рекорды"));
            buttonsList.Add(new Buttons(new myPoint(220, 400), 180, 60, "Выход"));

            for (i = 0; i < buttonsList.Count; i++)
            {
                MyClick += buttonsList[i].Click;//каждая кнопка подписана на событие
                MySketch += buttonsList[i].Draw;
            }
            buttonsList[0].Activate += ChooseDifficulty;
            buttonsList[1].Activate += Instruction;
            buttonsList[2].Activate += Records;
            buttonsList[3].Activate += Exit;
            MyForm.Invalidate();
        }
        public void ChooseDifficulty()
        {
            for (i = buttonsList.Count - 1; i >= 0; i--)
            {
                MySketch -= buttonsList[i].Draw;
                MyClick -= buttonsList[i].Click;
                buttonsList[i].Delete(buttonsList);
            }
            buttonsList.Add(new Buttons(new myPoint(220, 150), 180, 60, "Легкий"));
            buttonsList.Add(new Buttons(new myPoint(220, 260), 180, 60, "Сложный"));
            buttonsList.Add(new Buttons(new myPoint(350, 440), 180, 60, "Назад"));
            for (i = 0; i < buttonsList.Count; i++)
            {
                MyClick += buttonsList[i].Click;//каждая кнопка подписана на событие
                MySketch += buttonsList[i].Draw;
            }
            buttonsList[0].Activate += ChooseSize;
            buttonsList[1].Activate += ChooseSize;
            buttonsList[2].Activate += Menu;
            MyForm.Invalidate();
        }
        public void ChooseSize()
        {
            if (buttonsList[0].Clicked)
                logic.Difficulty = true;
            if (buttonsList[1].Clicked)
                logic.Difficulty = false;
            for (i = buttonsList.Count - 1; i >= 0; i--)
            {
                MySketch -= buttonsList[i].Draw;
                MyClick -= buttonsList[i].Click;
                buttonsList[i].Delete(buttonsList);
            }
            textBoxList.Add(new TextBoxes(new myPoint(220, 200), 180, 60, ""));
            buttonsList.Add(new Buttons(new myPoint(220, 320), 180, 60, "Принять"));
            buttonsList.Add(new Buttons(new myPoint(350, 440), 180, 60, "Назад"));
            for (i = 0; i < buttonsList.Count; i++)
            {
                MyClick += buttonsList[i].Click;//каждая кнопка подписана на событие
                MySketch += buttonsList[i].Draw;//гейм менеджер подписан на нажатие кнопки        
            }
            MyClick += textBoxList[0].Click;//каждая кнопка подписана на событие
            MySketch += textBoxList[0].Draw;
            Enter += textBoxList[0].EnterSize;
            buttonsList[0].Activate += StartGame;
            buttonsList[1].Activate += Menu;
            MyForm.Invalidate();
        }
        
        public void StartGame()
        {
            logic.Size = int.Parse(textBoxList[0].Field);
            for (i = buttonsList.Count - 1; i >= 0; i--)
            {
                MySketch -= buttonsList[i].Draw;
                MyClick -= buttonsList[i].Click;
                buttonsList[i].Delete(buttonsList);
            }
            for (i = textBoxList.Count - 1; i >= 0; i--)
            {
                MyClick -= textBoxList[i].Click;//каждая кнопка подписана на событие
                MySketch -= textBoxList[i].Draw;
                Enter -= textBoxList[i].EnterSize;
                textBoxList[i].Delete(textBoxList);
            }
            buttonsList.Add(new Buttons(new myPoint(470, 490), 200, 60, "Назад"));
            MyClick += buttonsList[0].Click;
            MySketch += buttonsList[0].Draw;
            buttonsList[0].Activate += Menu;

            for(i = 0; i <logic.Size; i++)
                for (j = 0; j<logic.Size;j++)
                    buttonsList.Add(new Buttons(new myPoint(10 + i * (MyForm.Width - 40) / logic.Size, 20 + j * (MyForm.Height - 140) / logic.Size), (MyForm.Width - 40) / logic.Size, (MyForm.Height - 140) / logic.Size, logic.field[i * logic.Size + j].ToString(), i * logic.Size + j));
            for (i = 1; i < buttonsList.Count; i++)
            {
                MySketch += buttonsList[i].Draw;
                MyClick += buttonsList[i].Click;
                buttonsList[i].ActivateMark += ChangeSymbol;
            }

            PaintField();
            
            for (i = 0; i < Xbutt.Count; i++)
            {
                MySketch += Xbutt[i].Draw;
            }
           
            MyForm.Invalidate();
        }
        private void ChangeSymbol(int number, int type)     // меняем элемент списка под номером number на значение type
        {
            logic.field[number] = type;                 // меняем элемент списка под номером number на значение type
            logic.CheckGameOver();
            MySketch -= buttonsList[number + 1].Draw;   // обнуляем подписки кнопки, но НЕ УДАЛЯЕМ ЕЕ
            MyClick -= buttonsList[number + 1].Click;
            PaintField();
        }
        private void PaintField()
        {
            for (i = 0; i < logic.Size; i++)
            {
                for (j = 0; j < logic.Size; j++)
                {
                    switch (logic.field[i * logic.Size + j])
                    {
                        case 1:
                            {
                                Xbutt.Add(new XMark(new myPoint(10 + i * (MyForm.Width - 40) / logic.Size, 20 + j * (MyForm.Height - 140) / logic.Size), (MyForm.Width - 40) / logic.Size, (MyForm.Height - 140) / logic.Size));
                                MySketch += Xbutt[Xbutt.Count - 1].Draw;
                                break;
                            }
                        case 2:
                            {
                                Obutt.Add(new OMark(new myPoint(10 + i * (MyForm.Width - 40) / logic.Size, 20 + j * (MyForm.Height - 140) / logic.Size), (MyForm.Width - 40) / logic.Size, (MyForm.Height - 140) / logic.Size));
                                MySketch += Obutt[Obutt.Count - 1].Draw;
                                break;
                            }

                    }
                }
            }
            MyForm.Invalidate();
        }
        public void Instruction()
        {
            for (i = buttonsList.Count - 1; i >= 0; i--)
            {
                MySketch -= buttonsList[i].Draw;
                MyClick -= buttonsList[i].Click;
                buttonsList[i].Delete(buttonsList);
            }
            buttonsList.Add(new Buttons(new myPoint(350, 440), 180, 60, "Назад"));
            for (i = 0; i < buttonsList.Count; i++)
            {
                MyClick += buttonsList[i].Click;//каждая кнопка подписана на событие
                MySketch += buttonsList[i].Draw;
            }
            labelsList.Add(new Labels(new myPoint(200, 20), 40, 40, "Правила игры"));
            labelsList.Add(new Labels(new myPoint(20, 80), 40, 40, "Выиграйте компьютер собирая ряды из"));
            labelsList.Add(new Labels(new myPoint(10, 160), 40, 40, "3, 4, 5 крестиков или ноликов подряд. "));
            labelsList.Add(new Labels(new myPoint(10, 240), 40, 40, "Их количество зависит от уровня игры. "));
            labelsList.Add(new Labels(new myPoint(200, 320), 40, 40, "Успешной игры! "));

            for (i = 0; i < labelsList.Count; i++)
            {

                MySketch += labelsList[i].Draw;
            }
            buttonsList[0].Activate += Menu;
            MyForm.Invalidate();
        }
        public void Records()
        {
            for (i = buttonsList.Count - 1; i >= 0; i--)
            {
                MySketch -= buttonsList[i].Draw;
                MyClick -= buttonsList[i].Click;
                buttonsList[i].Delete(buttonsList);
            }
            buttonsList.Add(new Buttons(new myPoint(350, 440), 180, 60, "Назад"));
            for (i = 0; i < buttonsList.Count; i++)
            {
                MyClick += buttonsList[i].Click;//каждая кнопка подписана на событие
                MySketch += buttonsList[i].Draw;
            }
            buttonsList[0].Activate += Menu;
            MyForm.Invalidate();
        }
        public void Exit()
        {
            for (i = buttonsList.Count - 1; i >= 0; i--)
            {
                MySketch -= buttonsList[i].Draw;
                MyClick -= buttonsList[i].Click;
                buttonsList[i].Delete(buttonsList);
            }
            MyForm.Close();
        }
    }
}

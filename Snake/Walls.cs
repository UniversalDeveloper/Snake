using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Walls
    {
        static readonly int x = 80;
        static readonly int y = 26;
        private char ch;
        private List<Point> wall = new List<Point>();

        public List<Point> Wall
        {
            get
            {
                return wall;
            }
        }  // делаем список стен доступнім для использавания из вне
        // без возможности на прямую обратится  и изменить соостояние стен

        public Walls()// делаем конструктор без параметров для того чтобі
                      // можно было использовать экземпляр класса в любом месте проекта(получит список стен)
        {
            ch = '#';
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0, y);
            DrawVertical(x, y);
        }


        private void DrawHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Point p = (i, y, ch);
                p.Draw();
                wall.Add(p);
            }
        }
        private void DrawVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point p = (x, i, ch);
                p.Draw();
                wall.Add(p);
            }
        }
        
    }
}

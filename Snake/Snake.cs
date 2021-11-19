using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    class Snake
    {
        private List<Point> snake;
        private Direction direction;
        private int step = 1;
        private Point tail;
        private Point head;
        bool rotate = true;

        private List<Point> wallsOfGame = new List<Point>();
        private Walls walls = new Walls();

        public Snake(int x, int y, int length)
        {
            wallsOfGame = walls.Wall;// понадобится для сравнения столкновения голові змеи со стеной
            direction = Direction.RIGHT;//начальное направление движения змейки
            snake = new List<Point>();
            for (int i = x - length; i < x; i++)
            {
                Point p = (i, y, '*');
                snake.Add(p);
                p.Draw();
            }
        }
       
        //Методы движения и поворота в зависимости он направления движения змейки.
        public Point GetHead()
        {
            return snake.Last();
        }   //     public Point GetHead() => snake.Last();

        public Point GetNextPoint()
        {
            Point p = GetHead();
            switch (direction)
            {
                case Direction.LEFT:
                    p.x -= step;
                    break;
                case Direction.RIGHT:
                    p.x += step;
                    break;
                case Direction.UP:
                    p.y -= step;
                    break;
                case Direction.DOWN:
                    p.y += step;
                    break;
            }
            return p;
        }

        public void Move()
        {
            head = GetNextPoint();
            snake.Add(head);
            tail = snake.First();
            snake.Remove(tail);
            tail.Clear();
            head.Draw();
            rotate = true;
        }
        //нужен метод который будет стирать старую змею из списка змея созданого до столкновения при столкновении
        //со стеной или хвостом что бы  удалить из списка не нужные элементы и не переерасходовать память
        public void RemoveOlldSnake()
        {
            
            tail.Clear();
        }

        public void Rotation(ConsoleKey key)
        {
            if (rotate)
            {
                switch (direction)
                {
                    case Direction.LEFT:
                    case Direction.RIGHT:
                        if (key == ConsoleKey.DownArrow)
                            direction = Direction.DOWN;
                        else if (key == ConsoleKey.UpArrow)
                            direction = Direction.UP;
                        break;
                    case Direction.UP:
                    case Direction.DOWN:
                        if (key == ConsoleKey.LeftArrow)
                            direction = Direction.LEFT;
                        else if (key == ConsoleKey.RightArrow)
                            direction = Direction.RIGHT;
                        break;
                }
                rotate = false;
            }
        }
        public bool Eat(Point p)//методом проверки съела ли еду наша змейка, и сразу делаем ее длиннее.
        {
            head = GetNextPoint();
            if (head == p)
            {
                snake.Add(head);
                head.Draw();
                return true;
            }
            return false;
        }
        public bool IsHitBody(Point p)
        {
            for (int i = snake.Count - 2; i > 0; i--)
            {
                if (snake[i] == p)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsHitWalls(Point p)
        {
            foreach (var w in wallsOfGame)
            {
                if (p == w)
                {
                    return true;
                }
            }
            return false;

        }

    }
    }

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Snake
{
    class StartGame
    {
        private static readonly int x = 80;
        private static readonly int y = 26;

        private static Walls walls;
        private static Snake snake;
        private static FoodFactory foodFactory;

        public static void startGame()
        {
            Console.Clear();
            сreatGameEl();
            Stopwatch sw = new Stopwatch();//вычесляет точное время работы операции
            while (true)// главный цикл отвечающий за отрисовку перемещения змеи по полю
            {
                sw.Restart();

                while (sw.ElapsedMilliseconds <= 200)// проверка управления между кадрами была ли нажата клавиша поворота
                {
                    if (Console.KeyAvailable)// если указан поворот змея поворачивае в указаннам
                                             // напровлении в противном случае она движется по заданной траектории
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        snake.Rotation(key.Key);
                    }
                }
                if (snake.Eat(foodFactory.food))//еслт змея сьела еду
                {
                    foodFactory.CreateFood();//создаем новую еду
                }
                snake.Move();// в бесконечном цикле наша змея постоянно движется по указанной траекторие

                //условие для гейм овер
                if (snake.IsHitWalls(snake.GetHead()) || snake.IsHitBody(snake.GetHead()))
                {
                    break;
                }
            }
            snake.RemoveOlldSnake();//очистить змею
            Console.WriteLine("вася");// сообщить игроку о проигеше
        }


        public static void сreatGameEl()
        {
            Console.SetWindowSize(x + 1, y + 1);
            Console.SetBufferSize(x + 1, y + 1);
            Console.CursorVisible = false;

            walls = new Walls();
            snake = new Snake(x / 2, y / 2, 3);
            foodFactory = new FoodFactory(x, y, '@');
            foodFactory.CreateFood();


        }

    }
}

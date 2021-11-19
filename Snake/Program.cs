using System;
using System.Diagnostics;
using System.Threading;

namespace Snake
{
    class Program
    {
       
        static void Main()
        {
           
               while (true)// бесконечній цикл віполняющий главную логику двидения змеии
               {
                StartGame.startGame();
                  // startGame();
                   Thread.Sleep(1000);// авто перезапуск игры при проигреше
                 //  Console.ReadKey();//после нажатия на любую кнопку ига запускается заново второй вариант перезапуска игры с помощью клавы

               }

            
        }
      
    }
}


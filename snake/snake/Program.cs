 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {

            // создаем границы консоли Arkasha
            Console.SetBufferSize(80, 25);

            // отрисовка рамочки
            HorizontalLine Topline = new HorizontalLine(0, 78, 0, '+');
            VerticalLine Leftline = new VerticalLine(0, 24, 0, '+');
            HorizontalLine Downline = new HorizontalLine(0, 78, 24, '+');
            VerticalLine Rightline = new VerticalLine(0, 24, 78, '+');
            Topline.Draw();
            Leftline.Draw();
            Downline.Draw();
            Rightline.Draw();

            //отрисовка точек
            Point p = new Point(10, 10, '*');
            Snake snake = new Snake(p, 3, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                } 
            }
   
        }

    }

}

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

            Walls walls = new Walls(80, 25);
            walls.Draw();


            //отрисовка точек
            Point p = new Point(10, 10, '*');
            Snake snake = new Snake(p, 3, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
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
            WriteGameOver();
            Console.ReadLine();
        }
        static void WriteGameOver()
        {
            int xOffset = 21;
            int yOffset = 7;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("====================================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 5, yOffset++);
            yOffset++;
            WriteText("Авторы: Аркадий и Евгения", xOffset + 6, yOffset++);
            WriteText("Брюховецкие", xOffset + 13, yOffset++);
            yOffset++;
            WriteText("Я люблю тебя как змейка любит кушать", xOffset, yOffset++);
            WriteText("====================================", xOffset, yOffset++);


        }
        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);

        }
    }
}

 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {

            //// создаем границы консоли Akelaina
            // Console.SetBufferSize(80, 20);
            
            // создаем границы консоли Arkasha
            Console.SetBufferSize(120, 30);

            // отрисовка рамочки
            HorizontalLine Topline = new HorizontalLine(0, 78, 0, '+');
            VerticalLine Leftline = new VerticalLine(0, 24, 0, '+');
            HorizontalLine Downline = new HorizontalLine(0, 78, 24, '+');
            VerticalLine Rightline = new VerticalLine(0, 24, 78, '+');
            Topline.Drow();
            Leftline.Drow();
            Downline.Drow();
            Rightline.Drow();

            //отрисовка точек
            Point p = new Point(7, 7, '*');
            p.Draw();


            Console.ReadKey();
        }



    }

}

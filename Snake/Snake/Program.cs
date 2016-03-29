using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Point p1 = new Point(1, 3, '*');
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            p2.Draw();

            HorizontalLine lineH = new HorizontalLine(3, 10, 3, '+');
            lineH.Draw();

            VerticalLine lineV = new VerticalLine(3, 10, 3, '-');
            lineV.Draw();

            Console.ReadLine();
        }
    }
}

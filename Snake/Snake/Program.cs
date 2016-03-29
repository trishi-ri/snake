using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetBufferSize(80, 25);

            //frames
            HorizontalLine upF = new HorizontalLine(0, 78, 0, '+');
            upF.Draw();
            HorizontalLine downF = new HorizontalLine(0, 78, 24, '+');
            downF.Draw();
            VerticalLine leftF = new VerticalLine(0, 24, 0, '+');
            leftF.Draw();
            VerticalLine rightF = new VerticalLine(0, 24, 78, '+');
            rightF.Draw();

            Console.ReadLine();
        }
    }
}

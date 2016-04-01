using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetBufferSize(80, 25);

            //frames
            HorizontalLine upF = new HorizontalLine(0, 78, 0, '+');
            Draw(upF);
            HorizontalLine downF = new HorizontalLine(0, 78, 24, '+');
            Draw(downF);
            VerticalLine leftF = new VerticalLine(0, 24, 0, '+');
            Draw(leftF);
            VerticalLine rightF = new VerticalLine(0, 24, 78, '+');
            Draw(rightF);

            //points
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            Draw(snake);

            FoodCreator foodCreator = new FoodCreator(80, 25, '@');
            Point food = foodCreator.CreateFood();

            while (true)
            {
                if (snake.Eat(food))
                    food = foodCreator.CreateFood();
                else
                    snake.Move();

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

            }
        }

        static void Draw(Figure figure)
        {
            figure.Draw();
        }
    }
}

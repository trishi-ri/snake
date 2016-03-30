using System;
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
            upF.Draw();
            HorizontalLine downF = new HorizontalLine(0, 78, 24, '+');
            downF.Draw();
            VerticalLine leftF = new VerticalLine(0, 24, 0, '+');
            leftF.Draw();
            VerticalLine rightF = new VerticalLine(0, 24, 78, '+');
            rightF.Draw();

            //points
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
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
                    //if (key.Key == ConsoleKey.S)
                    //    break;
                    snake.HandleKey(key.Key);
                }
                
            }

            //Console.ReadLine();
        }
    }
}

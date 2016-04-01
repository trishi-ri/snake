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

            Walls walls = new Walls(80, 25);
            walls.Draw();

            //points
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            Draw(snake);

            FoodCreator foodCreator = new FoodCreator(80, 25, '@');
            Point food = foodCreator.CreateFood();
            foodCreator.Draw(food);

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTile())
                    break;

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    foodCreator.Draw(food);
                }
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

using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetBufferSize(80, 25);

            int start_length = 4;
            int max_length = start_length;
            int count_games = 0;
            int snake_length;
            do
            {
                count_games++;
                snake_length = NewGame(start_length);
                if (snake_length > max_length)
                    max_length = snake_length;

            }
            while (WriteGameOver(snake_length, max_length, count_games) == "");

        }

        static int NewGame(int start_length)
        {
            Console.Clear();
            Walls walls = new Walls(80, 25);
            walls.Draw();

            //points
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, start_length, Direction.RIGHT);
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
            return snake.Length();
        }

        static string WriteGameOver(int snake_length, int max_length, int count_games)
        {
            int xOffset = 20;
            int yOffset = 6;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("==========================================", xOffset, yOffset++);
            WriteText("К О Н Е Ц    И Г Р Ы", xOffset + 10, yOffset++);
            yOffset++;
            WriteText("номер игры в сесии: " + count_games, xOffset + 2, yOffset++);
            WriteText("длина змейки в последней игре: " + snake_length, xOffset + 2, yOffset++);
            WriteText("максимальная длина змейки в сессии: " + max_length, xOffset + 2, yOffset++);
            yOffset++;
            WriteText("начать новую игру - Enter", xOffset + 2, yOffset++);
            WriteText("==========================================", xOffset, yOffset++);
            return Console.ReadLine();

        }

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        static void Draw(Figure figure)
        {
            figure.Draw();
        }
    }
}

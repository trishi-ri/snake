﻿using System;

namespace Snake
{
    class FoodCreator
    {

        int mapWidth;
        int mapHeight;
        char sym;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            Point food = new Point(x, y, sym);
            Console.ForegroundColor = ConsoleColor.Red;
            food.Draw();
            Console.ForegroundColor = ConsoleColor.White;
            return food;
        }
    }
}

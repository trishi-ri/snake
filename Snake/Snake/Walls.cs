using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;
        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            HorizontalLine upF = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine downF = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftF = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine rightF = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            wallList.Add(upF);
            wallList.Add(downF);
            wallList.Add(leftF);
            wallList.Add(rightF);

        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                    return true;
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                wall.Draw();
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

    }
}

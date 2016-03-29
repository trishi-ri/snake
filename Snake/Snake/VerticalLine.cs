using System.Collections.Generic;

namespace Snake
{
    class VerticalLine
    {

        List<Point> pList;

        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }

        }

        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

    }
}

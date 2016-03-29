﻿using System.Collections.Generic;

namespace Snake
{
    class Figure
    {

        protected List<Point> pList;

        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

    }
}

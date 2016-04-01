﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;

        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            Draw(head);
        }

        private Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;

        }

        internal bool IsHitTile()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                Draw(food);
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }

        private void Draw(Point ps)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ps.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            base.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

using System.Collections.Generic;

namespace SnakeGame
{
    class Snake
    {
        public List<Point> Body { get; private set; } = new List<Point>();
        public Point? LastTail { get; private set; }
        public Point Head => Body[0];

        public Snake()
        {
            Body.Add(new Point(Config.Width / 2, Config.Height / 2));
        }

        public void Move(Direction dir, bool grow = false)
        {
            Point newHead = Head;

            switch (dir)
            {
            case Direction.Up: newHead = new Point(Head.X, Head.Y - 1); break;
            case Direction.Down: newHead = new Point(Head.X, Head.Y + 1); break;
            case Direction.Left: newHead = new Point(Head.X - 1, Head.Y); break;
            case Direction.Right: newHead = new Point(Head.X + 1, Head.Y); break;
            }

            Body.Insert(0, newHead);

            if (!grow)
            {
                LastTail = Body[Body.Count - 1];
                Body.RemoveAt(Body.Count - 1);
            }
            else
            {
                LastTail = null;
            }
        }

        public void Grow()
        {
            Body.Add(Body[Body.Count - 1]);
        }

        public bool IsHitWall()
        {
            return Head.X <= 0 || Head.Y <= 0 || Head.X >= Config.Width - 1 || Head.Y >= Config.Height - 1;
        }

        public bool IsHitSelf()
        {
            for (int i = 1; i < Body.Count; i++)
                if (Head.Equals(Body[i]))
                    return true;
            return false;
        }
    }
}

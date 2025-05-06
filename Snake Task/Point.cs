namespace SnakeGame
{
    struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y) { X = x; Y = y; }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point p = (Point)obj;
                return p.X == X && p.Y == Y;
            }
            return false;
        }

        public override int GetHashCode() => (X, Y).GetHashCode();
    }
}

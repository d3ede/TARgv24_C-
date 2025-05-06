namespace SnakeGame
{
    public static class Config
    {
        public const int Width = 40;
        public const int Height = 20;

        public const int LogicSpeed = 5; // 1–10, 10 - very fast
        public static int Speed => 300 - LogicSpeed * 25; // ms/frame (less is faster)
    }
}

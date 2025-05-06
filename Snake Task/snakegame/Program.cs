using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            while (true)
            {
                Game game = new Game();
                game.Run();

                Console.SetCursorPosition(0, Config.Height + 1);
                Console.WriteLine("Press Enter for restart or Escape for exit...");

                ConsoleKey key;
                do
                {
                    key = Console.ReadKey(true).Key;
                } while (key != ConsoleKey.Enter && key != ConsoleKey.Escape);

                if (key == ConsoleKey.Escape)
                    break;

                Console.Clear();
            }
        }
    }

    public static class Config
    {
        public const int Width = 40;
        public const int Height = 20;

        public const int LogicSpeed = 5; // 1–10, 10 - very fast
        public static int Speed => 300 - LogicSpeed * 25; // ms/frame (less is faster)
    }
}

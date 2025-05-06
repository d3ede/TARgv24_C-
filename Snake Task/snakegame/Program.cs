using System;

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
}

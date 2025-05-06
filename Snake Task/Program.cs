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

    class Game
    {
        private Snake snake;
        private Point food;
        private Direction currentDirection = Direction.Right;
        private bool gameOver = false;
        private SoundPlayer eatSound = new SoundPlayer("eat.wav");
        private SoundPlayer deadSound = new SoundPlayer("dead.wav");
        private SoundPlayer bgMusic = new SoundPlayer("bg.wav");

        private int score = 0;
        private const string scoreFile = "scores.txt";

        private void SaveScore()
        {
            Console.SetCursorPosition(0, Config.Height + 1);
            Console.Write("Enter your name: ");
            string name = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(name))
                name = "Anonymous";

            string line = $"{name} : {score}";
            try
            {
                File.AppendAllText(scoreFile, line + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save score: {ex.Message}");
            }
        }

        public void Run()
        {
            snake = new Snake();
            DrawBorder();
            GenerateFood();

            bgMusic.Play();

            Thread inputThread = new Thread(ReadInput);
            inputThread.Start();

            while (!gameOver)
            {
                bool grow = false;

                if (snake.Head.Equals(food))
                {
                    score++;
                    new Thread(() =>
                    {
                        eatSound.PlaySync();
                        bgMusic.Play();
                    }).Start();

                    GenerateFood();
                    grow = true;
                }

                snake.Move(currentDirection, grow);

                if (snake.IsHitWall() || snake.IsHitSelf())
                {
                    gameOver = true;
                    bgMusic.Stop();
                    deadSound.Play();
                    break;
                }

                Draw();
                Thread.Sleep(Config.Speed);
            }

            Console.SetCursorPosition(0, Config.Height);
            Console.WriteLine($"Game Over! Final score: {score}");
            SaveScore();
        }

        private void ReadInput()
        {
            while (!gameOver)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                    case ConsoleKey.UpArrow:
                        if (currentDirection != Direction.Down)
                            currentDirection = Direction.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentDirection != Direction.Up)
                            currentDirection = Direction.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currentDirection != Direction.Right)
                            currentDirection = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentDirection != Direction.Left)
                            currentDirection = Direction.Right;
                        break;
                    }
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }

        private void GenerateFood()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, Config.Width - 1);
            int y = rnd.Next(1, Config.Height - 1);
            food = new Point(x, y);
        }

        private void Draw()
        {
            // score
            Console.SetCursorPosition(2, Config.Height);
            Console.Write($"Score: {score}");

            // clear the tail
            if (snake.LastTail.HasValue)
            {
                Console.SetCursorPosition(snake.LastTail.Value.X, snake.LastTail.Value.Y);
                Console.Write(' ');
            }

            // food
            Console.SetCursorPosition(food.X, food.Y);
            Console.Write('O');

            // head
            var head = snake.Head;
            Console.SetCursorPosition(head.X, head.Y);
            Console.Write('#');
        }

        private void DrawBorder()
        {
            for (int x = 0; x < Config.Width; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write('-');
                Console.SetCursorPosition(x, Config.Height - 1);
                Console.Write('-');
            }

            for (int y = 0; y < Config.Height; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write('|');
                Console.SetCursorPosition(Config.Width - 1, y);
                Console.Write('|');
            }

            Console.SetCursorPosition(0, 0);
            Console.Write('+');
            Console.SetCursorPosition(Config.Width - 1, 0);
            Console.Write('+');
            Console.SetCursorPosition(0, Config.Height - 1);
            Console.Write('+');
            Console.SetCursorPosition(Config.Width - 1, Config.Height - 1);
            Console.Write('+');
        }
    }

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

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}

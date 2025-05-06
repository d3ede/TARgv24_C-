using NAudio.Wave;
using System.Threading;

class Game
{
    private Snake snake;
    private Point food;
    private Direction currentDirection = Direction.Right;
    private bool gameOver = false;

    private WaveOutEvent bgPlayer;
    private AudioFileReader bgMusic;

    private string eatSoundPath = "eat.wav";
    private string deadSoundPath = "dead.wav";
    private string bgMusicPath = "bg.wav";

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

        // запуск фоновой музыки
        bgMusic = new AudioFileReader(bgMusicPath);
        bgPlayer = new WaveOutEvent();
        bgPlayer.Init(bgMusic);
        bgPlayer.Play();

        Thread inputThread = new Thread(ReadInput);
        inputThread.Start();

        while (!gameOver)
        {
            bool grow = false;

            if (snake.Head.Equals(food))
            {
                score++;
                PlayOneShot(eatSoundPath);
                GenerateFood();
                grow = true;
            }

            snake.Move(currentDirection, grow);

            if (snake.IsHitWall() || snake.IsHitSelf())
            {
                gameOver = true;
                bgPlayer.Stop();
                PlayOneShot(deadSoundPath);
                break;
            }

            Draw();
            Thread.Sleep(Config.Speed);
        }

        Console.SetCursorPosition(0, Config.Height);
        Console.WriteLine($"Game Over! Final score: {score}");
        SaveScore();

        bgMusic?.Dispose();
        bgPlayer?.Dispose();
    }

    private void PlayOneShot(string file)
    {
        new Thread(() =>
        {
            using var audioFile = new AudioFileReader(file);
            using var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(10);
            }
        }).Start();
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
        Console.SetCursorPosition(2, Config.Height);
        Console.Write($"Score: {score}");

        if (snake.LastTail.HasValue)
        {
            Console.SetCursorPosition(snake.LastTail.Value.X, snake.LastTail.Value.Y);
            Console.Write(' ');
        }

        Console.SetCursorPosition(food.X, food.Y);
        Console.Write('O');

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
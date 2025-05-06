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
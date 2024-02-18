using snake.bl;

namespace snake;
class Program
{
    /// <summary>
    /// Snake's speed.
    /// </summary>
    /// <remarks>
    /// 1 - lowest speed, 5 - highest.
    /// </remarks>
    private static int _speed = 5;

    static void Main()
    {
        var initialDirection = Direction.Left;
        var app = Initialize(initialDirection);
        Run(app, initialDirection);
    }

    private static SnakeApp Initialize(Direction initialDirection)
    {
        var field = new Field(15, 15);
        var snake = new Snake(field, initialDirection, 9);

        var app = new SnakeApp(snake);
        return app;
    }

    private static void Run(SnakeApp app, Direction initialDirection)
    {
        Console.CursorVisible = false;
        var threadSleepValue = 1100 - (_speed * 200);
        var snake = app.GetSnake(initialDirection);
        var currentDirection = initialDirection;
        var snakePrinter = new SnakePrinter();
        var autoResetEvent = new AutoResetEvent(false);
        var snakeThread = new Thread(() =>
        {
            do
            {
                autoResetEvent.Set();
                Thread.Sleep(threadSleepValue);
                snake = app.GetSnake(currentDirection);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(currentDirection.ToString());
                snakePrinter.Print(snake);
            } while (true);
        });

        var keyThread = new Thread(() =>
        {
            while (true)
            {
                autoResetEvent.WaitOne();
                var direction = GetCurrentDirection();
                if (direction != null)
                    currentDirection = (Direction)direction;
                
            }
        });
        snakeThread.Start();
        keyThread.Start();
    }
    private static Direction? GetCurrentDirection()
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.W:
                return Direction.Up;
            case ConsoleKey.A:
                return Direction.Left;
            case ConsoleKey.S:
                return Direction.Down;
            case ConsoleKey.D:
                return Direction.Right;
            default:
                return null;
        }
    }
}

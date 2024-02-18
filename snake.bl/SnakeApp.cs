namespace snake.bl;

public class SnakeApp
{
    private Snake _snake;
    private int[,] _fieldArray;

    public SnakeApp(Snake snake)
    {
        _snake = snake;
    }

    public Snake GetSnake(Direction direction)
    {
        _snake.Direction = direction;
        var field = _snake.Field;
        _fieldArray = field.FieldArray;

        var tailVerticalIndex = 0;
        var tailHorizontalIndex = 0;
        var tail = 0;
        List<(int x, int y)> emptyIndicies = new List<(int x, int y)> ();

        for (var i = 0; i < field.VerticalSize; i++)
        {
            for (var j = 0; j < field.HorizontalSize; j++)
            {
                if (_fieldArray[i, j] == 0)
                {
                    emptyIndicies.Add((i, j));
                    continue;
                }
                if (_fieldArray[i, j] != -1)
                    _fieldArray[i, j]++;

                if (_fieldArray[i, j] > tail)
                {
                    tail = _fieldArray[i, j];
                    tailVerticalIndex = i;
                    tailHorizontalIndex = j;
                    continue;
                }
            }
        }

        SetHead(direction, out var wasAppleEaten);
        if (!wasAppleEaten)
        {
            _snake.TailHorizontalIndex = tailHorizontalIndex;
            _snake.TailVerticalIndex = tailVerticalIndex;
            _fieldArray[tailVerticalIndex, tailHorizontalIndex] = 0;
            return _snake;
        }
        var appleCorrds = GetAppleCoords(emptyIndicies);
        _fieldArray[appleCorrds.x,appleCorrds.y] = -1;

        return _snake;
    }

    private static (int x, int y) GetAppleCoords(List<(int x, int y)> emptyIndicies)
    {
        var random = new Random();
        return emptyIndicies[random.Next(0, emptyIndicies.Count - 1)];
    }

    private void SetHead(Direction direction, out bool wasAppleEaten)
    {
        wasAppleEaten = true;
        switch (direction)
        {
            case Direction.Up:
                wasAppleEaten = IsApple(_fieldArray[--_snake.HeadVerticalIndex, _snake.HeadHorizontalIndex]);
                _fieldArray[_snake.HeadVerticalIndex, _snake.HeadHorizontalIndex] = 1;
                break;
            case Direction.Down:
                wasAppleEaten = IsApple(_fieldArray[++_snake.HeadVerticalIndex, _snake.HeadHorizontalIndex]);
                _fieldArray[_snake.HeadVerticalIndex, _snake.HeadHorizontalIndex] = 1;
                break;
            case Direction.Right:
                wasAppleEaten = IsApple(_fieldArray[_snake.HeadVerticalIndex, ++_snake.HeadHorizontalIndex]);
                _fieldArray[_snake.HeadVerticalIndex, _snake.HeadHorizontalIndex] = 1;
                break;
            case Direction.Left:
                wasAppleEaten = IsApple(_fieldArray[_snake.HeadVerticalIndex, --_snake.HeadHorizontalIndex]);
                _fieldArray[_snake.HeadVerticalIndex, _snake.HeadHorizontalIndex] = 1;
                break;
            case Direction.None:
            default:
                break;
        }
    }
    private bool IsApple(int maybeApple)
    {
        return maybeApple == -1;
    }
}
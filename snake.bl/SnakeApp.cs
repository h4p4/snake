namespace snake.bl;

public class SnakeApp
{
    private Snake _snake;

    public SnakeApp(Snake snake)
    {
        _snake = snake;
    }

    public Snake GetSnake(Direction direction)
    {
        _snake.Direction = direction;
        var field = _snake.Field;
        var fieldArray = field.FieldArray;

        var tailVerticalIndex = 0;
        var tailHorizontalIndex = 0;
        var tail = 0;
        for (var i = 0; i < field.VerticalSize - 1; i++)
        {
            for (var j = 0; j < field.HorizontalSize - 1; j++)
            {
                if (fieldArray[i, j] != 0)
                {
                    fieldArray[i, j]++;
                    if (fieldArray[i, j] > tail)
                    {
                        tail = fieldArray[i, j];
                        tailVerticalIndex = i; 
                        tailHorizontalIndex = j;
                    }
                }
            }
        }
        fieldArray[tailVerticalIndex, tailHorizontalIndex] = 0;

        switch (direction)
        {
            case Direction.Up:
                fieldArray[--_snake.HeadVerticalIndex, _snake.HeadHorizontalIndex] = 1;
                break;
            case Direction.Down:
                fieldArray[++_snake.HeadVerticalIndex, _snake.HeadHorizontalIndex] = 1;
                break;
            case Direction.Right:
                fieldArray[_snake.HeadVerticalIndex, ++_snake.HeadHorizontalIndex] = 1;
                break;
            case Direction.Left:
                fieldArray[_snake.HeadVerticalIndex, --_snake.HeadHorizontalIndex] = 1;
                break;
            case Direction.None:
            default:
                break;
        }
        

        return _snake;
    }
}
using snake.bl;

namespace snake
{
    internal class SnakePrinter
    {
        internal void Print(Snake snake)
        {
            var field = snake.Field;
            for (int i = 0; i < field.VerticalSize - 1; i++)
            {
                for(int j = 0; j < field.HorizontalSize - 1; j++)
                {
                    var symbol = GetSymbol(field.FieldArray[i,j], snake.Direction);
                    Console.Write($"{symbol} ");
                }
                Console.Write("\n");
            }
        }
        private char GetSymbol(int number, Direction direction)
        {
            if (number == 0)
                return SnakeConstants.EMPTY_SIGN;
            if (number == 1)
                return GetHeadSymbol(direction);
            if (number == -1)
                return SnakeConstants.APPLE_SIGN;
            
            return SnakeConstants.BODY_SIGN;
        }

        private char GetHeadSymbol(Direction direction)
        {
            if (direction == Direction.Up)
                return SnakeConstants.HEAD_UP_SIGN;
            if (direction == Direction.Down)
                return SnakeConstants.HEAD_DOWN_SIGN;
            if (direction == Direction.Left)
                return SnakeConstants.HEAD_LEFT_SIGN;
            if (direction == Direction.Right)
                return SnakeConstants.HEAD_RIGHT_SIGN;
            return '0';
        }
    }
}
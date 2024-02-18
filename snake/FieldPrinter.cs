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
                    Console.ForegroundColor = GetColor(symbol);
                    //Console.Write($"{field.FieldArray[i, j]} ");
                    Console.Write($"{symbol} ");
                }
                Console.Write("\n");
            }
        }
        private ConsoleColor GetColor(char symbol)
        {
            if (symbol == SnakeConstants.EMPTY_SIGN)
                return ConsoleColor.Gray;
            if (symbol == SnakeConstants.APPLE_SIGN)
                return ConsoleColor.Red;
            if (symbol == SnakeConstants.BODY_SIGN)
                return ConsoleColor.Green;
            if (symbol == SnakeConstants.HEAD_UP_SIGN ||
                symbol == SnakeConstants.HEAD_RIGHT_SIGN ||
                symbol == SnakeConstants.HEAD_DOWN_SIGN ||
                symbol == SnakeConstants.HEAD_LEFT_SIGN)
                return ConsoleColor.DarkGreen;
            return ConsoleColor.White;
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
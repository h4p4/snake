namespace snake.bl
{
    public class Snake
    {
        public Snake(Field field, Direction initialDirection, int initialSize)
        {
            Field = field;
            HeadHorizontalIndex = field.HorizontalSize / 2;
            HeadVerticalIndex = field.VerticalSize / 2;
            SnakeSize = initialSize;

            if (initialDirection == Direction.Left)
            {
                TailVerticalIndex = HeadVerticalIndex;
                TailHorizontalIndex = HeadHorizontalIndex - initialSize;

                for (int i = TailHorizontalIndex, snakeIndex = 1; 
                    i < HeadHorizontalIndex; i++, snakeIndex++)
                {
                    Field.FieldArray[HeadVerticalIndex, i] = snakeIndex;
                }
                return;
            }
            var errorMessage = $"Изначальное направление {initialDirection} не реализовано.";
            throw new NotImplementedException(errorMessage);
        }

        public Direction Direction { get; set; }
        public int HeadVerticalIndex { get; set; }
        public int HeadHorizontalIndex { get; set; }
        public int TailVerticalIndex { get; set; }
        public int TailHorizontalIndex { get; set; }
        public int SnakeSize { get; set; }
        public Field Field { get; }
    }
}

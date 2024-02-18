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
                TailHorizontalIndex = HeadHorizontalIndex - 1;
                Field.FieldArray[TailVerticalIndex - 2, TailHorizontalIndex - 2] = -1;
                var snakeNumber = 1;
                //for (int i = TailHorizontalIndex; i > HeadHorizontalIndex; i--)
                //{
                //    Field.FieldArray[TailVerticalIndex, TailHorizontalIndex] = snakeNumber++;
                //}
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

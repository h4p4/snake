namespace snake.bl
{
    public class Field
    {
        public Field(int horizontalSize, int verticalSize)
        {
            HorizontalSize = horizontalSize;
            VerticalSize = verticalSize;
            FieldArray = new int[VerticalSize, HorizontalSize];
        }
        public int VerticalSize { get; }
        public int HorizontalSize { get; }
        public int[,] FieldArray { get; }
    }
}

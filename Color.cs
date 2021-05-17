namespace Task_2
{
    public enum Color
    {
        Black,
        White,
        None
    }

    public static class ColorExtensions
    {
        public static Color InvertColor(this Color color)
        {
            if (color == Color.None)
                return Color.None;

            return color == Color.Black ? Color.White : Color.Black;
        }
    }
}
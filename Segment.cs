namespace BeetrootHomework
{
    public struct Segment
    {
        private const char segmentChar = 'O';

        public Segment(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public int X { get; }
        public int Y { get; }

        public ConsoleColor Color { get; }

        public void DrawSegment()
        {
            Console.ForegroundColor = Color;

            Console.SetCursorPosition(X, Y);

            Console.Write(segmentChar);
        }

        public void ClearSegment()
        {
            Console.SetCursorPosition(X, Y);

            Console.Write(' ');
        }
    }
}

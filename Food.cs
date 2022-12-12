namespace BeetrootHomework
{
    public struct Food
    {
        private const char foodChar = '@';

        private static readonly Random random = new();

        private ConsoleColor foodColor = ConsoleColor.Red;

        public Food()
        {
            X = random.Next(1, GameFlow.MapWidth - 2);
            Y = random.Next(1, GameFlow.MapHeight - 2);
            Color = foodColor;
        }

        public int X { get; }
        public int Y { get; }

        public ConsoleColor Color { get; }

        public void DrawFood()
        {
            Console.ForegroundColor = Color;

            Console.SetCursorPosition(X, Y);

            Console.Write(foodChar);
        }

        public void ClearFood()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}

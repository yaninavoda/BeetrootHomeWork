namespace BeetrootHomework
{
    public class Snake
    {
        private readonly ConsoleColor _headColor = ConsoleColor.DarkCyan;
        private readonly ConsoleColor _tailColor = ConsoleColor.Cyan;

        public Segment Head { get; set; }
        public Queue<Segment> Tail { get; } = new();

        public Snake(
            int initialX,
            int initialY,
            int tailLength = 2)
        {
            Head = new Segment(initialX, initialY, _headColor);

            for (int i = tailLength; i >= 0; i--)
            {
                Tail.Enqueue(new Segment(Head.X - i - 1, initialY, _tailColor));
            }

            DrawSnake();
        }

        public void Move(Direction direction, bool eat = false)
        {
            ClearSnake();

            Tail.Enqueue(new Segment(Head.X, Head.Y, _tailColor));

            if (eat == false)
            {
                Tail.Dequeue();
            }

            Head = direction switch
            {
                Direction.Up => new Segment(Head.X, Head.Y - 1, _headColor),
                Direction.Down => new Segment(Head.X, Head.Y + 1, _headColor),
                Direction.Left => new Segment(Head.X - 1, Head.Y, _headColor),
                Direction.Right => new Segment(Head.X + 1, Head.Y, _headColor),
                _ => Head
            };

            DrawSnake();
        }

        public void DrawSnake()
        {
            Head.DrawSegment();

            foreach (Segment seg in Tail)
            {
                seg.DrawSegment();
            }
        }

        public void ClearSnake()
        {
            Head.ClearSegment();

            foreach (Segment seg in Tail)
            {
                seg.ClearSegment();
            }
        }
    }
}

using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace BeetrootHomework
{
    public class GameFlow
    {
        public const int MapWidth = 30;
        public const int MapHeight = 20;
        private const ConsoleColor borderColor = ConsoleColor.Gray;

        private const int FrameMs = 200;

        public Snake Snake { get; set; }
        public Direction Direction { get; set; }
        public Food Food { get; set; }
        public int Score { get; set; }
        public GameFlow()
        {
            Snake = new Snake(MapWidth / 2, MapHeight / 2);
            Direction = Direction.Right;
            Food = GenerateNewFood();
            Score = 0;

            InitializeGameField();
        }

        public static void InitializeGameField()
        {
            Console.SetWindowSize(MapWidth, MapHeight);
            Console.SetBufferSize(MapWidth, MapHeight);
            Console.OutputEncoding = Encoding.UTF8;

            Console.CursorVisible = false;

            DrawBorder();
        }

        public static void DrawBorder()
        {
            for (int i = 0; i < MapWidth; i++)
            {
                new Segment(x: i, y: 0, borderColor).DrawSegment();
                new Segment(x: i, y: MapHeight - 1, borderColor).DrawSegment();
            }

            for (int i = 0; i < MapHeight; i++)
            {
                new Segment(x: 0, y: i, borderColor).DrawSegment();
                new Segment(x: MapWidth - 1, y: i, borderColor).DrawSegment();
            }
        }

        public void StartGame()
        {
            Console.Clear();
            DrawBorder();

            Food = GenerateNewFood();
            Food.DrawFood();

            var sw = new Stopwatch();

            while (true)
            {
                sw.Restart();

                Direction previousDirection = Direction;

                while (sw.ElapsedMilliseconds <= FrameMs)
                {
                    if (previousDirection == Direction)
                    {
                        Direction = ReadDirection(Direction);
                    }
                }

                bool foodEaten = IsFoodEaten();

                if (foodEaten)
                {
                    Snake.Move(Direction, true);

                    Score++;

                    Food = new();
                    do
                    {
                        Food = new();

                    } while (Food.X == Snake.Head.X && Food.Y == Snake.Head.Y
                            || Snake.Tail.Any(seg => seg.X == Food.X && seg.Y == Food.Y));

                    Food.DrawFood();
                }
                else
                {
                    Snake.Move(Direction);
                }

                if (IsHitBorder() || IsHitTail())
                {
                    break;
                }
            }

            GameOver();
        }

        public static Direction ReadDirection(Direction currentDirection)
        {
            if (!Console.KeyAvailable) return currentDirection;

            ConsoleKey key = Console.ReadKey(true).Key;

            currentDirection = key switch
            {
                ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.W when currentDirection != Direction.Down => Direction.Up,

                ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.S when currentDirection != Direction.Up => Direction.Down,

                ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.A when currentDirection != Direction.Right => Direction.Left,

                ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
                ConsoleKey.D when currentDirection != Direction.Left => Direction.Right,

                _ => currentDirection
            };

            return currentDirection;
        }
        public void GameOver()
        {
            Snake.ClearSnake();
            Food.ClearFood();

            Console.SetCursorPosition(MapWidth / 3, MapHeight / 2);
            Console.WriteLine("GAME OVER");

            Console.SetCursorPosition(MapWidth / 3 - 3, MapHeight / 2 + 2);
            Console.WriteLine($"Your score is: {Score}");

        }

        public bool IsFoodEaten()
        {
            return Snake.Head.X == Food.X && Snake.Head.Y == Food.Y;
        }

        public bool IsHitBorder()
        {
            return Snake.Head.X == 0 ||
                    Snake.Head.X == MapWidth - 1 ||
                    Snake.Head.Y == 0 ||
                    Snake.Head.Y == MapHeight - 1;
        }

        public bool IsHitTail()
        {
            return Snake.Tail.Any(t => t.X == Snake.Head.X && t.Y == Snake.Head.Y);
        }

        public bool IsFoodGeneratedInSnake()
        {
            var foodGeneratedInHead = Snake.Head.X == Food.X && Snake.Head.Y == Food.Y;

            var foodGeneratedInTail = Snake.Tail.Any(t => t.X == Food.X) &&
                Snake.Tail.Any(t => t.Y == Food.Y);

            return foodGeneratedInHead || foodGeneratedInTail;

        }

        private Food GenerateNewFood()
        {
            Food food;
            do
            {
                food = new Food();

            } while (IsFoodGeneratedInSnake());

            return food;
        }
    }
}

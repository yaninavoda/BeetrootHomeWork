namespace BeetrootHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var gameFlow = new GameFlow();

                gameFlow.StartGame();

                Console.ReadKey();
            }
        }
    }
}
namespace BeetrootHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            // I recommend to change console font to raster font 8*8
            while (true)
            {
                var gameFlow = new GameFlow();

                gameFlow.StartGame();

                Console.ReadKey();
            }
        }
    }
}
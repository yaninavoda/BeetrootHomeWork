namespace BeetrootHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int X = 5;
            int Y = 2;
            int sum = 0;
            int smaller;
            int greater;

            if (X <= Y)
            {
                smaller = X;
                greater = Y;
            }
            else
            {
                smaller = Y;
                greater = X;
            }

            while (smaller <= greater)
            {
                sum += smaller;
                smaller++;
            }
            Console.WriteLine($"The sum of numbers between {(X <= Y ? X : Y)} and {greater} is {sum}.");

            Console.WriteLine();

            int number1;
            int number2;

            #region TryParse
            Console.WriteLine("Enter an integer number: ");
            if (int.TryParse(Console.ReadLine(), out number1))
            {
                Console.WriteLine("Enter another integer number: ");
                if (int.TryParse(Console.ReadLine(), out number2))
                {
                    if (number1 <= number2)
                    {
                        smaller = number1;
                        greater = number2;
                    }
                    else
                    {
                        smaller = number2;
                        greater = number1;
                    }

                    sum = 0;

                    while (smaller <= greater)
                    {
                        sum += smaller;
                        smaller++;
                    }
                    Console.WriteLine($"The sum of numbers between {(number1 <= number2 ? number1 : number2)} and {greater} is {sum}.");
                }
                else Console.WriteLine("Invalid input.");
            }
            else Console.WriteLine("Invalid input.");
            #endregion

            Console.ReadKey();
        }
    }
}
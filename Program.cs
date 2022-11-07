namespace BeetrootHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer number: ");
            if (int.TryParse(Console.ReadLine(), out int number1))
            {
                Console.WriteLine("Enter another integer number: ");
                if (int.TryParse(Console.ReadLine(), out int number2))
                {
                    OrderNumbers(ref number1, ref number2);

                    int sum = 0;

                    while (number1 <= number2)
                    {
                        sum += number1;
                        number1++;
                    }
                    Console.WriteLine($"The sum of numbers between numbers is {sum}.");
                }
                else Console.WriteLine("Invalid input.");
            }
            else Console.WriteLine("Invalid input.");


            Console.ReadKey();
        }
public static void OrderNumbers(ref int a, ref int b)
        {
            if (b < a)
            {
                (a, b) = (b, a);
            }
        }

    }
}
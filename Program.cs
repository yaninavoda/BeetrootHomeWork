using System.Globalization;

namespace BeetrootHomework
{
    internal class Program
    {
        public static void Formula1(double x)
        {
            double result = -6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15;
            Console.WriteLine($"The result of \"-6*x^3+5*x^2-10*x+15\" is: {result}");
        }

        public static void Formula2(double x)
        {
            double result = Math.Abs(x) * Math.Sin(x);
            Console.WriteLine($"The result of \"abs(x)*sin(x)\" is: {result}");
        }

        public static void Formula3(double x)
        {
            double result = 2 * Math.PI * x;
            Console.WriteLine($"The result of \"2*pi*x\" is: {result}");
        }

        public static void Formula4(double x, double y)
        {
            double result = Math.Max(x, y);
            Console.WriteLine($"The result of \"max(x, y)\" is: {result}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a whole number for the x variable: ");
            string userInput1 = Console.ReadLine();

            Console.WriteLine("Enter a whole number for the y variable: ");
            string userInput2 = Console.ReadLine();
            double result;

            Console.WriteLine();
            Console.WriteLine("Here are the results of the calculations for the entered numbers: ");
            Console.WriteLine();

            if (int.TryParse(userInput1, out int x))
            {
                result = -6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15;
                Console.WriteLine($"The result of \"-6*x^3+5*x^2-10*x+15\" is: {result}");

                result = Math.Abs(x) * Math.Sin(x);
                Console.WriteLine($"The result of \"abs(x)*sin(x)\" is: {result}");

                result = 2 * Math.PI * x;
                Console.WriteLine($"The result of \"2*pi*x\" is: {result}");
            }
            else Console.WriteLine("You did'n enter a whole number.");
            Console.WriteLine();

            if ((int.TryParse(userInput2, out int y)) && (int.TryParse(userInput1, out int q)))
            {
                result = Math.Max(y, q);
                Console.WriteLine($"The result of \"max(x, y)\" is: {result}");
            }
            else Console.WriteLine("At list one of your inputs was not a whole number.");
            Console.WriteLine();

            Console.WriteLine("Enter a floating-point number for the x variable: ");
            string userInput3 = Console.ReadLine();

            if (Double.TryParse(userInput3, NumberStyles.Float, CultureInfo.InvariantCulture, out double a))
            {
                result = -6 * Math.Pow(a, 3) + 5 * Math.Pow(a, 2) - 10 * a + 15;
                Console.WriteLine($"The result of \"-6*x^3+5*x^2-10*x+15\" is: {result}");

                result = Math.Abs(a) * Math.Sin(a);
                Console.WriteLine($"The result of \"abs(x)*sin(x)\" is: {result}");

                result = 2 * Math.PI * a;
                Console.WriteLine($"The result of \"2*pi*x\" is: {result}");
            }
            else Console.WriteLine("You did'n enter a floating-point number.");


            Console.WriteLine("Enter a floating-point number for the y variable: ");
            string userInput4 = Console.ReadLine();

            if (
                double.TryParse(
                    userInput3,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out double w)
                &&
                double.TryParse(
                    userInput4,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out double r)
                )
            {
                result = Math.Max(w, r);
                Console.WriteLine($"The result of \"max(x, y)\" is: {result}");
            }
            else Console.WriteLine("At list one of your inputs was not a floating-point number.");


            DateTime today = DateTime.Now;
            int daysPassedFromNewYear = today.DayOfYear;
            int thisYear = today.Year;

            int endOfYear = new DateTime(thisYear, 12, 31).DayOfYear;

            int daysLeftToNewYear = endOfYear - daysPassedFromNewYear;
            Console.WriteLine();
            Console.WriteLine($"{daysLeftToNewYear} days left to New Year.");
            Console.WriteLine($"{daysPassedFromNewYear} days passed from New Year.");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Here are the results of the calculations using methods named Formula1-Formula4:");
            Console.WriteLine();

            Formula1(daysLeftToNewYear);
            Formula2(daysLeftToNewYear);
            Formula3(daysLeftToNewYear);
            Formula4(daysLeftToNewYear, daysPassedFromNewYear);

            Console.ReadKey();
        }
    }
}
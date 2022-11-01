namespace BeetrootHomework
{
    internal class Program
    {
        public static double MaxValue(double a, double b)
        {
            return Math.Max(a, b);
        }

        public static double MaxValue(double a, double b, double c)
        {
            if (a > b) return Math.Max(a, c);
            else return Math.Max(b, c);
        }

        public static double MaxValue(params double[] numbers)
        {
            double maxValue = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                maxValue = Math.Max(maxValue, numbers[i]);
            }
            return maxValue;
        }

        public static double MinValue(double a, double b)
        {
            return Math.Min(a, b);
        }

        public static double MinValue(double a, double b, double c)
        {
            if (a < b) return Math.Min(a, c);
            else return Math.Min(b, c);
        }

        public static double MinValue(params double[] numbers)
        {
            double minValue = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                minValue = Math.Min(minValue, numbers[i]);
            }
            return minValue;
        }

        public static bool TrySumIfOdd(int a, int b, out int sum)
        {
            sum = 0;
            int length = Math.Abs(a - b);
            int smaller = (a < b) ? a : b;

            for (int i = 0; i < length; i++)
            {
                sum = sum + smaller + i;
            }
            sum = (length == 0) ? 0 : sum - smaller;
            if (sum % 2 != 0) return true;

            return false;
        }

        public static string Repeat(string x, int n)
        {
            if (n == 0) return string.Empty;
            return x + Repeat(x, --n);
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            double a = random.NextDouble() * 10;
            double b = random.NextDouble() * 10;
            double c = random.NextDouble() * 10;
            double d = random.NextDouble() * 10;

            Console.WriteLine($"MaxValue of '{a:N3}' and '{b:N3}' is '{MaxValue(a, b):N3}'");
            Console.WriteLine($"MaxValue of '{a:N3}', '{b:N3}' and '{c:N3}'" +
                $" is '{MaxValue(a, b, c):N3}'");
            Console.WriteLine($"MaxValue of '{a:N3}', '{b:N3}', '{c:N3}' and '{d:N3}'" +
                $" is '{MaxValue(a, b, c, d):N3}'");
            Console.WriteLine();
            Console.WriteLine($"MinValue of '{a:N3}' and '{b:N3}' is '{MinValue(a, b):N3}'");
            Console.WriteLine($"MinValue of '{a:N3}', '{b:N3}' and '{c:N3}' " +
                $"is '{MinValue(a, b, c):N3}'");
            Console.WriteLine($"MinValue of '{a:N3}', '{b:N3}', '{c:N3}' and '{d:N3}'" +
                $" is '{MinValue(a, b, c, d):N3}'");
            Console.WriteLine();

            int x = random.Next(1, 11);
            int y = random.Next(1, 11);

            Console.WriteLine($"The number are: {x} and {y}.");

            Console.WriteLine($"The statement that the sum of all numbers between them" +
                $" excluding {x} and {y} is {TrySumIfOdd(x, y, out int sum)}");
            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine();

            string str = "a";
            Console.WriteLine($"The string to be repeated is: {str}\n" +
                $"The number of repetitions is: {x}");
            Console.WriteLine(Repeat(str, x));

            Console.ReadKey();
        }
    }
}
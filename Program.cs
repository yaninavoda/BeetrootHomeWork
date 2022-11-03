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
        /// <summary>
        /// Allows to check if the sum of numbers between a and b (not including a and b) is an odd number.
        /// Returns True if sum is odd, otherwise False.
        /// </summary>
        /// <param name="a">Arbitrary whole number</param>
        /// <param name="b">Arbitrary whole number</param>
        /// <param name="sum">Sum of numbers between a and b (not including a and b).</param>
        /// <returns></returns>
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
        /// <summary>
        /// Allows to check if the sum of numbers between a and b (including a and b) is odd.
        /// Returns True if sum is odd, otherwise False.
        /// </summary>
        /// <param name="a">A whole number</param>
        /// <param name="b">A whole number greater than a</param>
        /// <param name="sum1">Sum of numbers between a and b (including a and b).</param>
        /// <returns></returns>
        public static bool TrySumIfOddLatest(int a, int b, out int sum1)
        {
            sum1 = 0;
            int length = b - a;

            for (int i = 0; i < length + 1; i++)
            {
                sum1 = sum1 + a + i;
            }
            
            if (sum1 % 2 != 0) return true;

            return false;
        }
        public static string Repeat(string x, int n)
        {
            if (n == 0) return string.Empty;
            return x + Repeat(x, --n);
        }
        
        public static bool IsValidInput(int a, int b)
        {
            return a < b;
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


            
            int x = random.Next(2, 11);
            int y = random.Next(2, 11);

            Console.WriteLine($"The numbers are: {x} and {y}.");

            // TrySumIfOdd excluding arguments from sum
            Console.WriteLine($"The sum of numbers between {x} and {y}" +
                $" excluding them is {(TrySumIfOdd(x, y, out int sum) ? "" : "not")} odd.");
            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine();

            // TrySumIfOddLatest
            Console.WriteLine("Testing TrySumIfOddLatest including inputs in the sum");
            int input1, input2;
            int attempts = 0;
            do
            {
                attempts++;

                if (attempts > 1)
                {
                    Console.WriteLine("Invalid input: the second number must be greater than the first number. " +
                        "Please try again))");
                    Console.WriteLine();
                }

                Console.WriteLine("Enter an whole number");
                input1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter another whole number greater than the previous");
                input2 = int.Parse(Console.ReadLine());

            } while (input1 >= input2);
                        
            Console.WriteLine($"The numbers are {input1} and {input2}.");
            Console.WriteLine($"The sum of numbers between {input1} and {input2}" +
                $" including them is {(TrySumIfOddLatest(input1, input2, out int sum1) ? "" : "not")} odd.");
            Console.WriteLine($"The sum is {sum1}");
            
            Console.WriteLine();

            // Repeat method
            string str = "--Hello";
            Console.WriteLine($"The string to be repeated is: {str}\n" +
                $"The number of repetitions is: {x}");
            Console.WriteLine(Repeat(str, x));

            Console.ReadKey();
        }
    }
}
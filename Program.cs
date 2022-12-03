namespace BeetrootHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region StringStack

            var listStr = new List<string> { "first", "second", "third" };

            var myStackString = new MyStack<string>(listStr);

            Console.WriteLine("Stack after initialization:");
            myStackString.PrintStack();

            myStackString.PopStack();

            Console.WriteLine("Stack after Pop:");
            myStackString.PrintStack();

            myStackString.PushStack("fourth");
            myStackString.PushStack("fifth");

            Console.WriteLine("Stack after two consequent Pushes:");
            myStackString.PrintStack();

            Console.WriteLine($"Peek method returns : {myStackString.PeekStack()}");

            Console.WriteLine();
            Console.WriteLine();
            var arrayStr = new string[myStackString.Count];

            myStackString.CopyToStack(arrayStr);
            Console.WriteLine("Stack copied to array looks as follows:");
            foreach (var item in arrayStr)
            {
                Console.WriteLine(item);
            }

            #endregion

            SwitchConsole();

            #region DoubleStack

            var listDouble = new List<double> { 0, 0.2, 1.1 };
            var myStackDouble = new MyStack<double>(listDouble);

            Console.WriteLine("Stack after initialization:");
            myStackDouble.PrintStack();

            myStackDouble.PopStack();

            Console.WriteLine("Stack after Pop:");
            myStackDouble.PrintStack();

            myStackDouble.PushStack(9.9);
            myStackDouble.PushStack(3.56);

            Console.WriteLine("Stack after two consequent Pushes:");
            myStackDouble.PrintStack();

            Console.WriteLine($"Peek method returns : {myStackDouble.PeekStack()}");

            #endregion

            SwitchConsole();

            #region IntStack

            var listInt = new List<int> { 0, 1, 2, 3 };

            var myStackInt = new MyStack<int>(listInt);

            Console.WriteLine("Stack after initialization:");
            myStackInt.PrintStack();

            myStackInt.PopStack();

            Console.WriteLine("Stack after Pop:");
            myStackInt.PrintStack();

            myStackInt.PushStack(44);
            myStackInt.PushStack(55);

            Console.WriteLine("Stack after two consequent Pushes:");
            myStackInt.PrintStack();

            Console.WriteLine($"Peek method returns : {myStackInt.PeekStack()}");

            #endregion

            Console.ReadKey();
        }

        public static void SwitchConsole()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key for another data type");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
using System;

namespace BeetrootHomework
{
    public enum SortAlgorithmType
    {
        Selection,
        Insertion,
        Bubble
    }

    public enum OrderBy
    {
        Asc,
        Desc
    }
    internal class Program
    {
        public static void InhabitArray(int[] array)
        {
            var random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-100, 101);
            }
        }
        public static void PrintArray(int[] array)
        {
            foreach (var element in array)
                Console.Write($"{element}\t");

            Console.WriteLine();
        }
        public static void RevertArray(int[] array)
        { 
            for (int i = 0; i < array.Length / 2; i++)
            {
                Swap(ref array[i], ref array[array.Length - 1 - i]);
            }
        }
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void SelectionSort(int[] array)
        {
            int selected;
            for (int i = 0; i < array.Length - 1; i++)
            {
                selected = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[selected])
                    {
                        selected = j;
                    }
                }
                Swap(ref array[i], ref array[selected]);
            }
        }

        public static void InsertionSort(int[] array)
        {
            int toInsert, previous;

            for (int i = 1; i < array.Length; i++)
            {
                toInsert = i;
                previous = toInsert - 1;

                while (toInsert > 0 && array[toInsert] < array[previous])
                {
                    (array[toInsert], array[previous]) = (array[previous], array[toInsert]);
                    toInsert--;
                    previous--;
                }
            }
        }

        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] >= array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }

                }
            }
        }
        public static void Sort(
            int[] array, 
            SortAlgorithmType algorithm = SortAlgorithmType.Bubble, 
            OrderBy order = OrderBy.Asc
            )
        {
            switch (algorithm)
            {
                case SortAlgorithmType.Selection:
                    SelectionSort(array);
                    break;
                case SortAlgorithmType.Insertion:
                    InsertionSort(array);
                    break;
                case SortAlgorithmType.Bubble:
                    BubbleSort(array);
                    break;
            }
            if (order == OrderBy.Desc)
            {
                RevertArray(array);
            }
        }
        static void Main(string[] args)
        {
            var rand = new Random();

            var array = new int[rand.Next(4, 10)];
            
            InhabitArray(array);
            Console.WriteLine("Initial array:");
            Console.WriteLine($"{string.Join("\t", array)}");
            Console.WriteLine();
            Sort(array, SortAlgorithmType.Insertion, OrderBy.Asc);
            Console.WriteLine($"Array sorted using" +
                $" {nameof(SortAlgorithmType.Insertion)}Sort in the " +
                $"{nameof(OrderBy.Asc)}ending order:");
            PrintArray(array);
            
            Console.WriteLine($"{new string('=', 20)}");
            Console.WriteLine();

            InhabitArray(array);
            Console.WriteLine("Initial array:");
            Console.WriteLine($"{string.Join("\t", array)}");
            Console.WriteLine();
            Sort(array, SortAlgorithmType.Selection, OrderBy.Asc);
            Console.WriteLine($"Array sorted using" +
                $" {nameof(SortAlgorithmType.Selection)}Sort in the " +
                $"{nameof(OrderBy.Asc)}ending order:");
            PrintArray(array);
            Console.WriteLine($"{new string('=', 20)}");
            Console.WriteLine();

            InhabitArray(array);
            Console.WriteLine("Initial array:");
            Console.WriteLine($"{string.Join("\t", array)}");
            Console.WriteLine();
            Sort(array, SortAlgorithmType.Bubble, OrderBy.Asc);
            Console.WriteLine($"Array sorted using" +
                $" {nameof(SortAlgorithmType.Bubble)}Sort in the " +
                $"{nameof(OrderBy.Asc)}ending order:");
            PrintArray(array);

            Console.WriteLine($"{new string('=', 20)}");
            Console.WriteLine();

            InhabitArray(array);
            Console.WriteLine("Initial array:");
            Console.WriteLine($"{string.Join("\t", array)}");
            Console.WriteLine();
            Sort(array, SortAlgorithmType.Insertion, OrderBy.Desc);
            Console.WriteLine($"Array sorted using" +
                $" {nameof(SortAlgorithmType.Insertion)}Sort in the " +
                $"{nameof(OrderBy.Desc)}ending order:");
            PrintArray(array);

            Console.WriteLine($"{new string('=', 20)}");
            Console.WriteLine();

            InhabitArray(array);
            Console.WriteLine("Initial array:");
            Console.WriteLine($"{string.Join("\t", array)}");
            Console.WriteLine();
            Sort(array, SortAlgorithmType.Selection, OrderBy.Desc);
            Console.WriteLine($"Array sorted using" +
                $" {nameof(SortAlgorithmType.Selection)}Sort in the " +
                $"{nameof(OrderBy.Desc)}ending order:");
            PrintArray(array);

            Console.WriteLine($"{new string('=', 20)}");
            Console.WriteLine();

            InhabitArray(array);
            Console.WriteLine("Initial array:");
            Console.WriteLine($"{string.Join("\t", array)}");
            Console.WriteLine();
            Sort(array, SortAlgorithmType.Bubble, OrderBy.Desc);
            Console.WriteLine($"Array sorted using" +
                $" {nameof(SortAlgorithmType.Bubble)}Sort in the " +
                $"{nameof(OrderBy.Desc)}ending order:");
            PrintArray(array);

            Console.WriteLine($"{new string('=', 20)}");
            Console.WriteLine(); ;

            Console.WriteLine("Using Sort method with default parameters.");
            Console.WriteLine("Initial array:");
            InhabitArray(array);
            PrintArray(array);
            Sort(array);
            Console.WriteLine("Sorted array:");
            PrintArray(array);

            



            Console.ReadKey();
        }
    }
}
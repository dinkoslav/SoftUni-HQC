namespace _03_SortingAlgorithmTests
{
    using System;
    using System.Diagnostics;
    
    public class SortingAlgorithmsTests
    {
        private const int LoopCount = 500000;

        public static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void Main()
        {
            IComparable[] result = null;
            int[] intNumbers = { 9, 4, 13, 42, 56, 21, 1, 19, 42, 42, 40, 109, 3, 8, 99 };
            int[] sortedIntNumbers = { 1, 3, 4, 8, 9, 13, 19, 21, 40, 42, 42, 42, 56, 99, 109 };
            int[] reversedIntNumbers = { 109, 99, 56, 42, 42, 42, 40, 21, 19, 13, 9, 8, 4, 3, 1 };
            double[] doubleNumbers = { 9, 4, 13, 42, 56, 21, 1, 19, 42, 42, 40, 109, 3, 8, 99 };
            double[] sortedDoubleNumbers = { 1, 3, 4, 8, 9, 13, 19, 21, 40, 42, 42, 42, 56, 99, 109 };
            double[] reversedDoubleNumbers = { 109, 99, 56, 42, 42, 42, 40, 21, 19, 13, 9, 8, 4, 3, 1 };
            string[] stringArray = { "9", "4", "13", "42", "56", "21", "1", "19", "42", "42", "40", "109", "3", "8", "99" };
            string[] sortedStringArray = { "1", "109", "13", "19", "21", "3", "4", "40", "42", "42", "42", "56", "8", "9", "99" };
            string[] reversedStringArray = { "99", "9", "8", "56", "42", "42", "42", "40", "4", "3", "21", "19", "13", "109", "1" };

            Console.Write("Test insertion sort algorithm on random int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[intNumbers.Length];
                        Array.Copy(intNumbers, result, intNumbers.Length);
                        SortingAlgorithms.InsertionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test selection sort algorithm on random int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[intNumbers.Length];
                        Array.Copy(intNumbers, result, intNumbers.Length);
                        SortingAlgorithms.SelectionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test quick sort algorithm on random int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[intNumbers.Length];
                        Array.Copy(intNumbers, result, intNumbers.Length);
                        SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
                    }
                });

            //PrintResult(result);

            Console.WriteLine();

            Console.Write("Test insertion sort algorithm on random double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[doubleNumbers.Length];
                        Array.Copy(doubleNumbers, result, doubleNumbers.Length);
                        SortingAlgorithms.InsertionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test selection sort algorithm on random double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[doubleNumbers.Length];
                        Array.Copy(doubleNumbers, result, doubleNumbers.Length);
                        SortingAlgorithms.SelectionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test quick sort algorithm on random double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[doubleNumbers.Length];
                        Array.Copy(doubleNumbers, result, doubleNumbers.Length);
                        SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
                    }
                });

            //PrintResult(result);

            Console.WriteLine();

            Console.Write("Test insertion sort algorithm on random strings:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[stringArray.Length];
                        Array.Copy(stringArray, result, stringArray.Length);
                        SortingAlgorithms.InsertionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test selection sort algorithm on random strings:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[stringArray.Length];
                        Array.Copy(stringArray, result, stringArray.Length);
                        SortingAlgorithms.SelectionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test quick sort algorithm on random strings:\t\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[stringArray.Length];
                        Array.Copy(stringArray, result, stringArray.Length);
                        SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
                    }
                });

            //PrintResult(result);

            Console.WriteLine();

            Console.Write("Test insertion sort algorithm on sorted int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[sortedIntNumbers.Length];
                        Array.Copy(sortedIntNumbers, result, sortedIntNumbers.Length);
                        SortingAlgorithms.InsertionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test selection sort algorithm on sorted int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[sortedIntNumbers.Length];
                        Array.Copy(sortedIntNumbers, result, sortedIntNumbers.Length);
                        SortingAlgorithms.SelectionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test quick sort algorithm on sorted int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[sortedIntNumbers.Length];
                        Array.Copy(sortedIntNumbers, result, sortedIntNumbers.Length);
                        SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
                    }
                });

            //PrintResult(result);

            Console.WriteLine();

            Console.Write("Test insertion sort algorithm on sorted double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[sortedDoubleNumbers.Length];
                        Array.Copy(sortedDoubleNumbers, result, sortedDoubleNumbers.Length);
                        SortingAlgorithms.InsertionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test selection sort algorithm on sorted double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[sortedDoubleNumbers.Length];
                        Array.Copy(sortedDoubleNumbers, result, sortedDoubleNumbers.Length);
                        SortingAlgorithms.SelectionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test quick sort algorithm on sorted double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[sortedDoubleNumbers.Length];
                        Array.Copy(sortedDoubleNumbers, result, sortedDoubleNumbers.Length);
                        SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
                    }
                });

            //PrintResult(result);

            Console.WriteLine();

            Console.Write("Test insertion sort algorithm on sorted strings:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[sortedStringArray.Length];
                        Array.Copy(sortedStringArray, result, sortedStringArray.Length);
                        SortingAlgorithms.InsertionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test selection sort algorithm on sorted strings:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[sortedStringArray.Length];
                        Array.Copy(sortedStringArray, result, sortedStringArray.Length);
                        SortingAlgorithms.SelectionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test quick sort algorithm on sorted strings:\t\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[sortedStringArray.Length];
                        Array.Copy(sortedStringArray, result, sortedStringArray.Length);
                        SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
                    }
                });

            //PrintResult(result);

            Console.WriteLine();

            Console.Write("Test insertion sort algorithm on reversed int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[reversedIntNumbers.Length];
                        Array.Copy(reversedIntNumbers, result, reversedIntNumbers.Length);
                        SortingAlgorithms.InsertionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test selection sort algorithm on reversed int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[reversedIntNumbers.Length];
                        Array.Copy(reversedIntNumbers, result, reversedIntNumbers.Length);
                        SortingAlgorithms.SelectionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test quick sort algorithm on reversed int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[reversedIntNumbers.Length];
                        Array.Copy(reversedIntNumbers, result, reversedIntNumbers.Length);
                        SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
                    }
                });

            //PrintResult(result);

            Console.WriteLine();

            Console.Write("Test insertion sort algorithm on reversed double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[reversedDoubleNumbers.Length];
                        Array.Copy(reversedDoubleNumbers, result, reversedDoubleNumbers.Length);
                        SortingAlgorithms.InsertionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test selection sort algorithm on reversed double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[reversedDoubleNumbers.Length];
                        Array.Copy(reversedDoubleNumbers, result, reversedDoubleNumbers.Length);
                        SortingAlgorithms.SelectionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test quick sort algorithm on reversed double numbers:\t\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[reversedDoubleNumbers.Length];
                        Array.Copy(reversedDoubleNumbers, result, reversedDoubleNumbers.Length);
                        SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
                    }
                });

            //PrintResult(result);

            Console.WriteLine();

            Console.Write("Test insertion sort algorithm on reversed strings:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[reversedStringArray.Length];
                        Array.Copy(reversedStringArray, result, reversedStringArray.Length);
                        SortingAlgorithms.InsertionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test selection sort algorithm on reversed strings:\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[reversedStringArray.Length];
                        Array.Copy(reversedStringArray, result, reversedStringArray.Length);
                        SortingAlgorithms.SelectionSort(result);
                    }
                });

            //PrintResult(result);

            Console.Write("Test quick sort algorithm on reversed strings:\t\t");
            DisplayExecutionTime(
                () =>
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        result = new IComparable[reversedStringArray.Length];
                        Array.Copy(reversedStringArray, result, reversedStringArray.Length);
                        SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
                    }
                });

            //PrintResult(result);
        }

        private static void PrintResult(IComparable[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

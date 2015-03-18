namespace _02_OperationsPerformanceTests
{
    using System;
    using System.Diagnostics;

    public class SimpleMathOperationsTests
    {
        private const int TestValue = 50000000;

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
            Console.Write("Test adding int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    int sum = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        sum = sum + 1;
                    }
                });

            Console.Write("Test adding long numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    long sum = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        sum = sum + 1;
                    }
                });

            Console.Write("Test adding float numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    float sum = 0f;
                    for (int i = 0; i < TestValue; i++)
                    {
                        sum = sum + 1f;
                    }
                });

            Console.Write("Test adding double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    double sum = 0f;
                    for (int i = 0; i < TestValue; i++)
                    {
                        sum = sum + 1d;
                    }
                });

            Console.Write("Test adding decimal numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    decimal sum = 0m;
                    for (int i = 0; i < TestValue; i++)
                    {
                        sum = sum + 1m;
                    }
                });

            Console.WriteLine();

            Console.Write("Test subtract int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    int result = TestValue;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = result - 1;
                    }
                });

            Console.Write("Test subtract long numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    long result = TestValue;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = result - 1;
                    }
                });

            Console.Write("Test subtract float numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    float result = TestValue;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = result - 1f;
                    }
                });

            Console.Write("Test subtract double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    double result = TestValue;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = result - 1d;
                    }
                });

            Console.Write("Test subtract decimal numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    decimal result = TestValue;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = result - 1m;
                    }
                });

            Console.WriteLine();

            Console.Write("Test increment int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    int result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result++;
                    }
                });

            Console.Write("Test increment long numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    long result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result++;
                    }
                });

            Console.Write("Test increment float numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    float result = 0f;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result++;
                    }
                });

            Console.Write("Test increment double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    double result = 0d;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result++;
                    }
                });

            Console.Write("Test increment decimal numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    decimal result = 0m;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result++;
                    }
                });

            Console.WriteLine();

            Console.Write("Test multiply int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    int result = 1;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result *= 1;
                    }
                });

            Console.Write("Test multiply long numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    long result = 1;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result *= 1;
                    }
                });

            Console.Write("Test multiply float numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    float result = 1f;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result *= 1f;
                    }
                });

            Console.Write("Test multiply double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    double result = 1d;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result *= 1d;
                    }
                });

            Console.Write("Test multiply decimal numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    decimal result = 1m;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result *= 1m;
                    }
                });

            Console.WriteLine();

            Console.Write("Test divide int numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    int result = TestValue;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = result / 2;
                    }
                });

            Console.Write("Test divide long numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    long result = TestValue;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = result / 2;
                    }
                });

            Console.Write("Test divide float numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    float result = TestValue;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = result / 2f;
                    }
                });

            Console.Write("Test divide double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    double result = TestValue;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = result / 2d;
                    }
                });

            Console.Write("Test divide decimal numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    decimal result = TestValue;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = result / 2m;
                    }
                });
        }
    }
}

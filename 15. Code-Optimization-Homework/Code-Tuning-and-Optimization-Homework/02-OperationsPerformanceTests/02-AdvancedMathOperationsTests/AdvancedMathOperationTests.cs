namespace _02_AdvancedMathOperationsTests
{
    using System;
    using System.Diagnostics;
    
    public class AdvancedMathOperationTests
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
            Console.Write("Test square root of float numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    float result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = (float)Math.Sqrt(TestValue);
                    }
                });

            Console.Write("Test square root of double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    double result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = Math.Sqrt(TestValue);
                    }
                });

            Console.Write("Test square root of decimal numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    decimal result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = (decimal)Math.Sqrt((double)TestValue);
                    }
                });

            Console.WriteLine();
            
            Console.Write("Test natural logarithm of float numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    float result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = (float)Math.Log(TestValue);
                    }
                });

            Console.Write("Test natural logarithm of double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    double result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = Math.Log(TestValue);
                    }
                });

            Console.Write("Test natural logarithm of decimal numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    decimal result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = (decimal)Math.Log((double)TestValue);
                    }
                });

            Console.WriteLine();

            Console.Write("Test sinus of float numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    float result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = (float)Math.Sin(TestValue);
                    }
                });

            Console.Write("Test sinus of double numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    double result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = Math.Sin(TestValue);
                    }
                });

            Console.Write("Test sinus of decimal numbers:\t");
            DisplayExecutionTime(
                () =>
                {
                    decimal result = 0;
                    for (int i = 0; i < TestValue; i++)
                    {
                        result = (decimal)Math.Sin(TestValue);
                    }
                });
        }
    }
}

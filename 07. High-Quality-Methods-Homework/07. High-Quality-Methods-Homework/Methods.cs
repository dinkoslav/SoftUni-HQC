using System;

namespace Methods
{
    class Methods
    {
        static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive!");
            }
            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
            return area;
        }

        static string DigitToString(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    throw new ArgumentOutOfRangeException("Invalid number");
            }
        }

        static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Elements in array can not be null or empty");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }
            return elements[0];
        }

        static void FormatAndPrintNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }


        static double FindPointsParameters(double x1, double y1, double x2, double y2, 
            out bool isHorizontal,  out bool isVertical)
        {
            isHorizontal = CheckIsHorizontal(y1, y2);
            isVertical = CheckIsVertical(x1, x2);

            return CalculateDistance(x1, y1, x2, y2);
        }

        private static bool CheckIsHorizontal(double y1, double y2)
        {
            bool isHorizontal = (y1 == y2);
            return isHorizontal;
        }

        private static bool CheckIsVertical(double x1, double x2)
        {
            bool isHorizontal = (x1 == x2);
            return isHorizontal;
        }

        static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }



        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(DigitToString(5));
            
            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));
            
            FormatAndPrintNumber(1.3, "f");
            FormatAndPrintNumber(0.75, "%");
            FormatAndPrintNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(FindPointsParameters(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}

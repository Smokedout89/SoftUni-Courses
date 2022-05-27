using System;

namespace P03._Longer_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            PrintLongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        static void PrintLongerLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double firstLine = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double secondLine = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));

            if (firstLine >= secondLine)
            {
                bool isFirstCloser = CloserPoint(x1, y1, x2, y2);
                if (isFirstCloser)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                bool isFirstCloser = CloserPoint(x3, y3, x4, y4);
                if (isFirstCloser)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }

        private static bool CloserPoint(double x1, double y1, double x2, double y2)
        {
            double firstPointLine = Math.Sqrt(x1 * x1 + y1 * y1);
            double secondPointLine = Math.Sqrt(x2 * x2 + y2 * y2);
            bool isFirstCloser = true;
            if (firstPointLine <= secondPointLine)
            {
                isFirstCloser = true;
            }
            else
            {
                isFirstCloser = false;
            }
            return isFirstCloser;
        }
    }
}

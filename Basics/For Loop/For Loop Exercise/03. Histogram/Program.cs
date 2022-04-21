using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int n1 = 0;
            int n2 = 0;
            int n3 = 0;
            int n4 = 0;
            int n5 = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (currentNum < 200)
                {
                    n1 ++;
                }
                else if (currentNum < 400)
                {
                    n2 ++;
                }
                else if (currentNum < 600)
                {
                    n3 ++;
                }
                else if (currentNum < 800)
                {
                    n4 ++;
                }
                else
                {
                    n5 ++;
                }
            }
            double percentConvertN1 = 1.0 * n1 / n * 100;
            double percentConvertN2 = 1.0 * n2 / n * 100;
            double percentConvertN3 = (double)n3 / n * 100;
            double percentConvertN4 = (double)n4 / n * 100;
            double percentConvertN5 = (double)n5 / n * 100;

            Console.WriteLine($"{percentConvertN1:f2}%");
            Console.WriteLine($"{percentConvertN2:f2}%");
            Console.WriteLine($"{percentConvertN3:f2}%");
            Console.WriteLine($"{percentConvertN4:f2}%");
            Console.WriteLine($"{percentConvertN5:f2}%");
        }
    }
}

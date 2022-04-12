using System;

namespace _10._Devided_without_residue
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double devisibleBy2 = 0;
            double devisibleBy3 = 0;
            double devisibleBy4 = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (currentNum % 2 == 0)
                {
                    devisibleBy2++;
                }
                if (currentNum % 3 == 0)
                {
                    devisibleBy3++;
                }
                if (currentNum % 4 == 0)
                {
                    devisibleBy4++;
                }
            }

            double by2Percent = devisibleBy2 / n * 100;
            double by3Percent = devisibleBy3 / n * 100;
            double by4Percent = devisibleBy4 / n * 100;

            Console.WriteLine($"{by2Percent:f2}%");      
            Console.WriteLine($"{by3Percent:f2}%");      
            Console.WriteLine($"{by4Percent:f2}%");      
        }
    }
}

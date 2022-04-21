using System;

namespace _06._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxFirstNum = int.Parse(Console.ReadLine());
            int maxSecondNum = int.Parse(Console.ReadLine());
            int maxThirdNum = int.Parse(Console.ReadLine());

            for (int i = 2; i <= maxFirstNum; i+=2)
            {
                for (int j = 2; j <= maxSecondNum; j++)
                {
                    for (int k = 2; k <= maxThirdNum; k+=2)
                    {
                        if (j == 2 || j == 3 || j == 5 || j == 7)
                        {
                            Console.WriteLine($"{i} {j} {k} ");
                        }
                    }
                }
            }

        }
    }
}

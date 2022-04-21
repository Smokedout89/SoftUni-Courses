using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDigitMax = int.Parse(Console.ReadLine());
            int secondDigitMax = int.Parse(Console.ReadLine());
            int thirdDigitMax = int.Parse(Console.ReadLine());  

            for (int i = 2; i <= firstDigitMax; i+=2)
            {
                for (int j = 2; j <= secondDigitMax; j++)
                {
                    for (int k = 2; k <= thirdDigitMax; k += 2)
                    {
                        if (j == 2 || j == 3 || j == 5 || j == 7)
                        {
                            Console.WriteLine(i+" "+j+" "+k);
                        }
                    }
                }
            }
            
        }
    }
}

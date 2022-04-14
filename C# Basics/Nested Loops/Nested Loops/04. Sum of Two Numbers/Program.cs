using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int lastNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int combinationCounter = 0;

            for (int i = firstNum; i <= lastNum; i++)
            {
                for (int n = firstNum; n <= lastNum; n++)
                {
                    combinationCounter++;
                    if (i + n == magicNum)
                    {                     
                        Console.WriteLine($"Combination N:{combinationCounter} ({i} + {n} = {magicNum})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{combinationCounter} combinations - neither equals {magicNum}");
        }
    }
}

using System;

namespace _02._Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char intervalStart = char.Parse(Console.ReadLine());
            char intervalFinish = char.Parse(Console.ReadLine());
            char letterToMiss = char.Parse(Console.ReadLine());

            int count = 0;

            for (char i = intervalStart; i <= intervalFinish; i++)
            {
                for (char j = intervalStart; j <= intervalFinish; j++)
                {
                    for (char k = intervalStart; k <= intervalFinish; k++)
                    {
                        if (i != letterToMiss && j != letterToMiss && k != letterToMiss)
                        {
                            Console.Write($"{i}{j}{k} ");
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}

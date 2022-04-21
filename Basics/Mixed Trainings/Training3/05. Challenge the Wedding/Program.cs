using System;

namespace _05._Challenge_the_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMens = int.Parse(Console.ReadLine());
            int numberOfWomens = int.Parse(Console.ReadLine());
            int maxNumOfTables = int.Parse(Console.ReadLine());
            int tablesCounter = 0;
            for (int m = 1; m <= numberOfMens; m++)
            {
                
                for (int f = 1; f <= numberOfWomens; f++)
                {
                    if (tablesCounter < maxNumOfTables)
                    {
                       tablesCounter++;
                       Console.Write($"({m} <-> {f}) ");
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }
    }
}

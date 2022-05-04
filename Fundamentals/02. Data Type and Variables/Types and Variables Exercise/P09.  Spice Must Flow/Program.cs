using System;

namespace P09.__Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int daysCount = 0;
            int totalSpices = 0;

            while (startingYield >= 100)
            {
                totalSpices += startingYield - 26;
                daysCount++;
                startingYield -= 10;
            }

            if (startingYield < 100 && daysCount == 0)
            {
                Console.WriteLine(daysCount);
                Console.WriteLine(totalSpices);
            }
            else
            {
                totalSpices -= 26;
                Console.WriteLine(daysCount);
                Console.WriteLine(totalSpices);
            }
        }
    }
}

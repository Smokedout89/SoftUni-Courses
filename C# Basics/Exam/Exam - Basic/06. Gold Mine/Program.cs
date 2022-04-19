using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLocations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfLocations; i++)
            {
                double expectedAverageIncome = double.Parse(Console.ReadLine());
                int numOfDays = int.Parse(Console.ReadLine());
                double averageGoldMined = 0;

                for (int j = 0; j < numOfDays; j++)
                {
                    double goldMined = double.Parse(Console.ReadLine());
                    averageGoldMined += goldMined;
                }

                double averageDailyMined = averageGoldMined / numOfDays;

                if (averageDailyMined >= expectedAverageIncome)
                {
                    Console.WriteLine($"Good job! Average gold per day: {averageDailyMined:f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {expectedAverageIncome-averageDailyMined:f2} gold.");
                }

            }

        }
    }
}

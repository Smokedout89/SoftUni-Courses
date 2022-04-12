using System;

namespace _08._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tourneysAttended = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            int tourneysWon = 0;
            int pointsWon = 0;
            for (int i = 0; i < tourneysAttended; i++)
            {
                string placing = Console.ReadLine();
                if (placing == "W")
                {
                    pointsWon += 2000;
                    tourneysWon++;
                }
                else if (placing == "F")
                {
                    pointsWon += 1200;
                }
                else
                {
                    pointsWon += 720;
                }
            }
            double totalPoints = pointsWon + startingPoints;
            double averagePoints = pointsWon / tourneysAttended;
            double winPercentage = (double)tourneysWon / tourneysAttended * 100;

            Console.WriteLine("Final points: " + totalPoints);
            Console.WriteLine("Average points: " + averagePoints);
            Console.WriteLine($"{winPercentage:f2}%");
        }
    }
}

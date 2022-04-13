using System;

namespace Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int seriesTime = int.Parse(Console.ReadLine());
            double brakeTime = int.Parse(Console.ReadLine());

            double lunchTime = brakeTime / 8;
            double relaxTime = brakeTime / 4;

            double timeLeft = brakeTime - (lunchTime + relaxTime);
            double timeNeeded = Math.Abs(seriesTime - timeLeft);

            Console.WriteLine(timeLeft >= seriesTime ?
                $"You have enough time to watch {seriesName} and left with {Math.Ceiling(timeNeeded)} minutes free time." :
                $"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(timeNeeded)} more minutes." );
        }
    }
}

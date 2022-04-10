using System;

namespace _04._Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int balls = int.Parse(Console.ReadLine());
            double points = 0;
            int redCount = 0;
            int orangeCount = 0;
            int yellowCount = 0;
            int whiteCount = 0;
            int otherCount = 0;
            int blackCount = 0;
            for (int i = 0; i < balls; i++)
            {
                string colours = Console.ReadLine();
                if (colours != "red" && colours != "orange" && colours != "yellow" && colours != "white" && colours != "black")
                {
                    otherCount++;
                    continue;
                }
                switch (colours)
                {
                    case "red":
                        points += 5;
                        redCount++;
                        break;
                    case "orange":
                        points += 10;
                        orangeCount++;
                        break;
                    case "yellow":
                        points += 15;
                        yellowCount++;
                        break;
                    case "white":
                        points += 20;
                        whiteCount++;
                        break;
                    case "black":
                        points /= 2;
                        points = Math.Floor(points);
                        blackCount++;
                        break;
                }
            }
            Console.WriteLine($"Total points: {points}");
            Console.WriteLine($"Points from red balls: {redCount}");
            Console.WriteLine($"Points from orange balls: {orangeCount}");
            Console.WriteLine($"Points from yellow balls: {yellowCount}");
            Console.WriteLine($"Points from white balls: {whiteCount}");
            Console.WriteLine($"Other colors picked: {otherCount}");
            Console.WriteLine($"Divides from black balls: {blackCount}");
        }
    }
}

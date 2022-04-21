using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMetres = double.Parse(Console.ReadLine());
            double timePerMetre = double.Parse(Console.ReadLine());

            double totalTime = distanceInMetres * timePerMetre;
            double timeSlowedDown = Math.Floor(distanceInMetres / 15);

            totalTime += timeSlowedDown * 12.5;

            Console.WriteLine(totalTime < recordInSeconds ? $"Yes, he succeeded! The new world record is {totalTime:f2} seconds." : $"No, he failed! He was {totalTime-recordInSeconds:f2} seconds slower.");

        }
    }
}

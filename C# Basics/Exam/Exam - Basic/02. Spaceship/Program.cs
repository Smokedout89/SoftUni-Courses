using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthOfSpaceship = double.Parse(Console.ReadLine());
            double lenghtOfSpaceship = double.Parse(Console.ReadLine());
            double heightOfSpaceship = double.Parse(Console.ReadLine());
            double averageHeighOfAstronauts = double.Parse(Console.ReadLine());

            double volumeOfSpaceship = widthOfSpaceship * lenghtOfSpaceship * heightOfSpaceship;
            double volumePerRoom = (averageHeighOfAstronauts + 0.40) * 2 * 2;
            double spaceForAstronauts = Math.Floor(volumeOfSpaceship / volumePerRoom);

            if (spaceForAstronauts >= 3 && spaceForAstronauts <= 10)
            {
                Console.WriteLine($"The spacecraft holds {spaceForAstronauts} astronauts.");
            }
            else if (spaceForAstronauts < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }

        }
    }
}

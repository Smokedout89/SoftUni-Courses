using System;

namespace P07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalWater = 0;
            const int waterCapacity = 255;

            for (int i = 0; i < n; i++)
            {
                int waterPoured = int.Parse(Console.ReadLine());

                if (totalWater + waterPoured <= waterCapacity)
                {
                    totalWater += waterPoured;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(totalWater);
        }
    }
}

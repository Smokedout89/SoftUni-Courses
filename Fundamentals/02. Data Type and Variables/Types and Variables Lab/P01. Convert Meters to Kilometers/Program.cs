using System;

namespace P01._Convert_Meters_to_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int metres = int.Parse(Console.ReadLine());
            double km = metres / 1000.0;

            Console.WriteLine($"{Math.Round(km, 2, MidpointRounding.AwayFromZero):F2}");
        }
    }
}

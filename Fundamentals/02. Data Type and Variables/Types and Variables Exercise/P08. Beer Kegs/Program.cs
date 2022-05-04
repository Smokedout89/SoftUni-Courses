using System;

namespace P08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double largestVolume = 0;
            string biggestKeg = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string kegModel = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (largestVolume < volume)
                {
                    largestVolume = volume;
                    biggestKeg = kegModel;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}

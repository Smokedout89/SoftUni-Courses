using System;

namespace Problem_4___Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal food = decimal.Parse(Console.ReadLine());
            decimal hay = decimal.Parse(Console.ReadLine());
            decimal cover = decimal.Parse(Console.ReadLine());
            decimal pigWeight = decimal.Parse(Console.ReadLine());

            for (int i = 1; i <= 30; i++)
            {
                food -= 0.300m;

                if (food <= 0 || hay <= 0 || cover <= 0)
                {
                    break;
                }


                if (i % 2 == 0)
                {
                    decimal hayToGive = food * 0.05m;
                    hay -= hayToGive;
                }

                if (i % 3 == 0)
                {
                    decimal coverToGive = pigWeight * 1 / 3;
                    cover -= coverToGive;
                }

            }

            if (food <= 0 || hay <= 0 || cover <= 0)
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
            else
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
        }
    }
}

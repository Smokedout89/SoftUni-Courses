using System;
using System.Linq;
using System.Collections.Generic;

namespace Bakery_Shop
{
    internal class BakeryShop
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split().Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse));

            Dictionary<string, int> baked = new Dictionary<string, int>
                {
                    {"Croissant", 0 },
                    {"Muffin", 0},
                    {"Baguette", 0},
                    {"Bagel", 0}
                };

            while (water.Any() && flour.Any())
            {
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();

                if (CroissantMix(currentWater, currentFlour))
                {
                    baked["Croissant"]++;
                }
                else if (MuffinMix(currentWater, currentFlour))
                {
                    baked["Muffin"]++;
                }
                else if (BaguetteMix(currentWater, currentFlour))
                {
                    baked["Baguette"]++;
                }
                else if (BagelMix(currentWater, currentFlour))
                {
                    baked["Bagel"]++;
                }
                else
                {
                    double remainder = currentFlour - currentWater;
                    baked["Croissant"]++;
                    flour.Push(remainder);
                }
            }

            foreach (var item in baked.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            var waterLeft = water.Count == 0 ? "None" : $"{string.Join(", ", water)}";
            var flourLeft = flour.Count == 0 ? "None" : $"{string.Join(", ", flour)}";

            Console.WriteLine($"Water left: {waterLeft}");
            Console.WriteLine($"Flour left: {flourLeft}");
        }

        private static bool BagelMix(double currentWater, double currentFlour)
        {
            var percentages = CalculatePercentages(currentWater, currentFlour);

            if (percentages[0] == 20 && percentages[1] == 80)
            {
                return true;
            }

            return false;
        }

        private static bool BaguetteMix(double currentWater, double currentFlour)
        {
            var percentages = CalculatePercentages(currentWater, currentFlour);

            if (percentages[0] == 30 && percentages[1] == 70)
            {
                return true;
            }

            return false;
        }

        private static bool MuffinMix(double currentWater, double currentFlour)
        {
            var percentages = CalculatePercentages(currentWater, currentFlour);

            if (percentages[0] == 40 && percentages[1] == 60)
            {
                return true;
            }

            return false;
        }

        private static bool CroissantMix(double currentWater, double currentFlour)
        {
            var percentages = CalculatePercentages(currentWater, currentFlour);

            if (percentages[0] == 50 && percentages[1] == 50)
            {
                return true;
            }

            return false;
        }

        private static double[] CalculatePercentages(double currentWater, double currentFlour)
        {
            var returnResult = new double[2];
            var sum = currentWater + currentFlour;
            returnResult[0] = (currentWater / sum) * 100;
            returnResult[1] = (currentFlour / sum) * 100;

            return returnResult;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] filledBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int wastedWater = 0;

            Queue<int> cupsQueue = new Queue<int>(cupsCapacity);
            Stack<int> bottlesStack = new Stack<int>(filledBottles);

            while (bottlesStack.Count > 0 && cupsQueue.Count > 0)
            {
                int currentBottle = bottlesStack.Pop();
                int currentCup = cupsQueue.Dequeue();

                if (currentCup - currentBottle <= 0)
                {
                    wastedWater += currentBottle - currentCup;
                    continue;
                }

                currentCup -= currentBottle;

                while (bottlesStack.Count > 0 && currentCup > 0)
                {
                    currentBottle = bottlesStack.Pop();

                    if (currentCup - currentBottle <= 0)
                    {
                        wastedWater += currentBottle - currentCup;
                    }

                    currentCup -= currentBottle;
                }
            }

            if (cupsQueue.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottlesStack)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(' ', cupsQueue)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}

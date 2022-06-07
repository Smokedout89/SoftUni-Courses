using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();

            double leftTime = 0;
            double rightTime = 0;

            for (int i = 0; i < input.Count / 2; i++)
            {
                leftTime += input[i];
                if (input[i] == 0)
                {
                    leftTime *= 0.8;
                }
            }

            for (int i = input.Count - 1; i > input.Count / 2; i--)
            {
                rightTime += input[i];
                if (input[i] == 0)
                {
                    rightTime *= 0.8;
                }
            }

            if (leftTime < rightTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightTime}");
            }
        }
    }
}

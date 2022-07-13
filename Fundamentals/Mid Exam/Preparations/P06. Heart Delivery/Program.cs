using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6___Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string command = Console.ReadLine();
            int startIndex = 0;

            while (command != "Love!")
            {
                string[] token = command.Split();
                int lengthIndex = int.Parse(token[1]);

                startIndex += lengthIndex;

                if (startIndex >= numbers.Count)
                {
                    startIndex = 0;
                }

                if (numbers[startIndex] == 0)
                {
                    Console.WriteLine($"Place {startIndex} already had Valentine's day.");
                }
                else
                {
                    numbers[startIndex] -= 2;
                    if (numbers[startIndex] == 0)
                    {
                        Console.WriteLine($"Place {startIndex} has Valentine's day.");
                    }
                }

                command = Console.ReadLine();
            }

            int failedCount = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != 0)
                {
                    failedCount++;
                }
            }

            Console.WriteLine($"Cupid's last position was {startIndex}.");

            if (numbers.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {failedCount} places.");
            }
        }
    }
}

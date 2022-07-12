using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .ToList();

            string command = Console.ReadLine();
            int movesCount = 0;

            while (command != "end")
            {
                int[] indexes = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int firstIndex = indexes[0];
                int secondIndex = indexes[1];

                if (CheatDetector(numbers, indexes, movesCount))
                {
                    movesCount++;

                    if (numbers[firstIndex] == numbers[secondIndex])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {numbers[firstIndex]}!");
                        if (secondIndex > firstIndex)
                        {
                            numbers.RemoveAt(secondIndex);
                            numbers.RemoveAt(firstIndex);
                        }
                        else
                        {
                            numbers.RemoveAt(firstIndex);
                            numbers.RemoveAt(secondIndex);
                        }
                    }
                    else if (numbers[firstIndex] != numbers[secondIndex])
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                else
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (numbers.Count == 0)
                {
                    Console.WriteLine($"You have won in {movesCount} turns!");
                    break;
                }

                command = Console.ReadLine();
            }

            if (numbers.Count != 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(' ', numbers));
            }
        }

        static bool CheatDetector(List<string> numbers, int[] indexes, int moveCount)
        {
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];
            moveCount++;

            if (firstIndex < 0 || firstIndex >= numbers.Count
                || secondIndex < 0 || secondIndex >= numbers.Count
                || firstIndex == secondIndex)
            {
                numbers.Insert(numbers.Count / 2, $"-{moveCount}a");
                numbers.Insert(numbers.Count / 2, $"-{moveCount}a");
                Console.WriteLine("Invalid input! Adding additional elements to the board");
                return false;
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] bomb = Console.ReadLine().Split();
            int bombNumber = int.Parse(bomb[0]);
            int bombPower = int.Parse(bomb[1]);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    int startIndex = i - bombPower;
                    int endIndex = i + bombPower;
                    if (startIndex < 0) startIndex = 0;
                    if (endIndex > numbers.Count) endIndex = numbers.Count - 1;

                    for (int j = startIndex; j <= endIndex; j++)
                    {
                        numbers[j]= 0;
                    }
                    
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}

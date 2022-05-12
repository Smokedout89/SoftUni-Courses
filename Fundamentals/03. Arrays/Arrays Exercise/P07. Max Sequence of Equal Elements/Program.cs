using System;
using System.Linq;

namespace P07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int counter = 0;
            int startIndex = 0;
            int maxSequence = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                    if (counter > maxSequence)
                    {
                        maxSequence = counter;
                        startIndex = i;
                    }
                }
                else
                {
                    counter = 0;
                }
            }

            for (int i = 0; i <= maxSequence; i++)
            {

                Console.Write(numbers[startIndex] + " ");
            }
        }
    }
}

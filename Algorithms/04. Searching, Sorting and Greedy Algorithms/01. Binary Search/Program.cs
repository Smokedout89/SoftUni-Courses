using System.Linq;

namespace _01._Binary_Search
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numberToFindIndex = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, numberToFindIndex));
        }

        private static int BinarySearch(int[] numbers, int numberToFindIndex)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (numbers[mid] == numberToFindIndex)
                {
                    return mid;
                }

                if (numberToFindIndex > numbers[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}

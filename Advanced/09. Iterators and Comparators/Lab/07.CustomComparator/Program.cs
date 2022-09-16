using System;
using System.Linq;

namespace _07.CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int, int> customComparer = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }

                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }

                if (x > y)
                {
                    return 1;
                }

                if (x < y)
                {
                    return -1;
                }

                return 0;

                //return (x % 2 == 0 && y % 2 != 0)
                //    ? -1
                //    : (x % 2 != 0 && y % 2 == 0) 
                //    ? 1
                //    : x > y 
                //    ? 1
                //    : x < y
                //    ? -1
                //    : 0;
            };

            Array.Sort(numbers, (x, y) => customComparer(x, y));

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}

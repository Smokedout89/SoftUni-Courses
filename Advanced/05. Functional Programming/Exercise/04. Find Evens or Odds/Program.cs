using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersRange = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string oddOrEven = Console.ReadLine();
            List<int> numbers = new List<int>();

            for (int i = numbersRange[0]; i <= numbersRange[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = n => n % 2 == 0; 
            Predicate<int> isOdd = n => n % 2 != 0; 
            List<int> result = new List<int>();

            if (oddOrEven == "odd")
            {
                result = numbers.FindAll(isOdd);
            }
            else
            {
                result = numbers.FindAll(isEven);
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = Enumerable.Range(1, n).ToList(); 
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var divider in dividers)
            {
                predicates.Add(x => x % divider == 0);
            }

            foreach (var number in numbers)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}

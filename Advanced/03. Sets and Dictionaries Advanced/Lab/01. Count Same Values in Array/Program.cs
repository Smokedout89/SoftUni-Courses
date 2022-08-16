using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> count = new Dictionary<double, int>();

            foreach (double value in values)
            {
                if (count.ContainsKey(value))
                {
                    count[value]++;
                }
                else
                {
                    count[value] = 1;
                }
            }

            foreach (var keyValuePair in count)
            {
                Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value} times");
            }
        }
    }
}

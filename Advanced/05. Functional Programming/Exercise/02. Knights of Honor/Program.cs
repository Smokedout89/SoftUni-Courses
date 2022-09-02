using System;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            //Action<string[]> printSir = names => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", input));
            Func<string, string> addSir = n => $"Sir {n}";

            foreach (var name in input)
            {
                Console.WriteLine(addSir(name));
            }
        }
    }
}

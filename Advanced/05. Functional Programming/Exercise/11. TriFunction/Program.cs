using System;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int asciiSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> isLargerOrEqual = (name, sum) => name.Sum(x => x) >= sum;

            Func<string[], int, Func<string, int, bool>, string> getName = (name, sum, func) =>
                names.Where(x => func(x, sum)).FirstOrDefault();

            string name = getName(names, asciiSum, isLargerOrEqual);

            Console.WriteLine(name);
        }
    }
}

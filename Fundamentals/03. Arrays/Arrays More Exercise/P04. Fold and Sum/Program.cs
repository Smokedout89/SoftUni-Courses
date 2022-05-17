using System;
using System.Linq;

namespace P04._Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = inputArray.Length / 4;

            int[] newArr = new int[k * 2];

            for (int i = 0; i < k; i++)
            {
                newArr[i] = inputArray[k - (i + 1)] + inputArray[k + i];
                newArr[newArr.Length - 1 - i] = inputArray[newArr.Length - 1 - i + k] +
                                                inputArray[(newArr.Length - 1 - i) + (k + 2 * i + 1)];
            }

            Console.WriteLine(string.Join(' ', newArr));
        }
    }
}

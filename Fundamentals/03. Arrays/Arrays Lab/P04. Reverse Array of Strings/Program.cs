using System;
using System.Linq;

namespace P04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < arr.Length / 2; i++)
            {
                var oldElement = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = oldElement;
            }
            Console.WriteLine(String.Join(' ', arr));
        }
    }
}

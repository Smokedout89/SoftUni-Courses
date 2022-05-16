using System;

namespace P03._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int result = 0;
            int[] arr = new int[number];

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    arr[i] = 1;
                }
                else if (i == 2)
                {
                    arr[i] = 2;
                }
                else
                {
                    arr[i] = arr[i - 1] + arr[i - 2];
                }

                result = arr[arr.Length - 1];
            }

            Console.WriteLine(result);
        }
    }
}

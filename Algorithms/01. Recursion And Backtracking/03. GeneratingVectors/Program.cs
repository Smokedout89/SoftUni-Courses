namespace _03.GeneratingVectors
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Generate01(arr, 0);
        }

        private static void Generate01(int[] arr, int idx) 
        {
            if (idx >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[idx] = i;

                Generate01(arr, idx + 1);
            }
        }
    }
}

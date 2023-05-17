namespace _01.Reverse_Array
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static int[] numbers;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            ReverseArray(0);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void ReverseArray(int idx)
        {
            if (idx == numbers.Length / 2)
            {
                return;
            }

            int temp = numbers[idx];
            numbers[idx] = numbers[numbers.Length - idx - 1];
            numbers[numbers.Length - idx - 1] = temp;

            ReverseArray(idx + 1);
        }
    }
}

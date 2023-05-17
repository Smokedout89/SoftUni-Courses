namespace _02.Nested_Loops_To_Recursion
{
    using System;

    internal class Program
    {
        private static int[] numbers;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            numbers = new int[n];

            GenerateLoops(0);
        }

        private static void GenerateLoops(int idx)
        {
            if (idx >= numbers.Length)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            for (int i = 1; i <= numbers.Length; i++)
            {
                numbers[idx] = i;

                GenerateLoops(idx + 1);
            }
        }
    }
}

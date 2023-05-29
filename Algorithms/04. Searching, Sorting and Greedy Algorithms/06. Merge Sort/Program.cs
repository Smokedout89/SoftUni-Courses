namespace _06._Merge_Sort
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sorted = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return numbers;
            }

            var left = numbers.Take(numbers.Length / 2).ToArray();
            var right = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergedIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merged[mergedIdx++] = left[leftIdx++]; 
                }
                else
                {
                    merged[mergedIdx++] = right[rightIdx++];
                }
            }

            for (int i = leftIdx; i < left.Length; i++)
            {
                merged[mergedIdx++] = left[i];
            }

            for (int i = rightIdx; i < right.Length; i++)
            {
                merged[mergedIdx++] = right[i];
            }

            return merged;
        }
    }
}

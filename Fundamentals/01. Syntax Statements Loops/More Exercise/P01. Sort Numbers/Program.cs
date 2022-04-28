using System;

namespace P01._Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[3];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(nums);
            Array.Reverse(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}

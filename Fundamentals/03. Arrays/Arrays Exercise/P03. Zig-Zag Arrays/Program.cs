using System;
using System.Linq;

namespace P03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] nums1 = new int[n];
            int[] nums2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < nums.Length; j++)
                {
                    if (i % 2 == 0)
                    {
                        nums1[i] = nums[0];
                        nums2[i] = nums[1];
                    }
                    else
                    {
                        nums1[i] = nums[1];
                        nums2[i] = nums[0];
                    }
                }
            }

            Console.WriteLine(string.Join(' ', nums1));
            Console.WriteLine(string.Join(' ', nums2));
        }
    }
}

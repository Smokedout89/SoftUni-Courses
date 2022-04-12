using System;

namespace leftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < n; i++)
            {
                leftSum += int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                rightSum += int.Parse(Console.ReadLine());
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine("Yes, sum = " + leftSum);
            }
            else
            {
                int diff = Math.Abs(leftSum - rightSum);
                Console.WriteLine("No, diff = " + diff);
            }
            //for (int i = 1; i <= n*2; i++)
            //{
            //    int n1 = int.Parse(Console.ReadLine());
            //    int n2 = int.Parse(Console.ReadLine());
            //    int n3 = int.Parse(Console.ReadLine());
            //    int n4 = int.Parse(Console.ReadLine());

            //    leftSum = n1 + n2; rightSum = n3 + n4;
            //    int difference = Math.Abs(leftSum - rightSum);
            //    if (leftSum == rightSum)
            //    {
            //        Console.WriteLine("Yes, sum = " + leftSum);
            //    }
            //    else
            //    {
            //        Console.WriteLine("No, diff = " + difference);
            //    }
        }
        
    }
}

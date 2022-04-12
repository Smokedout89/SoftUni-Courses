using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                sum += currentNum;
                if (currentNum > maxNum)
                {
                    maxNum = currentNum;
                }
            }           
            int sumWithoutMax = sum - maxNum;
            int diff = Math.Abs(maxNum - sumWithoutMax);
            if (sumWithoutMax == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + maxNum);
            }
            else               
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);    
            }
        }
    }
}

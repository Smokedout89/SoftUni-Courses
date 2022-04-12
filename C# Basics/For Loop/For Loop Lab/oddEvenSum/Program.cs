using System;

namespace oddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int oddSum = 0;
            int evenSum = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i % 2 == 0) evenSum += number;
                else            oddSum += number;
            }
            int diff = Math.Abs(oddSum - evenSum);
            if (oddSum == evenSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + oddSum);                                  
            }
            else
            {
              Console.WriteLine("No");
              Console.WriteLine("Diff = " + diff);
            }
        }
    }
}

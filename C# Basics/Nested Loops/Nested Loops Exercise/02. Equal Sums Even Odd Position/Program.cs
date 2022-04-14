using System;

namespace _02._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int num = start; num <= end; num++)
            {
                int currentNum = num;
                int oddSum = 0;
                int evenSum = 0;
                int count = 0;

                while (currentNum != 0)
                {
                    int digit = currentNum % 10;

                    if (count % 2 == 0)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddSum += digit;
                    }

                    currentNum /= 10;
                    count++;
                }

                if (evenSum == oddSum)
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}

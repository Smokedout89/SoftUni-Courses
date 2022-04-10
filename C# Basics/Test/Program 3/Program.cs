using System;

namespace _06._Barcode_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int fourthDigitFromNum1 = num1 % 10;
            int fourthDigitFromNum2 = num2 % 10;
            num1 /= 10;
            num2 /= 10;
            int thirdDigitFromNum1 = num1 % 10;
            int thirdDigitFromNum2 = num2 % 10;
            num1 /= 10;
            num2 /= 10;
            int secondDigitFromNum1 = num1 % 10;
            int secondDigitFromNum2 = num2 % 10;
            num1 /= 10;
            num2 /= 10;

            for (int i = num1; i <= num2; i++)
            {
                for (int j = secondDigitFromNum1; j <= secondDigitFromNum2; j++)
                {
                    for (int k = thirdDigitFromNum1; k <= thirdDigitFromNum2; k++)
                    {
                        for (int l = fourthDigitFromNum1; l <= fourthDigitFromNum2; l++)
                        {
                            if (i % 2 != 0 && j % 2 != 0 && k % 2 != 0 && l % 2 != 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}

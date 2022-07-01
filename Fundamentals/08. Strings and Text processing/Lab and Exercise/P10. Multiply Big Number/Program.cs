using System;

namespace P10._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputNum = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            string result = string.Empty;

            if (multiplier == 0)
            {
                //result = new string('0', inputNum.Length);
                Console.WriteLine(0);
            }

            int remainder = 0;

            for (int i = inputNum.Length - 1; i >= 0; i--)
            {
                int currNum = inputNum[i] - '0';

                int multiplied = multiplier * currNum;

                if (remainder != 0)
                {
                    multiplied += remainder;
                    remainder = 0;
                }

                int current = multiplied;

                if (multiplied > 9)
                {
                    current = multiplied % 10;
                    remainder = multiplied / 10;
                }

                result += current.ToString();
            }

            if (remainder != 0)
            {
                result += remainder;
            }

            char[] reverseIt = result.ToCharArray();
            Array.Reverse(reverseIt);

            if (multiplier != 0)
            {
                Console.WriteLine(reverseIt);
            }
        }
    }
}

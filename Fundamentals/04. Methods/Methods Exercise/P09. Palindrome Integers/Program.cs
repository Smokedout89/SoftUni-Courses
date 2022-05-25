using System;

namespace P09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                bool result = PalindromeIntegerChecker(input);
                Console.WriteLine(result.ToString().ToLower());
                input = Console.ReadLine();
            }
        }

        static bool PalindromeIntegerChecker(string number)
        {
            for (int i = 0; i < number.Length / 2; i++)
            {
                if (number[i] != number[number.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

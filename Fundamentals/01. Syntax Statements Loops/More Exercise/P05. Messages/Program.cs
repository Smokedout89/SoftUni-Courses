using System;

namespace P05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string output = string.Empty;

            for (int i = 1; i <= number; i++)
            {
                string input = Console.ReadLine();
                int currentNum = int.Parse(input);

                int mainDigit = currentNum % 10;
                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }

                offset = offset + (input.Length - 1) + 97;
                char letter = (char)offset;

                if (input == "0")
                {
                    output += " ";
                }
                else
                {
                    output += letter;
                }
            }

            Console.WriteLine(output);
        }
    }
}

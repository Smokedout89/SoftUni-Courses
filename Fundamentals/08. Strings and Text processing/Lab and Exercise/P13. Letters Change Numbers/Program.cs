using System;

namespace P13._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            decimal sum = 0;

            foreach (string word in words)
            {
                int firstNumPos = GetAlphabeticalPosition(word[0]);
                int lastNumPos = GetAlphabeticalPosition(word[word.Length - 1]);
                decimal number = GetNumberFromString(word);

                if (char.IsUpper(word[0]))
                {
                    number /= firstNumPos;
                }
                else if (char.IsLower(word[0]))
                {
                    number *= firstNumPos;
                }

                if (char.IsUpper(word[word.Length - 1]))
                {
                    number -= lastNumPos;
                }
                else if (char.IsLower(word[word.Length - 1]))
                {
                    number += lastNumPos;
                }

                sum += number;

            }

                Console.WriteLine($"{sum:f2}");
        }

        static int GetNumberFromString(string word)
        {
            int result;
            word = word.Substring(1, word.Length - 2);

            return result = int.Parse(word);
        }
        static int GetAlphabeticalPosition(char ch)
        {
            return char.ToLower(ch) - 96;
        }
    }
}

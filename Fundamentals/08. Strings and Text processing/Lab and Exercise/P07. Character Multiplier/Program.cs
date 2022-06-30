using System;

namespace P07._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int sum = 0;
            string firstWord = input[0];
            string secondWord = input[1];
            string longestWord = string.Empty;
            string shorterWord = string.Empty;

            if (firstWord.Length > secondWord.Length)
            {
                longestWord = firstWord;
                shorterWord = secondWord;
            }
            else
            {
                longestWord = secondWord;
                shorterWord = firstWord;
            }

            int counter = 0;

            for (int i = 0; i < shorterWord.Length; i++)
            {
                sum += firstWord[i] * secondWord[i];
                counter++;
            }

            for (int i = counter; i < longestWord.Length; i++)
            {
                sum += longestWord[i];
            }

            Console.WriteLine(sum);
        }
    }
}

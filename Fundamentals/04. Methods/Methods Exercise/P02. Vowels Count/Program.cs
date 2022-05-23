using System;
using System.Linq;

namespace P02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(VowelCount(input));
        }

        static int VowelCount(string input)
        {
            string word = input.ToLower();
            int count = 0;
            char[] vowels = new char[] { 'a', 'o', 'e', 'u', 'i' };

            foreach (char ch in word)
            {
                if (vowels.Contains(ch))
                {
                    count++;
                }
            }

           return count;
        }
    }
}

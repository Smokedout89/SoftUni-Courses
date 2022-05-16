using System;

namespace P01._Encrypt__Sort__and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sumOfLetters = new int[n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int sumOfVowels = 0;
                int sumOfConsonants = 0;

                foreach (char c in input)
                {
                    if (c == 'a' || c == 'e' || c == 'o' || c == 'i' || c == 'u' ||
                        c == 'A' || c == 'E' || c == 'O' || c == 'I' || c == 'U')
                    {
                        sumOfVowels += c * input.Length;
                    }
                    else
                    {
                        sumOfConsonants += c / input.Length;
                    }
                }

                int totalSum = sumOfConsonants + sumOfVowels;
                sumOfLetters[i] = totalSum;
            }

            Array.Sort(sumOfLetters);

            foreach (var item in sumOfLetters)
            {
                Console.WriteLine(item);
            }
        }
    }
}

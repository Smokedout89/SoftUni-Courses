using System;
using System.Text;

namespace P09._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
               char currCh = input[i];
               currCh += (char)3;
               result.Append(currCh);
            }

            Console.WriteLine(result);
        }
    }
}

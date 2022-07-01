using System;

namespace P11._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = string.Empty;
          
            for (int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    result += input[i];
                }
                else if (input[i] != input[i + 1])
                {
                    result += input[i];
                }
            }

            Console.WriteLine(result);
        }
    }
}

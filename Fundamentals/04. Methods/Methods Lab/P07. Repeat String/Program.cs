using System;
using System.Text;

namespace P07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeats = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatedString(input, repeats));
        }

        private static string RepeatedString(string input, int repeats)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < repeats; i++)
            {
                result.Append(input);
            }

            return result.ToString();
        }
    }
}

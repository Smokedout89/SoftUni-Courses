using System;

namespace P06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(MidCharacter(input));
        }

        static string MidCharacter(string input)
        {
            int index = input.Length / 2;
            string result = String.Empty;

            if (input.Length % 2 == 0)
            {
                result = input[index - 1].ToString() + input[index].ToString();
            }
            else
            {
                result = input[index].ToString();
            }

            return result;

        }
    }
}

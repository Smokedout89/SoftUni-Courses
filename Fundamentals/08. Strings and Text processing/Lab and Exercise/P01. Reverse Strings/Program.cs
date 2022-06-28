using System;

namespace P01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word != "end")
            {
                char[] reversed = word.ToCharArray();
                Array.Reverse(reversed);
                string result = new string(reversed);

                Console.WriteLine($"{word} = {result}");

                word = Console.ReadLine();
            }
        }
    }
}

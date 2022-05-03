using System;

namespace P04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                //char.ConvertFromUtf32(letter);
                sum += letter;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}

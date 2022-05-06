using System;

namespace P05._Decrypting_Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string result = string.Empty;

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                char letter = char.Parse(Console.ReadLine());
                sum = letter + key;
                result += (char)sum;
            }

            Console.WriteLine(result);
        }
    }
}

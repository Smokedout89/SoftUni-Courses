using System;

namespace P10._Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());

            if (char.IsLower(letter))
            {
                Console.WriteLine("lower-case");
            }

            if (char.IsUpper(letter))
            {
                Console.WriteLine("upper-case");
            }
        }
    }
}

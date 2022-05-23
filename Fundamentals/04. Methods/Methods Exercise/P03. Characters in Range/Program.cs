using System;
using System.ComponentModel;
using System.Threading.Channels;

namespace P03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char charOne = char.Parse(Console.ReadLine());
            char charTwo = char.Parse(Console.ReadLine());

            CharactersInRange(charOne, charTwo);
        }

        static void CharactersInRange(char charOne, char charTwo)
        {
            int first = Math.Min(charOne, charTwo);
            int second = Math.Max(charOne,charTwo);

            for (int i = ++first; i < second; i++)
            {
                Console.Write((char)i + " ");
            }

            Console.WriteLine();
        }
    }
}

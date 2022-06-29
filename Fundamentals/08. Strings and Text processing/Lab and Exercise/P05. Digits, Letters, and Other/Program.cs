using System;
using System.Text;

namespace P05._Digits__Letters__and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder others = new StringBuilder();

            foreach (char ch in input)
            {
                if (char.IsDigit(ch))
                {
                    digits.Append(ch);
                }
                else if (char.IsLetter(ch))
                {
                    letters.Append(ch);
                }
                else if (!char.IsLetterOrDigit(ch))
                {
                    others.Append(ch);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}

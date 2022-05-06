using System;

namespace P06._Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int openingBracketCount = 0;
            int closingBracketCount = 0;

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    openingBracketCount++;
                }
                else if (input == ")")
                {
                    closingBracketCount++;
                }

                if (closingBracketCount > openingBracketCount)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }

            }

            if (openingBracketCount == closingBracketCount)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}

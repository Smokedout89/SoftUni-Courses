using System;

namespace P02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstCh = char.Parse(Console.ReadLine());
            char secondCh = char.Parse(Console.ReadLine());
            string randomString = Console.ReadLine();

            int sum = 0;

            foreach (char ch in randomString)
            {
                if (ch > firstCh && ch < secondCh)
                {
                    sum += ch;
                }
            }

            Console.WriteLine(sum);
        }
    }
}

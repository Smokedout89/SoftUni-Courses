using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"!(?<name>[A-Z][a-z]{2,})!:\[(?<translate>[A-Za-z]{8,})\]");
            List<int> numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string name = regex.Match(input).Groups["name"].Value;

                if (regex.IsMatch(input))
                {
                    string toTranslate = regex.Match(input).Groups["translate"].Value;

                    foreach (char ch in toTranslate)
                    {
                        int currN = Convert.ToInt32(ch);
                        numbers.Add(currN);
                    }

                    Console.WriteLine($"{name}: {string.Join(' ', numbers)}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}

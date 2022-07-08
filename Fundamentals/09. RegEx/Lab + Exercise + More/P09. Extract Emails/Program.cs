using System;
using System.Text.RegularExpressions;

namespace P09._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-][A-Za-z]+)+))(\b|(?=\s))";
            //string pattern = @"(\s[a-z]+[\w.-]+\w)@([a-z]+[-a-z]*?([.][a-z]+)+)\b";
            string pattern = @"(?<=\s|^)[a-z0-9]+[\.\-_a-z0-9]+@[a-z\-]+\.([\.A-Za-z]+)+\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}

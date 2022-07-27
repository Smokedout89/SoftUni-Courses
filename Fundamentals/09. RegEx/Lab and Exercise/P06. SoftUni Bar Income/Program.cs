using System;
using System.Text.RegularExpressions;

namespace P06._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern =
                @"\%(?<name>[A-Z]{1}[a-z]+)\%[^|$%.]*?\<(?<product>\w+)\>[^|$%.]*?\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+(?:\.\d+)?)\$";
            string command;
            decimal income = 0;

            while ((command = Console.ReadLine()) != "end of shift")
            {
                MatchCollection matches = Regex.Matches(command, pattern);

                foreach (Match match in matches)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    Console.WriteLine($"{name}: {product} - {count * price:f2}");

                    income += (decimal)price * count;
                }
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}

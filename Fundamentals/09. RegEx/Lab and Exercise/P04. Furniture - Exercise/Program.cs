using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P04._Furniture___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @">>(?<product>[A-Z]([A-Z]+|[a-z]+))<<(?<price>([0-9]+[.|\][0-9]+))!(?<quantity>\d+)\b";
            // string regex = @">>(?<product>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";
            List<string> boughtFurniture = new List<string>();
            double total = 0;

            while (input != "Purchase")
            {
                MatchCollection matches = Regex.Matches(input, regex);
                foreach (Match match in matches)
                {
                    string product = match.Groups["product"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    total += price * quantity;
                    boughtFurniture.Add(product);
                }

                //Match match = Regex.Match(input, regex, RegexOptions.IgnoreCase);
                //if (match.Success)
                //{
                //    string product = match.Groups["product"].Value;
                //    double price = double.Parse(match.Groups["price"].Value);
                //    int quantity = int.Parse(match.Groups["quantity"].Value);
                //    total += price * quantity;
                //    boughtFurniture.Add(product);
                //}

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            if (boughtFurniture.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, boughtFurniture));
            }
            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}

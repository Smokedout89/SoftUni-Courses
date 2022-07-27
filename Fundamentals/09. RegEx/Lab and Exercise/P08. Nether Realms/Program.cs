using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P08._Nether_Realms
{
    class Demon
    {
        public Demon(int health, double damage)
        {
            this.Health = health;
            this.Damage = damage;
        }
        public int Health { get; set; }

        public double Damage { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Demon> demonBook = new SortedDictionary<string, Demon>();

            string[] demons = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string demon in demons)
            {
                demonBook.Add(demon, new Demon(GetDemonHealth(demon), GetDemonDamage(demon)));
            }

            foreach (KeyValuePair<string, Demon> keyValuePair in demonBook)
            {
                Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value.Health} health, {keyValuePair.Value.Damage:f2} damage");
            }
        }

        static int GetDemonHealth(string demon)
        {
            int health = 0;

            foreach (char ch in demon)
            {
                if (!char.IsDigit(ch) && ch != '+' && ch != '-' && ch != '*' && ch != '/' && ch != '.')
                {
                    health += ch;
                }
            }

            return health;
        }

        static double GetDemonDamage(string demon)
        {
            string numbersPattern = @"-?\d+\.?\d*";
            string operatorPattern = @"[*/]";

            MatchCollection matches = Regex.Matches(demon, numbersPattern);
            MatchCollection operatorMatch = Regex.Matches(demon, operatorPattern);
            double damage = 0;

            foreach (Match match in matches)
            {
                damage += double.Parse(match.Value);
            }

            foreach (Match match in operatorMatch)
            {
                if (match.Value == "*")
                {
                    damage *= 2;
                }
                else if (match.Value == "/")
                {
                    damage /= 2;
                }
            }

            return damage;
        }
    }
}

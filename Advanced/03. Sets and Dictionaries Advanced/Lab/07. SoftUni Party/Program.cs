using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> VIP = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (char.IsDigit(input.First()))
                {
                    VIP.Add(input);
                }
                else
                {
                    regular.Add(input);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                if (regular.Contains(input))
                {
                    regular.Remove(input);
                }

                if (VIP.Contains(input))
                {
                    VIP.Remove(input);
                }

                input = Console.ReadLine();
            }

            int guestsNotAttended = regular.Count + VIP.Count;

            Console.WriteLine(guestsNotAttended);

            foreach (var guest in VIP)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regular)
            {
                Console.WriteLine(guest);
            }
        }
    }
}

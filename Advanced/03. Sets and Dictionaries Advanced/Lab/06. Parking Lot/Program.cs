using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _06._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> parking = new HashSet<string>();

            while (input != "END")
            {
                string[] info = Regex.Split(input, ", ");

                if (info[0] == "IN")
                {
                    parking.Add(info[1]);
                }
                else
                {
                    parking.Remove(info[1]);
                }

                input = Console.ReadLine();
            }

            if (parking.Count > 0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine($"{car}");
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

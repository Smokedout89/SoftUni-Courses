using System;
using System.Collections.Generic;

namespace P09._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> parkingLot = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string command = cmdArgs[0];
                string username = cmdArgs[1];

                if (command == "register")
                {
                    string licensePlate = cmdArgs[2];

                    if (parkingLot.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                        continue;
                    }

                    parkingLot.Add(username, licensePlate);
                    Console.WriteLine($"{username} registered {licensePlate} successfully");
                }

                if (command == "unregister")
                {
                    if (!parkingLot.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                        continue;
                    }

                    parkingLot.Remove(username);
                    Console.WriteLine($"{username} unregistered successfully");
                }
            }

            foreach (var car in parkingLot)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}

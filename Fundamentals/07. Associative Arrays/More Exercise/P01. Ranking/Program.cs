using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwords = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userPoints = new Dictionary<string, Dictionary<string, int>>();

            string passwordsInput = Console.ReadLine();

            while (passwordsInput != "end of contests")
            {
                string[] input = passwordsInput.Split(':');
                string contest = input[0];
                string password = input[1];

                passwords.Add(contest,password);

                passwordsInput = Console.ReadLine();
            }

            string pointsInput = Console.ReadLine();

            while (pointsInput != "end of submissions")
            {
                string[] cmdArgs = pointsInput.Split("=>");
                string contest = cmdArgs[0];
                string password = cmdArgs[1];
                string name = cmdArgs[2];
                int points = int.Parse(cmdArgs[3]);

                if (passwords.ContainsKey(contest) && passwords[contest] == password)
                {
                    if (!userPoints.ContainsKey(name))
                    {
                        userPoints.Add(name, new Dictionary<string, int>());
                    }

                    if (!userPoints[name].ContainsKey(contest))
                    {
                        userPoints[name].Add(contest, 0);
                    }

                    if (userPoints[name][contest] < points)
                    {
                        userPoints[name][contest] = points;
                    }
                }

                pointsInput = Console.ReadLine();
            }

            foreach (var user in userPoints.OrderByDescending(kvp => kvp.Value.Values.Sum()))
            {
                Console.WriteLine($"Best candidate is {user.Key} with total {user.Value.Values.Sum()} points.");
                break;
            }

            Console.WriteLine("Ranking: ");

            foreach (var student in userPoints.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{student.Key}");

                foreach (var kvp in student.Value.OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}

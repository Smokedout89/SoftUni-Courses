using System;
using System.Collections.Generic;
using System.Linq;

namespace P02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestInfo = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> individualStanding = new Dictionary<string, Dictionary<string, int>>();

            string command;

            while ((command = Console.ReadLine()) != "no more time")
            {
                string[] cmdArgs = command.Split(" -> ");
                string student = cmdArgs[0];
                string contest = cmdArgs[1];
                int points = int.Parse(cmdArgs[2]);

                if (!contestInfo.ContainsKey(contest))
                {
                    contestInfo.Add(contest, new Dictionary<string, int>());
                }

                if (!contestInfo[contest].ContainsKey(student))
                {
                    contestInfo[contest].Add(student, 0);
                }

                if (contestInfo[contest][student] < points)
                {
                    contestInfo[contest][student] = points;
                }

                if (!individualStanding.ContainsKey(student))
                {
                    individualStanding.Add(student, new Dictionary<string, int>());
                }

                if (!individualStanding[student].ContainsKey(contest))
                {
                    individualStanding[student].Add(contest, 0);
                }

                if (individualStanding[student][contest] < points)
                {
                    individualStanding[student][contest] = points;
                }

            }

            foreach (var contest in contestInfo)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                int index = 1;

                foreach (var student in contest.Value.OrderByDescending(points => points.Value).ThenBy(name => name.Key))
                {
                    Console.WriteLine($"{index}. {student.Key} <::> {student.Value}");
                    index++;
                }
            }

            Console.WriteLine("Individual standings:");

            int individualIndex = 1;

            foreach (var student in individualStanding.OrderByDescending(totalpts => totalpts.Value.Values.Sum()).ThenBy(name => name.Key))
            {
                Console.WriteLine($"{individualIndex}. {student.Key} -> {student.Value.Values.Sum()}");
                individualIndex++;
            }
        }
    }
}

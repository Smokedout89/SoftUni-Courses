using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            Dictionary<string, int[]> vloggersInfo = new Dictionary<string, int[]>();
            Dictionary<string, List<string>> followers = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[1];

                if (action == "joined")
                {
                    string vlogger = cmdArgs[0];

                    if (!vloggersInfo.ContainsKey(vlogger))
                    {
                        vloggersInfo.Add(vlogger, new int[2]);
                        followers.Add(vlogger, new List<string>());
                    }
                }

                if (action == "followed")
                {
                    string vlogger = cmdArgs[0];
                    string followedVlogger = cmdArgs[2];

                    if (!vloggersInfo.ContainsKey(vlogger) || !vloggersInfo.ContainsKey(followedVlogger))
                    {
                        continue;
                    }

                    if (vlogger == followedVlogger)
                    {
                        continue;
                    }

                    if (followers[followedVlogger].Contains(vlogger))
                    {
                        continue;
                    }

                    if (!followers[followedVlogger].Contains(vlogger))
                    {
                        followers[followedVlogger].Add(vlogger);
                        vloggersInfo[vlogger][0]++;
                        vloggersInfo[followedVlogger][1]++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggersInfo.Keys.Count} vloggers in its logs.");

            int vloggerIndex = 1;

            foreach (var vlogger in vloggersInfo.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Value[0]))
            {
                Console.WriteLine($"{vloggerIndex}. {vlogger.Key} : {vlogger.Value[1]} followers, {vlogger.Value[0]} following");

                if (vloggerIndex == 1)
                {
                    foreach (var follower in followers[vlogger.Key].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {string.Join("\n", follower)}");
                    }
                }

                vloggerIndex++;
            }
        }
    }
}

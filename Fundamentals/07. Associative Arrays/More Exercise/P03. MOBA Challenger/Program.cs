using System;
using System.Linq;
using System.Collections.Generic;

namespace P03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playersDetails = new Dictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();

            while (command != "Season end")
            {
                if (command.Contains(" -> "))
                {
                    string[] cmdArgs = command.Split(" -> ");
                    string playerName = cmdArgs[0];
                    string position = cmdArgs[1];
                    int skill = int.Parse(cmdArgs[2]);

                    if (!playersDetails.ContainsKey(playerName))
                    {
                        playersDetails.Add(playerName, new Dictionary<string, int>());
                    }

                    if (!playersDetails[playerName].ContainsKey(position))
                    {
                        playersDetails[playerName].Add(position, 0);
                    }

                    if (playersDetails[playerName][position] < skill)
                    {
                        playersDetails[playerName][position] = skill;
                    }

                }
                else if (command.Contains(" vs "))
                {
                    string[] cmdArgs = command.Split(" vs ");
                    string playerOne = cmdArgs[0];
                    string playerTwo = cmdArgs[1];

                    if (playersDetails.ContainsKey(playerOne) && playersDetails.ContainsKey(playerTwo))
                    {
                        foreach (var position in playersDetails[playerOne].Keys)
                        {
                            if (playersDetails[playerTwo].ContainsKey(position))
                            {
                                if (playersDetails[playerOne].Values.Sum() > playersDetails[playerTwo].Values.Sum())
                                {
                                    playersDetails.Remove(playerTwo);
                                }
                                else if (playersDetails[playerTwo].Values.Sum() > playersDetails[playerOne].Values.Sum())
                                {
                                    playersDetails.Remove(playerOne);
                                }

                                break;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var player in playersDetails.OrderByDescending(skill => skill.Value.Values.Sum()).ThenBy(name => name.Key))
            {

                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var kvp in player.Value.OrderByDescending(skill => skill.Value).ThenBy(pos => pos.Key))
                {
                    Console.WriteLine($"- {kvp.Key} <::> {kvp.Value}");
                }
            }
        }
    }
}

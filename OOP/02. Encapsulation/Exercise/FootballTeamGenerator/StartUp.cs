using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            while (input != "END")
            {
                try
                {
                    string[] inputArgs = input.Split(';');
                    string command = inputArgs[0];
                    string teamName = inputArgs[1];

                    if (command == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(teamName, team);
                    }
                    else if (command == "Add")
                    {
                        string playerName = inputArgs[2];

                        if (!ValidateTeamName(teams, teamName))
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        int endurance = int.Parse(inputArgs[3]);
                        int sprint = int.Parse(inputArgs[4]);
                        int dribble = int.Parse(inputArgs[5]);
                        int passing = int.Parse(inputArgs[6]);
                        int shooting = int.Parse(inputArgs[7]);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teams[teamName].AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        string playerName = inputArgs[2];

                        if (!ValidateTeamName(teams, teamName))
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        bool removed = teams[teamName].RemovePlayer(playerName);

                        if (!removed)
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                        }
                    }
                    else if (command == "Rating")
                    {
                        if (!ValidateTeamName(teams, teamName))
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine($"{teamName} - {teams[teamName].Stats}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }

        private static bool ValidateTeamName(Dictionary<string, Team> teams, string teamName)
        {
            if (!teams.ContainsKey(teamName))
            {
                Console.WriteLine(($"Team {teamName} does not exist."));
                return false;
            }

            return true;
        }
    }
}

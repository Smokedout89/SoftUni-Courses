using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Teamwork_Projects
{
    class Team
    {
        public Team(string teamName, string teamCreator)
        {
            this.Name = teamName;
            this.Creator = teamCreator;

            this.Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }

        public void AddMember(string member)
        {
            this.Members.Add(member);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            RegisterTeam(teams, teamsCount);

            JoiningTeam(teams);

            List<Team> teamWithMembers = teams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name)
                .ToList();

            List<Team> teamsToDisband = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)
                .ToList();

            foreach (Team validTeams in teamWithMembers)
            {
                Console.WriteLine($"{validTeams.Name}");
                Console.WriteLine($"- {validTeams.Creator}");

                foreach (string currMember in validTeams.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {currMember}");
                }
            }

            Console.WriteLine($"Teams to disband:");

            foreach (Team invalidTeam in teamsToDisband)
            {
                Console.WriteLine($"{invalidTeam.Name}");
            }
        }

        static void RegisterTeam(List<Team> teams, int teamsCount)
        {
            for (int i = 0; i < teamsCount; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split('-');
                string teamName = cmdArgs[1];
                string teamCreator = cmdArgs[0];

                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;

                }

                // Both of this if statements can be done with foreach loop

                if (teams.Any(c => c.Creator == teamCreator))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                    continue;
                }

                teams.Add(new Team(teamName, teamCreator));
                Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
            }
        }

        static void JoiningTeam(List<Team> teams)
        {
            string command;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] cmdArgs = command.Split("->");
                string memberName = cmdArgs[0];
                string teamName = cmdArgs[1];

                Team teamToJoin = teams.FirstOrDefault(t => t.Name == teamName);

                if (teamToJoin == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                // Short version, down is the same with bool and foreach
                //if (teams.Any(t => t.Members.Contains(memberName)))
                //{
                //    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                //    continue;
                //}

                bool isAlreadyMember = false;

                foreach (Team team in teams)
                {
                    if (team.Members.Contains(memberName))
                    {
                        isAlreadyMember = true;
                    }
                }

                if (isAlreadyMember)
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                if (teams.Any(c => c.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                teamToJoin.AddMember(memberName);
            }
        }
    }
}

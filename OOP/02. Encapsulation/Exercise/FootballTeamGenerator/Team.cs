using System;
using System.Linq;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public int Stats => players.Any()
            ? (int) Math.Round(players.Average(s => s.Stats))
            : 0;

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(n => n.Name == name);
            return players.Remove(player);
        }

        public void AddPlayer(Player player) => players.Add(player);
    }
}

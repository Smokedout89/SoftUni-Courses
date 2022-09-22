using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player toRemove = roster.Find(n => n.Name == name);
            return roster.Remove(toRemove);
        }

        public void PromotePlayer(string name)
        {
            Player toPromote = roster.Find(n => n.Name == name);

            if (toPromote.Rank == "Member")
            {
                return;
            }

            toPromote.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            Player toDemote = roster.Find(n => n.Name == name);

            if (toDemote.Rank == "Trial")
            {
                return;
            }

            toDemote.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] toReturn = roster.FindAll(c => c.Class == @class).ToArray();
            roster.RemoveAll(c => c.Class == @class);
            return toReturn;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

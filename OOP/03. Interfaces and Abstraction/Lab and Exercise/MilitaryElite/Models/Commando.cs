using System.Linq;
using MilitaryElite.Enums;
using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<IMission>();
        }

        public List<IMission> Missions { get; set; }
        public void CompleteMission(string codeName)
        {
            var mission = Missions.FirstOrDefault(cn => cn.CodeName == codeName);

            if (mission != null)
            {
                mission.State = State.Finished;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string baseInfo = base.ToString();

            sb
                .AppendLine(baseInfo)
                .AppendLine($"Corps: {Corps}")
                .AppendLine($"Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
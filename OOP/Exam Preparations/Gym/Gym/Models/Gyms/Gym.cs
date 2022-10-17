namespace Gym.Models.Gyms
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using Athletes.Contracts;
    using Equipment.Contracts;

    public abstract class Gym : IGym
    {
        private string name;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Equipment = new List<IEquipment>();
            Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => Equipment.Select(w => w.Weight).Sum();

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {this.GetType().Name}:");

            string athletes;

            if (Athletes.Count > 0)
            {
                athletes = string.Join(", ", Athletes.Select(a => a.FullName));
            }
            else
            {
                athletes = "No athletes";
            }

            sb
                .AppendLine($"Athletes: {athletes}")
                .AppendLine($"Equipment total count: {Equipment.Count}")
                .AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}
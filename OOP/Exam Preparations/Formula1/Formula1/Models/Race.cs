namespace Formula1.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Utilities;
    using Models.Contracts;

    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => this.raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => this.numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; } = false;

        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot) => pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            string tookPlace = TookPlace ? "Yes" : "No";

            sb
                .AppendLine($"The {RaceName} race has:")
                .AppendLine($"Participants: {pilots.Count}")
                .AppendLine($"Number of laps: {NumberOfLaps}")
                .AppendLine($"Took place: {tookPlace}");

            return sb.ToString().TrimEnd();
        }
    }
}
using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private readonly int endurance;
        private readonly int sprint;
        private readonly int dribble;
        private readonly int passing;
        private readonly int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.name = name;

            CheckValidStats("Endurance", endurance);
            CheckValidStats("Sprint", sprint);
            CheckValidStats("Dribble", dribble);
            CheckValidStats("Passing", passing);
            CheckValidStats("Shooting", shooting);

            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
        }

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

        public double Stats => (endurance + sprint + dribble + passing + shooting) / 5.0;

        public void CheckValidStats(string name, int stat)
        {
            if (stat < 0 || stat > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }
    }
}

namespace SpaceStation.Models
{
    using System;

    using Bags.Contracts;
    using Utilities.Messages;
    using Astronauts.Contracts;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            Bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                oxygen = value;
            }
        }

        public bool CanBreath => oxygen > 0;

        public IBag Bag { get; }

        public virtual void Breath()
        {
            oxygen -= 10;

            if (oxygen < 0)
            {
                oxygen = 0;
            }
        }
    }
}
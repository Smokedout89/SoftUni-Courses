namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Dyes.Contracts;
    using Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private readonly ICollection<IDye> dyes;

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes = new List<IDye>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                name = value;
            }
        }

        public int Energy
        {
            get => energy;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                energy = value;
            }
        }

        public ICollection<IDye> Dyes => dyes;

        public virtual void Work()
        {
            Energy -= 10;
        }

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }
    }
}
namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Decorations.Contracts;
    using Fish.Contracts;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly ICollection<IDecoration> decorations;
        private readonly ICollection<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fish;

        public void AddFish(IFish fish)
        {
            if (this.fish.Count + 1 > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public bool RemoveFish(IFish fish) => this.fish.Remove(fish);

        public void AddDecoration(IDecoration decoration) => decorations.Add(decoration);

        public void Feed()
        {
            foreach (var currFish in fish)
            {
                currFish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string emptyOrNot = fish.Any()
                ? string.Join(", ", fish.Select(n => n.Name))
                : "none";

            sb
                .AppendLine($"{Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {emptyOrNot}")
                .AppendLine($"Decorations: {decorations.Count}")
                .AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
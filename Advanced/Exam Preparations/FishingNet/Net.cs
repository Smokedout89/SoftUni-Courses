using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly List<Fish> fish;

        public List<Fish> Fish { get { return fish; } }

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }
        public string Material { get; set; }

        public int Capacity { get; set; }

        public int Count => fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (this.fish.Count + 1 > Capacity)
            {
                return "Fishing net is full.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            return fish.Remove(fish.FirstOrDefault(w => w.Weight == weight));
        }

        public Fish GetFish(string fishType)
        {
            return fish.FirstOrDefault(t => t.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return fish.OrderByDescending(l => l.Length).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Into the {Material}:");

            foreach (var item in Fish.OrderByDescending(l => l.Length))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

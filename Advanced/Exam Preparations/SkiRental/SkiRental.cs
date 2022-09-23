using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> skiList;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            skiList = new List<Ski>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => skiList.Count;

        public void Add(Ski ski)
        {
            if (skiList.Count < Capacity)
            {
                skiList.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return skiList.Remove(skiList.FirstOrDefault(m => m.Manufacturer == manufacturer && m.Model == model));
        }

        public Ski GetNewestSki()
        {
            var newest = skiList.OrderByDescending(a => a.Year).FirstOrDefault();

            return newest;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            var ski = skiList.FirstOrDefault(m => m.Manufacturer == manufacturer && m.Model == model);

            return ski;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in skiList)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

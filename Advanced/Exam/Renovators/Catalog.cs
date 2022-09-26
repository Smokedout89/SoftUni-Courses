using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name))
            {
                return "Invalid renovator's information.";
            }

            if (string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (renovators.Count + 1 > NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            return renovators.Remove(renovators.FirstOrDefault(n => n.Name == name));
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            return renovators.RemoveAll(t => t.Type == type);
        }

        public Renovator HireRenovator(string name)
        {
            var toHire = renovators.FirstOrDefault(n => n.Name == name);
            if (toHire == null)
            {
                return null;
            }
            toHire.Hired = true;
            return toHire;
        }

        public List<Renovator> PayRenovators(int days)
        {
            var payed = renovators.Where(d => d.Days >= days);
            return payed.ToList();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            var notHired = renovators.Where(d => !d.Hired);

            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in notHired)
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

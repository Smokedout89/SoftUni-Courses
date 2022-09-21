using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public int Count => drones.Count;

        public string AddDrone(Drone drone)
        {
            if (drone.Name == null || drone.Brand == null || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (drones.Count == Capacity)
            {
                return "Airfield is full.";
            }

            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone currDrone = drones.FirstOrDefault(n => n.Name == name);
            return drones.Remove(currDrone);
        }

        public int RemoveDroneByBrand(string brand)
        {
            return drones.RemoveAll(b => b.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            Drone droneToFly = drones.FirstOrDefault(n => n.Name == name);
            if (droneToFly != null)
            {
                droneToFly.Available = false;
            }
            return droneToFly;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesToFly = drones.FindAll(r => r.Range >= range);
            foreach (var drone in dronesToFly)
            {
                drone.Available = false;
            }
            return dronesToFly;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {Name}:");

            foreach (var drone in drones.Where(a => a.Available))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

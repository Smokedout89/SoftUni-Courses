using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            participants = new List<Car>();
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count => participants.Count;

        public void Add(Car car)
        {
            if (participants.Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            return participants.Remove(participants.FirstOrDefault(l => l.LicensePlate == licensePlate));
        }

        public Car FindParticipant(string licensePlate)
        {
            return participants.FirstOrDefault(l => l.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return participants.OrderByDescending(h => h.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var participant in participants)
            {
                sb.AppendLine(participant.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

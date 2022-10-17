namespace Gym.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Gyms;
    using Repositories;
    using Models.Athletes;
    using Models.Equipment;
    using Utilities.Messages;
    using Models.Gyms.Contracts;
    using Models.Equipment.Contracts;

    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
            }
            else if (gymType == "WeightliftingGym")
            {
                gyms.Add(new WeightliftingGym(gymName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            return $"Successfully added {gymType}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                equipment.Add(new BoxingGloves());
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment.Add(new Kettlebell());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            return $"Successfully added {equipmentType}.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment currEquipment = equipment.FindByType(equipmentType);

            if (currEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            gym.AddEquipment(currEquipment);
            equipment.Remove(currEquipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        { 
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            bool isAdded = false;

            if (athleteType == "Boxer")
            {
                if (gym.GetType().Name == nameof(BoxingGym))
                {
                    isAdded = true;
                    Boxer boxer = new Boxer(athleteName, motivation, numberOfMedals);
                    gym.AddAthlete(boxer);
                }
            }
            else if (athleteType == "Weightlifter")
            {
                if (gym.GetType().Name == nameof(WeightliftingGym))
                {
                    isAdded = true;
                    Weightlifter weightlifter = new Weightlifter(athleteName, motivation, numberOfMedals);
                    gym.AddAthlete(weightlifter);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (isAdded)
            {
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }

            return OutputMessages.InappropriateGym;
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
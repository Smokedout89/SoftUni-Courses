namespace CarRacing.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Models;
    using Contracts;
    using Models.Maps;
    using Repositories;
    using Models.Racers;
    using Utilities.Messages;
    using Models.Maps.Contracts;
    using Models.Cars.Contracts;
    using Models.Racers.Contracts;

    public class Controller : IController
    {
        private readonly CarRepository cars;
        private readonly RacerRepository racers;
        private readonly IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;

            if (type == nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);
            IRacer racer = null;

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type == nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == nameof(StreetRacer))
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            string result = map.StartRace(racerOne, racerTwo);

            return result;
        }

        public string Report()
        {
            var orderedRacers = racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(u => u.Username);

            StringBuilder sb = new StringBuilder();

            foreach (var racer in orderedRacers)
            {
                sb
                    .AppendLine($"{racer.GetType().Name}: {racer.Username}")
                    .AppendLine($"--Driving behavior: {racer.RacingBehavior}")
                    .AppendLine($"--Driving experience: {racer.DrivingExperience}")
                    .AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
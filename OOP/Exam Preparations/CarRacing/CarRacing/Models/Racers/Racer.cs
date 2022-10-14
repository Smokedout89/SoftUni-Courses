namespace CarRacing.Models.Racers
{
    using System;
    using Cars.Contracts;
    using Contracts;
    using Utilities.Messages;

    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }

                username = value;
            }
        }
        public string RacingBehavior
        {
            get => racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }

                racingBehavior = value;
            }
        }
        public int DrivingExperience
        {
            get => drivingExperience;
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                drivingExperience = value;
            }
        }
        public ICar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                car = value;
            }
        }
        public virtual void Race()
        {
            this.Car.Drive();
        }

        public bool IsAvailable() => this.Car.FuelAvailable > this.Car.FuelConsumptionPerRace;
    }
}
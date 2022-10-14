namespace CarRacing.Models.Maps
{
    using Contracts;
    using Racers;
    using Racers.Contracts;
    using Utilities.Messages;

    public class Map : IMap
    {
        private const double StrictMultiplier = 1.2;
        private const double AggresiveMultiplier = 1.1;

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username );
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            double racerOneScore = 0;
            double racerTwoScore = 0;

            if (racerOne.GetType().Name == nameof(StreetRacer))
            { 
                racerOneScore = racerOne.Car.HorsePower * racerOne.DrivingExperience * AggresiveMultiplier;
            }
            else
            {
                racerOneScore = racerOne.Car.HorsePower * racerOne.DrivingExperience * StrictMultiplier;
            }

            if (racerTwo.GetType().Name == nameof(StreetRacer))
            {
                racerTwoScore = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * AggresiveMultiplier;
            }
            else
            {
                racerTwoScore = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * StrictMultiplier;
            }

            racerOne.Race();
            racerTwo.Race();

           return racerOneScore > racerTwoScore
                ? string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username)
                : string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
        }
    }
}
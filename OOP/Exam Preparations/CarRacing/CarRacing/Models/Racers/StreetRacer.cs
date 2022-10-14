namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const int StreetRacerDrivingExp = 10;
        private const string StreetRacerBehavior = "aggressive";
        

        public StreetRacer(string username, ICar car) 
            : base(username, StreetRacerBehavior, StreetRacerDrivingExp, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
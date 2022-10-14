namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const int ProffesionalRacerDrivingExp = 30;
        private const string ProffesionalRacerBehavior = "strict";

        public ProfessionalRacer(string username, ICar car) 
            : base(username, ProffesionalRacerBehavior, ProffesionalRacerDrivingExp, car) 
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
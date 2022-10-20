namespace PlanetWars.Models.MilitaryUnits
{
    public class StormTroopers : MilitaryUnit
    {
        private const double StormTrooperCost = 2.5;

        public StormTroopers() 
            : base(StormTrooperCost)
        {
        }
    }
}
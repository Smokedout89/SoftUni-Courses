namespace PlanetWars.Models.MilitaryUnits
{
    public class SpaceForces : MilitaryUnit
    {
        private const double SpaceForceCost = 11;

        public SpaceForces() 
            : base(SpaceForceCost)
        {
        }
    }
}
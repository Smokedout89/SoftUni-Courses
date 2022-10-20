namespace PlanetWars.Models.MilitaryUnits
{
    public class AnonymousImpactUnit : MilitaryUnit
    {
        private const double AnonymousUnitPrice = 30;

        public AnonymousImpactUnit() 
            : base(AnonymousUnitPrice)
        {
        }
    }
}
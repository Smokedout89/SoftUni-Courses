namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        private const double SpaceMisslePrice = 8.75;

        public SpaceMissiles(int destructionLevel) 
            : base(destructionLevel, SpaceMisslePrice)
        {
        }
    }
}
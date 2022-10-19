namespace SpaceStation.Models
{
    public class Geodesist : Astronaut
    {
        private const int GeodesistOxygen = 50;

        public Geodesist(string name) 
            : base(name, GeodesistOxygen)
        {
        }
    }
}
namespace SpaceStation.Models
{
    public class Meteorologist : Astronaut
    {
        private const int MeteorologistOxygen = 90;

        public Meteorologist(string name) 
            : base(name, MeteorologistOxygen)
        {
        }
    }
}
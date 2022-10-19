namespace SpaceStation.Models
{
    public class Biologist : Astronaut
    {
        private const int BiologistOxygen = 70;


        public Biologist(string name) 
            : base(name, BiologistOxygen)
        {
        }

        public override void Breath()
        {
           Oxygen -= 5;
        }
    }
}
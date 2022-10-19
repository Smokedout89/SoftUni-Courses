namespace SpaceStation.Models.Mission
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Planets.Contracts;
    using Astronauts.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Count > 0)
                {
                    astronaut.Bag.Items.Add(planet.Items.First());
                    planet.Items.Remove(planet.Items.First());
                    astronaut.Breath();
                }
            }
        }
    }
}
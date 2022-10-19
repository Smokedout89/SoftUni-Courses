namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Models;
    using Contracts;
    using Repositories;
    using Models.Mission;
    using Utilities.Messages;
    using Models.Mission.Contracts;
    using Models.Planets.Contracts;
    using Models.Astronauts.Contracts;

    public class Controller : IController
    {
        private readonly AstronautRepository astronauts;
        private readonly PlanetRepository planets;
        private int exploredPlanets = 0;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type == nameof(Biologist))
            {
                astronauts.Add(new Biologist(astronautName));
            }
            else if (type == nameof(Geodesist))
            {
                astronauts.Add(new Geodesist(astronautName));
            }
            else if (type == nameof(Meteorologist))
            {
                astronauts.Add(new Meteorologist(astronautName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronauntToRemove = astronauts.FindByName(astronautName);

            if (astronauntToRemove == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronauntToRemove);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> exploringAstronauts = astronauts.Models.Where(o => o.Oxygen > 60).ToList();
            IPlanet exploringPlanet = planets.FindByName(planetName);

            if (!exploringAstronauts.Any()) 
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IMission mission = new Mission();
            mission.Explore(exploringPlanet, exploringAstronauts);
            exploredPlanets++;

            int deadAstronauts = exploringAstronauts.Where(o => o.Oxygen == 0).Count();

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{exploredPlanets} planets were explored!")
                .AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                string items = astronaut.Bag.Items.Any()
                    ? string.Join(", ", astronaut.Bag.Items)
                    : "none";

                sb
                    .AppendLine($"Name: {astronaut.Name}")
                    .AppendLine($"Oxygen: {astronaut.Oxygen}")
                    .AppendLine($"Bag items: {items}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
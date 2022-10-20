    namespace PlanetWars.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.MilitaryUnits;
    using Models.MilitaryUnits.Contracts;
    using Models.Planets;
    using Models.Planets.Contracts;
    using Models.Weapons;
    using Models.Weapons.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);

            if (planets.Models.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            IMilitaryUnit unit = null;

            if (planet == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Any(t => t.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            planet.Spend(unit.Cost);

            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);
            IWeapon weapon = null;

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(n => n.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            planet.Spend(weapon.Price);

            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);

            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            bool firstPlanetWon;

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                bool firstPlanetNuclear = firstPlanet.Weapons.Any(n => n.GetType().Name == nameof(NuclearWeapon));
                bool secondPlanetNuclear = secondPlanet.Weapons.Any(n => n.GetType().Name == nameof(NuclearWeapon));

                if (firstPlanetNuclear && secondPlanetNuclear)
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return string.Format(OutputMessages.NoWinner);
                }

                if (!firstPlanetNuclear && !secondPlanetNuclear)
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return string.Format(OutputMessages.NoWinner);
                }

                if (firstPlanetNuclear && !secondPlanetNuclear)
                {
                    firstPlanetWon = true;

                    return PrintWinner(firstPlanet, secondPlanet, firstPlanetWon);
                }

                if (!firstPlanetNuclear && secondPlanetNuclear)
                {
                    firstPlanetWon = false;

                    return PrintWinner(firstPlanet, secondPlanet, firstPlanetWon);
                }
            }

            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                firstPlanetWon = true;

                return PrintWinner(firstPlanet, secondPlanet, firstPlanetWon);
            }
            else
            {
                firstPlanetWon = false;

                return PrintWinner(firstPlanet, secondPlanet, firstPlanetWon);
            }
        }

        public string ForcesReport()
        {
            var orderedPlanets = planets.Models
                .OrderByDescending(m => m.MilitaryPower)
                .ThenBy(n => n.Name);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string PrintWinner(IPlanet firstPlanet, IPlanet secondPlanet, bool firstPlanetWon)
        {
            if (firstPlanetWon)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Army.Sum(p => p.Cost)
                                   + secondPlanet.Weapons.Sum(p => p.Price));

                planets.RemoveItem(secondPlanet.Name);

                return string.Format(OutputMessages.WinnigTheWar, firstPlanet.Name, secondPlanet.Name);
            }
            else
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Army.Sum(p => p.Cost)
                                    + firstPlanet.Weapons.Sum(p => p.Price));

                planets.RemoveItem(firstPlanet.Name);

                return string.Format(OutputMessages.WinnigTheWar, secondPlanet.Name, firstPlanet.Name);
            }
        }
    }
}
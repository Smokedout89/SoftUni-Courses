namespace PlanetWars.Models.Planets
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using MilitaryUnits;
    using MilitaryUnits.Contracts;
    using Repositories;
    using Utilities.Messages;
    using Weapons;
    using Weapons.Contracts;

    public class Planet : IPlanet
    {
        private readonly UnitRepository units;
        private readonly WeaponRepository weapons;
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit) => units.AddItem(unit);

        public void AddWeapon(IWeapon weapon) => weapons.AddItem(weapon);

        public void TrainArmy()
        {
            foreach (var unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            budget -= amount;
        }

        public void Profit(double amount)
        {
            budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string unitsOrNo = Army.Count == 0
                ? "No units"
                : string.Join(", ", units.Models.Select(n => n.GetType().Name));

            string weaponsOrNo = Weapons.Count == 0
                ? "No weapons"
                : string.Join(", ", weapons.Models.Select(n => n.GetType().Name));

            sb
                .AppendLine($"Planet: {Name}")
                .AppendLine($"--Budget: {Budget} billion QUID")
                .AppendLine($"--Forces: {unitsOrNo}")
                .AppendLine($"--Combat equipment: {weaponsOrNo}")
                .AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        private double CalculateMilitaryPower()
        {
            double totalPower =
                units.Models.Sum(e => e.EnduranceLevel) + weapons.Models.Sum(d => d.DestructionLevel);

            if (units.Models.Any(t => t.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalPower *= 1.3;
            }

            if (weapons.Models.Any(t => t.GetType().Name == nameof(NuclearWeapon)))
            {
                totalPower *= 1.45;
            }

            totalPower = Math.Round(totalPower, 3);

            return totalPower;
        }
    }
}
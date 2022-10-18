namespace Heroes.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Repositories;
    using Models.Map;
    using Models.Heroes;
    using Models.Weapons;
    using Models.Contracts;
    public class Controller : IController
    {
        private readonly HeroRepository heroes;
        private readonly WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            Hero hero = null;

            if (type == nameof(Knight))
            {
                hero = new Knight(name, health, armour);
            }
            else if (type == nameof(Barbarian))
            {
                hero = new Barbarian(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            heroes.Add(hero);

            if (type == nameof(Knight))
            {
                return $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                return $"Successfully added Barbarian {name} to the collection.";
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            IWeapon weapon = null;

            if (type == nameof(Claymore))
            {
                weapon = new Claymore(name, durability);
            }
            else if (type == nameof(Mace))
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            weapons.Add(weapon);

            return $"A {weapon.GetType().Name.ToLower()} {name} is added to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            IHero hero = heroes.FindByName(heroName);
            IWeapon weapon = weapons.FindByName(weaponName);

            if (hero.Weapon != null)
            {
                return $"Hero {heroName} is well-armed.";
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string StartBattle()
        {
            Map map = new Map();

            List<IHero> players = heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();

            return map.Fight(players);
        }

        public string HeroReport()
        {
            var sortedHeroes = heroes.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(n => n.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var hero in sortedHeroes)
            {
                string heroWeapon = hero.Weapon == null ? "Unarmed" : hero.Weapon.Name;

                sb
                    .AppendLine($"{hero.GetType().Name}: {hero.Name}")
                    .AppendLine($"--Health: {hero.Health}")
                    .AppendLine($"--Armour: {hero.Armour}")
                    .AppendLine($"--Weapon: {heroWeapon}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
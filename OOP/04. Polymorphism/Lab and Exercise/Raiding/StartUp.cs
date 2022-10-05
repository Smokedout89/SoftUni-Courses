using System;
using System.Linq;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Hero> heroes = new List<Hero>();

            while (heroes.Count != n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    Hero hero = CreateHero(name, type);
                    heroes.Add(hero);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }      
           
            int bossHealth = int.Parse(Console.ReadLine());        

            foreach (Hero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int totalDamage = heroes.Sum(p => p.Power);

            if (totalDamage >= bossHealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }

        public static Hero CreateHero(string name, string type)
        {
            switch (type)
            {
                case "Druid": return new Druid(name);
                case "Paladin": return new Paladin(name);
                case "Rogue": return new Rogue(name);
                case "Warrior": return new Warrior(name);
                default: throw new ArgumentException("Invalid hero!");
            }
        }
    }
}

namespace Heroes.Models.Map
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Heroes;
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = players.Where(p => p.GetType().Name == nameof(Knight));
            var barbarians = players.Where(p => p.GetType().Name == nameof(Barbarian));

            bool knightsWon = false;

            while (true)
            {
                foreach (var knight in knights.Where(k => k.IsAlive))
                {
                    foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                if (barbarians.All(b => b.IsAlive == false))
                {
                    knightsWon = true;
                    break;
                }

                foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                {
                    foreach (var knight in knights.Where(k => k.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }

                if (knights.All(k => k.IsAlive == false))
                {
                    break;
                }
            }

            if (knightsWon)
            {
                int casualities = knights.Count(k => k.IsAlive == false);
                return $"The knights took {casualities} casualties but won the battle.";
            }
            else
            {
                int casualities = barbarians.Count(b => b.IsAlive == false);
                return $"The barbarians took {casualities} casualties but won the battle.";
            }
        }
    }
}
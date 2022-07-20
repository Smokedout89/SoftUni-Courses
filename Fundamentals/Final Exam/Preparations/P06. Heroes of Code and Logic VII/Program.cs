using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            this.Name = name;
            this.HP = hp;
            this.MP = mp;
        }
        public string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            int hpMax = 100;
            int mpMax = 200;

            for (int i = 0; i < n; i++)
            {
                string[] heroesInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroesInfo[0];
                int hp = int.Parse(heroesInfo[1]);
                int mp = int.Parse(heroesInfo[2]);

                if (hp > 100) hp = hpMax;
                if (mp > 200) mp = mpMax;

                heroes.Add(heroName, new Hero(heroName, hp, mp));
            }

            string play = Console.ReadLine();

            while (play != "End")
            {
                string[] cmdArgs = play.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                string heroName = cmdArgs[1];

                if (command == "CastSpell")
                {
                    int mpNeeded = int.Parse(cmdArgs[2]);
                    string spell = cmdArgs[3];

                    if (mpNeeded <= heroes[heroName].MP)
                    {
                        heroes[heroName].MP -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spell} and now has {heroes[heroName].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spell}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(cmdArgs[2]);
                    string attacker = cmdArgs[3];

                    heroes[heroName].HP -= damage;

                    if (heroes[heroName].HP > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(heroName);
                    }
                }
                else if (command == "Recharge")
                {
                    int amount = int.Parse(cmdArgs[2]);

                    if (heroes[heroName].MP + amount > mpMax)
                    {
                        amount = mpMax - heroes[heroName].MP;
                        heroes[heroName].MP = mpMax;
                    }
                    else
                    {
                        heroes[heroName].MP += amount;
                    }

                    Console.WriteLine($"{heroName} recharged for {amount} MP!");
                }
                else if (command == "Heal")
                {
                    int amount = int.Parse(cmdArgs[2]);

                    if (heroes[heroName].HP + amount > hpMax)
                    {
                        amount = hpMax - heroes[heroName].HP;
                        heroes[heroName].HP = hpMax;
                    }
                    else
                    {
                        heroes[heroName].HP += amount;
                    }

                    Console.WriteLine($"{heroName} healed for {amount} HP!");
                }

                play = Console.ReadLine();
            }

            foreach (var hero in heroes)   //.OrderByDescending(hp => hp.Value.HP).ThenBy(name => name.Key))
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }
    }
}

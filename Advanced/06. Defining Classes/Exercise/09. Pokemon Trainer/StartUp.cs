using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] info = command.Split();
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    trainers.Add(trainerName, newTrainer);
                }

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainers[trainerName].Pokemons.Add(pokemon);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(e => e.Element == command))
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Value.Pokemons.RemoveAll(h => h.Health <= 0);
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(b => b.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}

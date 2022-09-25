using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private readonly List<Animal> animals;

        public List<Animal> Animals { get { return animals; } }

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (this.animals.Count + 1 > Capacity)
            {
                return "The zoo is full.";
            }

            this.animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int removed = animals.RemoveAll(s => s.Species == species);
            return removed;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var sortByDiet = animals.FindAll(d => d.Diet == diet);
            return sortByDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return animals.FirstOrDefault(w => w.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var sortedAnimals = animals.Where(l => l.Length >= minimumLength && l.Length <= maximumLength);
            return $"There are {sortedAnimals.Count()} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}

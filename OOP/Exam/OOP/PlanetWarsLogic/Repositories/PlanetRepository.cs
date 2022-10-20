namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models;

        public void AddItem(IPlanet model) => models.Add(model);

        public IPlanet FindByName(string name) => models.FirstOrDefault(n => n.Name == name);

        public bool RemoveItem(string name) => models.Remove(models.FirstOrDefault(n => n.Name == name));
    }
}
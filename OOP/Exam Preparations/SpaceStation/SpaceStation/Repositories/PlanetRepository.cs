namespace SpaceStation.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

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

        public void Add(IPlanet model) => models.Add(model);

        public bool Remove(IPlanet model) => models.Remove(model);

        public IPlanet FindByName(string name) => models.FirstOrDefault(n => n.Name == name);
    }
}
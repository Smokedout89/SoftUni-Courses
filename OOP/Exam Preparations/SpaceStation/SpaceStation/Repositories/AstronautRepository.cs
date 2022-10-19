namespace SpaceStation.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models;

        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => models;

        public void Add(IAstronaut model) => models.Add(model);

        public bool Remove(IAstronaut model) => models.Remove(model);

        public IAstronaut FindByName(string name) => models.FirstOrDefault(n => n.Name == name);
    }
}
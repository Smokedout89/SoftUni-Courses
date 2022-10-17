namespace Formula1.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Contracts;
    using Repositories.Contracts;
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.models;

        public void Add(IRace model) => models.Add(model);

        public bool Remove(IRace model) => models.Remove(model);

        public IRace FindByName(string name)
        {
            return models.FirstOrDefault(m => m.RaceName == name);
        }
    }
}
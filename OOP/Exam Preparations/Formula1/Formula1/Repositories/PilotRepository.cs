namespace Formula1.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Contracts;
    using Repositories.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> models;

        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.models;

        public void Add(IPilot model) => models.Add(model);

        public bool Remove(IPilot model) => models.Remove(model);

        public IPilot FindByName(string name)
        {
            return models.FirstOrDefault(m => m.FullName == name);
        }
    }
}
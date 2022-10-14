namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Bunnies.Contracts;

    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> models;

        public BunnyRepository()
        {
            models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => models;

        public void Add(IBunny model) => models.Add(model);

        public bool Remove(IBunny model) => models.Remove(model);

        public IBunny FindByName(string name) => models.FirstOrDefault(n => n.Name == name);
    }
}
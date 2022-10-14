namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Eggs.Contracts;

    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> models;

        public EggRepository()
        {
            models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => models;

        public void Add(IEgg model) => models.Add(model);

        public bool Remove(IEgg model) => models.Remove(model);

        public IEgg FindByName(string name) => models.FirstOrDefault(n => n.Name == name);
    }
}
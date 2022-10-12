namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => models;

        public void Add(IDecoration model) => models.Add(model);

        public bool Remove(IDecoration model) => models.Remove(model);

        public IDecoration FindByType(string type) => models.FirstOrDefault(t => t.GetType().Name == type);
    }
}
namespace Heroes.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Contracts;
    using Repositories.Contracts;
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> models;

        public HeroRepository()
        {
            this.models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => models;

        public void Add(IHero model)
        {
            models.Add(model);
        }

        public bool Remove(IHero model)
        {
           return models.Remove(model);
        }

        public IHero FindByName(string name)
        {
            return models.FirstOrDefault(n => n.Name == name);
        }
    }
}
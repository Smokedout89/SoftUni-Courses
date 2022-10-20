namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => models;

        public void AddItem(IMilitaryUnit model) => models.Add(model);

        public IMilitaryUnit FindByName(string name) => models.FirstOrDefault(n => n.GetType().Name == name);

        public bool RemoveItem(string name) => models.Remove(models.FirstOrDefault(n => n.GetType().Name == name));
    }
}
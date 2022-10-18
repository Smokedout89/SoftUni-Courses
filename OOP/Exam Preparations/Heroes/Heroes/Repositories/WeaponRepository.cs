namespace Heroes.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Contracts;
    using Repositories.Contracts;
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => models;

        public void Add(IWeapon model)
        {
            models.Add(model);
        }

        public bool Remove(IWeapon model)
        {
            return models.Remove(model);
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(n => n.Name == name);
        }
    }
}
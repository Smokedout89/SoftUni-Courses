namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Contracts;
    using Models.Weapons;
    using Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => models;

        public void AddItem(IWeapon model) => models.Add(model);

        public IWeapon FindByName(string name) => models.FirstOrDefault(n => n.GetType().Name == name);

        public bool RemoveItem(string name) => models.Remove(models.FirstOrDefault(n => n.GetType().Name == name));
        
    }
}
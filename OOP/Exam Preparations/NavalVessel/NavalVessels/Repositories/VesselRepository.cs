namespace NavalVessels.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> models;

        public VesselRepository()
        {
            models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => models;

        public void Add(IVessel model) => models.Add(model);

        public bool Remove(IVessel model) => models.Remove(model);

        public IVessel FindByName(string name) => models.FirstOrDefault(n => n.Name == name);
    }
}
namespace Gym.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Equipment.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models { get; }

        public void Add(IEquipment model)
        {
            models.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return models.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return models.FirstOrDefault(t => t.GetType().Name == type);
        }
    }
}
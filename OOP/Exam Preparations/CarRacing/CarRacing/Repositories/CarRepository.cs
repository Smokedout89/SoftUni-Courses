namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Cars.Contracts;
    using Utilities.Messages;

    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => models;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model);
        }

        public bool Remove(ICar model) => models.Remove(model);

        public ICar FindBy(string property) => models.FirstOrDefault(v => v.VIN == property);
    }
}
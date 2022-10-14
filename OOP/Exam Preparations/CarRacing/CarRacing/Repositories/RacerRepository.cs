namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Racers.Contracts;
    using Utilities.Messages;

    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => models;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            models.Add(model);
        }

        public bool Remove(IRacer model) => models.Remove(model);

        public IRacer FindBy(string property) => models.FirstOrDefault(u => u.Username == property);
    }
}
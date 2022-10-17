namespace Formula1.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Contracts;
    using Repositories.Contracts;
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => this.models;

        public void Add(IFormulaOneCar model) => this.models.Add(model);

        public bool Remove(IFormulaOneCar model) => models.Remove(model);

        public IFormulaOneCar FindByName(string name)
        {
            return models.FirstOrDefault(m => m.Model == name);
        }
    }
}
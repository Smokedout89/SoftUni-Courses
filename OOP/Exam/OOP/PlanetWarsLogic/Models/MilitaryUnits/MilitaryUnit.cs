namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private int enduranceLevel = 1;

        public MilitaryUnit(double cost)
        {
            Cost = cost;
        }

        public double Cost { get; }

        public int EnduranceLevel => enduranceLevel;

        public void IncreaseEndurance()
        {
            enduranceLevel++;

            if (enduranceLevel > 20)
            {
                enduranceLevel = 20;

                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
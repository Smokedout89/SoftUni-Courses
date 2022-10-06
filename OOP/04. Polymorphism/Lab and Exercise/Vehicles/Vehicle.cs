using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double TankCapacity { get; }
        public double FuelQuantity
        {
            get => fuelQuantity;

            private set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (amount > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }

            FuelQuantity += amount;
        }

        public bool CanDrive(double distance)
        {
            bool canDrive = FuelQuantity - FuelConsumption * distance >= 0;

            if (!canDrive)
            {
                return false;
            }

            FuelQuantity -= FuelConsumption * distance;
            return true;
        }
    }
}
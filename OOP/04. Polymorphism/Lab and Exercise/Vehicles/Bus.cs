namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double busAirConditioner = 1.4;
        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity)
        {
        }

        public bool IsEmpty { get; set; }

        public override double FuelConsumption => IsEmpty 
            ? base.FuelConsumption 
            : base.FuelConsumption + busAirConditioner;
    }
}
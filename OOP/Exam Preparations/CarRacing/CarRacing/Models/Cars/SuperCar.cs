namespace CarRacing.Models
{
    public class SuperCar : Car
    {
        private const double SuperCarFuelAvailable = 80;
        private const double SuperCarFuelConsumption = 10;


        public SuperCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower,
                SuperCarFuelAvailable, SuperCarFuelConsumption)
        {
        }
    }
}
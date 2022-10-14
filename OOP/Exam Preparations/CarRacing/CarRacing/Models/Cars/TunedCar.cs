namespace CarRacing.Models
{
    using System;

    public class TunedCar : Car
    {
        private const double TunedCarFuelAvailable = 65;
        private const double TunedCarFuelConsumption = 7.5;


        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower,
                TunedCarFuelAvailable, TunedCarFuelConsumption)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower = (int) Math.Round(HorsePower * 0.97);
        }
    }
}
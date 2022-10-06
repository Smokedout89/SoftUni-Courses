using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string[] cmd = Console.ReadLine().Split();
                string action = cmd[0];
                string type = cmd[1];
                double amount = double.Parse(cmd[2]);

                Vehicle vehicle = null;
                vehicle = CheckVehicle(vehicle, type, car, truck, bus);

                if (action == "Drive")
                {
                    CanDrive(vehicle, amount);
                }
                else if (action == "Refuel")
                {
                    try
                    {
                        vehicle.Refuel(amount);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    bus.IsEmpty = true;
                    CanDrive(bus, amount);
                    bus.IsEmpty = false;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }

        private static Vehicle CheckVehicle(Vehicle vehicle, string type, Car car, Truck truck, Bus bus)
        {
            if (type == "Car")
            {
                return vehicle = car;
            }
            else if (type == "Truck")
            {
                return vehicle = truck;
            }
            else
            {
                return vehicle = bus;
            }
        }

        public static void CanDrive(Vehicle vehicle, double distance)
        {
            bool canDrive = vehicle.CanDrive(distance);
            string vehicleType = vehicle.GetType().Name;
            string result = canDrive
                ? $"{vehicleType} travelled {distance} km"
                : $"{vehicleType} needs refueling";

            Console.WriteLine(result);
        }
    }
}

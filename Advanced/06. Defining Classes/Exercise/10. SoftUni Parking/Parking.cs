using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new Dictionary<string, Car>();
            this.capacity = capacity;
        }

        public int Count => cars.Count;

        //public int Count
        //{
        //    get
        //    {
        //        return cars.Count;
        //    }
        //}


        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(registrationNumber);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            //foreach (var car in cars)
            //{
            //    if (car.Key == registrationNumber)
            //    {
            //        return car.Value;
            //    }
            //}

            //return null;

            return cars.FirstOrDefault(r => r.Key == registrationNumber).Value;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                cars.Remove(regNumber);
            }
        }
    }
}

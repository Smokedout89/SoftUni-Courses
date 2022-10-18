using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    using NUnit.Framework;
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void CarConstructorTest()
            {
                Car car = new Car("Mercedes", 2);

                Assert.AreEqual("Mercedes", car.CarModel);
                Assert.AreEqual(2, car.NumberOfIssues);
                Assert.IsFalse(car.IsFixed);

                car.NumberOfIssues = 0;

                Assert.IsTrue(car.IsFixed);
            }


            [Test]
            public void GarageConstructorTest()
            {
                Garage garage = new Garage("Gladnite", 3);
                
                Assert.AreEqual("Gladnite", garage.Name);
                Assert.AreEqual(3, garage.MechanicsAvailable);
                Assert.IsNotNull(garage);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void GarageNameThrowsException(string name)
            {
                Garage garage = null;

                Assert.Throws<ArgumentNullException>(
                    () => garage = new Garage(name, 2),
                    "Invalid garage name.");
            }

            [Test]
            [TestCase(0)]
            [TestCase(-1)]
            public void GarageMechachingsCountThrowsException(int number)
            {
                Garage garage = null;

                Assert.Throws<ArgumentException>(
                    () => garage = new Garage("Gladnite", number),
                    "At least one mechanic must work in the garage.");
            }

            [Test]
            public void GarageCountTest()
            {
                Garage garage = new Garage("Gladnite", 3);

                Assert.AreEqual(0, garage.CarsInGarage);

                Car car = new Car("Schupena", 12);
                Car car1 = new Car("sha zahlebim", 10);

                garage.AddCar(car1);
                garage.AddCar(car);

                Assert.AreEqual(2, garage.CarsInGarage);
            }

            [Test]
            public void GarageAddCarThrowsException()
            {
                Garage garage = new Garage("Gladnite", 1);
                Car car1 = new Car("sha zahlebim", 10);
                Car car = new Car("Schupena", 12);

                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(
                    () => garage.AddCar(car),
                    "No mechanic available.");
            }

            [Test]
            public void GarageTestFixCar()
            {
                Garage garage = new Garage("Gladnite", 1);
                Car car1 = new Car("schupena", 10);
                garage.AddCar(car1);

                garage.FixCar(car1.CarModel);

                Assert.AreEqual(0, car1.NumberOfIssues);
                Assert.IsTrue(car1.IsFixed);
            }

            [Test]
            public void GarageFixCarThrowException()
            {
                Garage garage = new Garage("Gladnite", 1);
                Car car1 = new Car("sha zahlebim", 10);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(
                    () => garage.FixCar(null));
            }

            [Test]
            public void GarageRemoveFixedCar()
            {
                Garage garage = new Garage("Gladnite", 3);
                Car car1 = new Car("schupena", 10);
                Car car = new Car("shazam", 6);
                Car car2 = new Car("zapazena", 2);

                garage.AddCar(car);
                garage.AddCar(car2);

                garage.FixCar(car.CarModel);
                garage.FixCar(car2.CarModel);

                int carsRemoved = garage.RemoveFixedCar();

                Assert.AreEqual(2, carsRemoved);
            }

            [Test]
            public void GarageRemoveFixedThrowsException()
            {
                Garage garage = new Garage("Gladnite", 3);

                Car car = new Car("shazam", 6);
                Car car2 = new Car("zapazena", 2);

                garage.AddCar(car);
                garage.AddCar(car2);

                Assert.Throws<InvalidOperationException>(
                    () => garage.RemoveFixedCar());
            }

            [Test]
            public void ReportTest()
            {
                Garage garage = new Garage("Gladnite", 3);

                Car car = new Car("shazam", 6);
                Car car2 = new Car("zapazena", 2);
                garage.AddCar(car);
                garage.AddCar(car2);

                Assert.AreEqual($"There are 2 which are not fixed: {car.CarModel}, {car2.CarModel}.", garage.Report());
            }
        }
    }
}
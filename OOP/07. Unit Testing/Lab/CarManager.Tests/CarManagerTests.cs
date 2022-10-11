namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void TestConstructors_CreateObjectProperly()
        {
            Car car = new Car("Mercedes", "C270", 8.8, 80.9);

            Assert.AreEqual("Mercedes", car.Make);
            Assert.AreEqual("C270", car.Model);
            Assert.AreEqual(8.8, car.FuelConsumption);
            Assert.AreEqual(80.9, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void TestMake_ThrowsException_NullOrEmpty()
        {
            Assert.Throws<ArgumentException>(
                () => new Car(null, "C270", 8.8, 80.9));

            Assert.Throws<ArgumentException>(
                () => new Car("", "C270", 8.8, 80.9));
        }

        [Test]
        public void TestModel_ThrowsException_NullOrEmpty()
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Mercedes", null, 8.8, 80.9));

            Assert.Throws<ArgumentException>(
                () => new Car("Mercedes", "", 8.8, 80.9));
        }

        [Test]
        public void TestFuelConsumption_ThrowsException_ZeroOrBelow()
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Mercedes", "C270", 0, 80.9));

            Assert.Throws<ArgumentException>(
                () => new Car("Mercedes", "C270", -2.2, 80.9));
        }

        [Test]
        public void TestFuelCapacity_ThrowsException_BelowZero()
        {
            Assert.Throws<ArgumentException>(
                () => new Car("Mercedes", "C270", 8.8, -0.1));

            Assert.Throws<ArgumentException>(
                () => new Car("Mercedes", "C270", 8.8, -20));
        }

        [Test]
        public void TestRefuelAmount_RefuelProperly()
        {
            Car car = new Car("Mercedes", "C270", 8.8, 80.9);

            car.Refuel(20);

            Assert.AreEqual(20, car.FuelAmount);
        }

        [Test]
        public void TestRefuelAmount_RefuelProperly_WhenAmountIsMoreThanCapacity()
        {
            Car car = new Car("Mercedes", "C270", 8.8, 80.9);

            car.Refuel(100);

            Assert.AreEqual(80.9, car.FuelAmount);
        }

        [Test]
        public void TestRefuelAmount_ThrowsException_ZeroOrLess()
        {
            Car car = new Car("Mercedes", "C270", 8.8, 80.9);

            Assert.Throws<ArgumentException>(
                () => car.Refuel(0));

            Assert.Throws<ArgumentException>(
                () => car.Refuel(-10));
        }

        [Test]
        public void TestDrive_ChangeFuelProperly()
        {
            Car car = new Car("Mercedes", "C270", 9, 80.9);

            car.Refuel(50);
            car.Drive(100);

            Assert.AreEqual(41, car.FuelAmount);
        }

        [Test]
        public void TestDrive_ThrowsException_NotEnoughFuel()
        {
            Car car = new Car("Mercedes", "C270", 9, 80.9);

            car.Refuel(8.9);

            Assert.Throws<InvalidOperationException>(
                () => car.Drive(100));
        }
    }
}
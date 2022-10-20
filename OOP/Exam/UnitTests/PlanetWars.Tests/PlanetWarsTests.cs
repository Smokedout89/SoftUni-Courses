using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        private Weapon weapon;
        private Planet planet;

        [TestFixture]
        public class PlanetWarsTests
        {
        }

        [SetUp]
        public void Init()
        {
            weapon = new Weapon("Weapon", 100, 10);
            planet = new Planet("Planet", 1000);
        }

        [Test]
        public void WeaponConstructorTest()
        {
            Assert.AreEqual("Weapon", weapon.Name);
            Assert.AreEqual(100, weapon.Price);
            Assert.AreEqual(10, weapon.DestructionLevel);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void WeaponPriceException(int value)
        {
            Assert.Throws<ArgumentException>(
                () => new Weapon("asd", value, 10));
        }

        [Test]
        public void WeaponIncreaseDestro()
        {
            weapon.IncreaseDestructionLevel();

            Assert.AreEqual(11, weapon.DestructionLevel);
            Assert.IsTrue(weapon.IsNuclear);

            weapon.DestructionLevel = 9;
            Assert.IsFalse(weapon.IsNuclear);
        }

        [Test]
        public void PlanetConstctructorTest()
        {
            Assert.AreEqual("Planet", planet.Name);
            Assert.AreEqual(1000, planet.Budget);
            Assert.IsNotNull(planet.Weapons);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PlanetNameException(string value)
        {
            Assert.Throws<ArgumentException>(
                () => new Planet(value, 10));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void PlanetBudgetThrows(int value)
        {
            Assert.Throws<ArgumentException>(
                () => new Planet("Planet", value));
        }

        [Test]
        public void PlanetMilitaryPower()
        {
            planet.AddWeapon(weapon);
            Assert.AreEqual(10, planet.MilitaryPowerRatio);
        }

        [Test]
        public void PlanetProfit()
        {
            planet.Profit(10);

            Assert.AreEqual(1010, planet.Budget);
        }

        [Test]
        public void PlanetSpendFunds()
        {
            planet.SpendFunds(900);
            Assert.AreEqual(100, planet.Budget);
        }

        [Test]
        public void PlanetSpendFundsThrows()
        {
            Assert.Throws<InvalidOperationException>(
                () => planet.SpendFunds(1001));
        }

        [Test]
        public void PlanedAddWeaponThrows()
        {
            planet.AddWeapon(weapon);

            Assert.Throws<InvalidOperationException>(
                () => planet.AddWeapon(new Weapon("Weapon", 20,20)));
        }

        [Test]
        public void PlanedRemoveWeapon()
        {
            planet.AddWeapon(weapon);
            planet.RemoveWeapon("Weapon");

            Assert.AreEqual(0, planet.Weapons.Count);
        }

        [Test]
        public void PlanedUpgradeWeapon()
        {
            planet.AddWeapon(weapon);
            planet.UpgradeWeapon("Weapon");

            Assert.AreEqual(11, weapon.DestructionLevel);
        }

        [Test]
        public void PlanedUpgradeWeaponThrows()
        {
            Assert.Throws<InvalidOperationException>(
                () => planet.UpgradeWeapon("Weapon"));
        }

        [Test]
        public void PlanetDestruct()
        {
            var opponent = new Planet("Op", 10);
            planet.AddWeapon(weapon);

            string result = planet.DestructOpponent(opponent);

            Assert.AreEqual("Op is destructed!", result);
        }

        [Test]
        public void PlanetDestructThrows()
        {
            var opponent = new Planet("Op", 10);

            Assert.Throws<InvalidOperationException>(
                () => planet.DestructOpponent(opponent));
        }
    }
}
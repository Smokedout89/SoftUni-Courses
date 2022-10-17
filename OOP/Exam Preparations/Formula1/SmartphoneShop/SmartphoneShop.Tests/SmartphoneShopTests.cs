namespace SmartphoneShop.Tests
{
    using System;
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;

        [SetUp]
        public void Init()
        {
            smartphone = new Smartphone("Samsung", 100);
            shop = new Shop(5);
            shop.Add(smartphone);
        }

        [Test]
        public void SmartphoneConstrunctorTest()
        {
            Assert.AreEqual("Samsung", smartphone.ModelName);
            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
            Assert.AreEqual(100, smartphone.MaximumBatteryCharge);
        }

        [Test]
        public void ShopConstructorTest()
        {
            Assert.AreEqual(5, shop.Capacity);
            Assert.IsFalse(shop == null);
        }

        [Test]
        public void ShopSetCapacityThrowsException()
        {
            Shop exceptionShop = null;

            Assert.Throws<ArgumentException>(
                () => exceptionShop = new Shop(-1),
                "Invalid capacity.");
        }

        [Test]
        public void ShopCountTest()
        {
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void ShopAddShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => shop.Add(new Smartphone("Samsung", 90)));

            shop.Add(new Smartphone("Apple", 100));
            shop.Add(new Smartphone("Motorola", 100));
            shop.Add(new Smartphone("Huawei", 100));
            shop.Add(new Smartphone("Oppo", 20));

            Assert.Throws<InvalidOperationException>(
                () => shop.Add(new Smartphone("Sony", 1)));
        }

        [Test]
        public void ShopRemoveShouldRemovePhone()
        {
            shop.Remove("Samsung");

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void ShopRemoveShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => shop.Remove("Apple"));
        }

        [Test]
        public void ShopTestPhoneShouldWork()
        {
            shop.TestPhone("Samsung", 40);

            Assert.AreEqual(60, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ShopTestPhoneShouldThrowException()
        {
            smartphone.CurrentBateryCharge = 40;

            Assert.Throws<InvalidOperationException>(
                () => shop.TestPhone("Apple", 20));

            Assert.Throws<InvalidOperationException>(
                () => shop.TestPhone("Samsung", 41));
        }

        [Test]
        public void ShopChargePhoneShouldCharge()
        {
            smartphone.CurrentBateryCharge = 20;
            shop.ChargePhone("Samsung");

            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ShopChargeShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => shop.ChargePhone("Apple"));
        }
    }
}
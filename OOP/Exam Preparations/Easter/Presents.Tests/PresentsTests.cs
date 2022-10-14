namespace Presents.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void Init()
        {
            present = new Present("Podaruche", 50);
            bag = new Bag();
        }

        [Test]
        public void PresentConstructorTest()
        {
            Assert.AreEqual("Podaruche", present.Name);
            Assert.AreEqual(50, present.Magic);
        }

        [Test]
        public void BagCollectionInitializationTest()
        {
            Assert.IsNotNull(bag);
        }

        [Test]
        public void BagCreateShouldAddPresent()
        {
            Assert.DoesNotThrow(
                () => bag.Create(present),
                $"Successfully added present {present.Name}.");
        }

        [Test]
        public void BagCreateShouldThrowException()
        {
            present = null;

            Assert.Throws<ArgumentNullException>(
                () => bag.Create(present),
                "Present is null");

            Present pres = new Present("FurgamGreshka", 100);
            bag.Create(pres);

            Assert.Throws<InvalidOperationException>(
                () => bag.Create(pres),
                "This present already exists!");
        }

        [Test]
        public void BagRemoveShouldRemovePresent()
        {
            bag.Create(present);

            Assert.IsTrue(bag.Remove(present));
        }

        [Test]
        public void BagShouldReturnPresentWithLeastMagig()
        {
            bag.Create(present);

            Present pres = new Present("Yok magic", 1);
            bag.Create(pres);

            Assert.AreEqual(pres, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void BagGetPresentShouldReturnPresent()
        {
            bag.Create(present);

            Assert.AreEqual(present, bag.GetPresent("Podaruche"));
        }

        [Test]
        public void BagGetPresentsShouldReturnTheCollection()
        {
            bag.Create(present);
            var expected = bag.GetPresents();

            Assert.IsTrue(expected is IReadOnlyCollection<Present>);
        }
    }
}

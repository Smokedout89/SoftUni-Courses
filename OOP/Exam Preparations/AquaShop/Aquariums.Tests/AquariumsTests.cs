namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void Init()
        {
            fish = new Fish("Ribka");
            aquarium = new Aquarium("AquaParadise", 20);
        }

        [Test]
        public void FishConstuctorTest()
        {
            Assert.AreEqual("Ribka", fish.Name);
            Assert.IsTrue(fish.Available);
        }

        [Test]
        public void AquariumConstructorTest()
        {
            Assert.IsNotNull(aquarium);
            Assert.AreEqual("AquaParadise", aquarium.Name);
            Assert.AreEqual(20, aquarium.Capacity);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void AquariumNameShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(
                () => new Aquarium(name, 5),
                "Invalid aquarium name!");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void AquariumCapacityShouldThrowException(int capacity)
        {
            Assert.Throws<ArgumentException>(
                () => new Aquarium("Akvarium", capacity),
                "Invalid aquarium capacity!");
        }

        [Test]
        public void AquariumCountShouldWork()
        {
            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void AquariumAddShouldThrowCapacityException()
        {
            Aquarium aqua = new Aquarium("Akvarium", 1);
            aqua.Add(fish);
            Fish fishy = new Fish("Ribchi");

            Assert.Throws<InvalidOperationException>(
                () => aqua.Add(fishy),
                "Aquarium is full!");
        }

        [Test]
        public void AquariumRemoveFishShouldWork()
        {
            aquarium.Add(fish);

            aquarium.RemoveFish("Ribka");

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void AquariumRemoveShouldThrowWhenNull()
        {
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(
                () => aquarium.RemoveFish("Fishyyy"),
                $"Fish with the name Fishyyy doesn't exist!");
        }

        [Test]
        public void AquariumSellFishShouldWork()
        {
            aquarium.Add(fish);
            aquarium.SellFish("Ribka");

            Assert.IsFalse(fish.Available);
        }

        [Test]
        public void AquariumSellFishShouldReturnTheFish()
        {
            aquarium.Add(fish);
            Fish fishToReturn = aquarium.SellFish("Ribka");

            Assert.AreEqual(fish, fishToReturn);
        }

        [Test]
        public void AquariumSellFishShouldThrow()
        {
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(
                () => aquarium.SellFish("Fishy"),
                $"Fish with the name Fishy doesn't exist!");
        }

        [Test]
        public void AquariumReportTest()
        {
            aquarium.Add(fish);
            Fish fishy = new Fish("Fishy");
            aquarium.Add(fishy);

            string expected = $"Fish available at AquaParadise: Ribka, Fishy";

            Assert.AreEqual(expected, aquarium.Report());
        }
    }
}

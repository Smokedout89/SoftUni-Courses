using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            Dummy dummy = new Dummy(100, 10);

            dummy.TakeAttack(10);

            Assert.AreEqual(90, dummy.Health);
        }

        [Test]
        public void DeadDummyExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);

            // Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));

            Assert.That(() => dummy.TakeAttack(1), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyGivesXp()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.AreEqual(10, dummy.GiveExperience());
        }

        [Test]
        public void AliveDummyDontGiveXp()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
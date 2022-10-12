namespace FightingArena.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void TestArena_RepositoryCreation_Succesfully()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(arena.Warriors.Count, arena.Count);
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void TestArena_Enroll_Succesfully()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Manqka", 100, 100);
            Warrior warrior1 = new Warrior("Slabaka", 50, 50);
            Warrior warrior2 = new Warrior("Zagzo", 10, 10);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.AreEqual(3, arena.Count);
            Assert.True(arena.Warriors.Any(n => n.Name == "Zagzo"));
        }

        [Test]
        public void TestArena_Enroll_ThrowException()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Manqka", 100, 100);
            Warrior warrior2 = new Warrior("Manqka", 10, 10);

            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(warrior2));
        }

        [Test]
        public void TestArena_FightReduceHp_ValidData()
        {
            Arena arena = new Arena();

            Warrior attacker = new Warrior("Manqka", 100, 100);
            Warrior defender = new Warrior("Slabaka", 50, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Manqka", "Slabaka");

            Assert.AreEqual(50, attacker.HP);
            Assert.AreEqual(0, defender.HP);
        }

        [Test]
        public void TestArena_FightShouldThrowException_WarriorDoesntExist()
        {
            Arena arena = new Arena();

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Manqka", "Slabaka"));

            Warrior attacker = new Warrior("Manqka", 100, 100);
            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Manqka", "Slabaka"));
        }
    }
}

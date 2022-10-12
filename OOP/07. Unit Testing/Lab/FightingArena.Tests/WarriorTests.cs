namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Constuctor_SetData_Properly()
        {
            Warrior warrior = new Warrior("Manqka", 100, 100);

            Assert.AreEqual("Manqka", warrior.Name);
            Assert.AreEqual(100, warrior.HP);
            Assert.AreEqual(100, warrior.Damage);

            Warrior warrior2 = new Warrior("Zagzo", 1, 0);
            Assert.AreEqual("Zagzo", warrior2.Name);
            Assert.AreEqual(0, warrior2.HP);
            Assert.AreEqual(1, warrior2.Damage);
        }

        [Test]
        public void Constuctor_ShouldThrowException_InvalidData()
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(null, 100, 100));
            Assert.Throws<ArgumentException>(
                () => new Warrior("", 1, 0));
            Assert.Throws<ArgumentException>(
                () => new Warrior(" ", 1, 0));
            Assert.Throws<ArgumentException>(
                () => new Warrior("Zagzo", 0, 10));
            Assert.Throws<ArgumentException>(
                () => new Warrior("Zagzo", -123, 10));
            Assert.Throws<ArgumentException>(
                () => new Warrior("Zagzo", 123, -2));
        }

        [Test]
        public void Fight_ShouldCalculateDamage_ValidData()
        {
            Warrior attacker = new Warrior("Manqka", 100, 100);
            Warrior defender = new Warrior("Slabaka", 50, 150);

            attacker.Attack(defender);

            Assert.AreEqual(50, attacker.HP);
            Assert.AreEqual(50, defender.HP);

            attacker = new Warrior("Manqka", 100, 100);
            defender = new Warrior("Slabaka", 50, 50);

            attacker.Attack(defender);

            Assert.AreEqual(50, attacker.HP);
            Assert.AreEqual(0, defender.HP);
        }

        [Test]
        public void Fight_ShouldThrowException_InvalidData()
        {
            Warrior attacker = new Warrior("Manqka", 100, 20);
            Warrior defender = new Warrior("Slabaka", 50, 50);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));

            attacker = new Warrior("Manqka", 100, 100);
            defender = new Warrior("Slabaka", 50, 20);
            
            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));

            attacker = new Warrior("Manqka", 100, 100);
            defender = new Warrior("Slabaka", 101, 101);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));
        }
    }
}
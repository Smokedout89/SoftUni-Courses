using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class BankVaultTests
    {
        private Item item;
        private BankVault bank;

        [SetUp]
        public void Setup()
        {
            item = new Item("Pavchito", "The Hammer");
            bank = new BankVault();
        }

        [Test]
        public void ItemConstuctorTest()
        {
            Assert.AreEqual("Pavchito", item.Owner);
            Assert.AreSame("The Hammer", item.ItemId);
        }

        [Test]
        public void BankVaultConstructorTest()
        {
            Assert.That(bank.VaultCells.Values.All(v => v == null));
        }

        [Test]
        public void BankVaultCollectionReadonlyTest()
        {
            var collection = bank.VaultCells;

            Assert.True(collection is IReadOnlyDictionary<string, Item>);
        }

        [Test]
        public void BankVaultAddItemWorking()
        {
            string result = bank.AddItem("C4", item);

            Assert.IsTrue(bank.VaultCells["C4"].Owner == "Pavchito");
            Assert.IsTrue(bank.VaultCells["C4"].ItemId == "The Hammer");
            Assert.AreEqual($"Item:The Hammer saved successfully!", result);
        }

        [Test]
        public void BankVaultAddItemExceptions()
        {
            Assert.Throws<ArgumentException>(
                () => bank.AddItem("D1", item),
                "Cell doesn't exists!");

            bank.AddItem("C4", item);
            Item newItem = new Item("Roshtein", "CasinoGambler");

            Assert.Throws<ArgumentException>(
                () => bank.AddItem("C4", newItem),
                "Cell is already taken!");

            Assert.Throws<InvalidOperationException>(
                () => bank.AddItem("A1", item),
                "Item is already in cell!");
        }

        [Test]
        public void BankVaultRemoveItemWorking()
        {
            bank.AddItem("C4", item);

            string result = bank.RemoveItem("C4", item);

            Assert.AreEqual(null, bank.VaultCells["C4"]);
            Assert.AreEqual($"Remove item:The Hammer successfully!", result);
        }

        [Test]
        public void BankVaultRemoveExceptions()
        {
            Assert.Throws<ArgumentException>(
                () => bank.RemoveItem("D1", item),
                "Cell doesn't exists!");

            bank.AddItem("C4", item);
            Item otherItem = new Item("Gosheto", "Powera");

            Assert.Throws<ArgumentException>(
                () => bank.RemoveItem("C4", otherItem),
                "Item in that cell doesn't exists!");
        }
    }
}
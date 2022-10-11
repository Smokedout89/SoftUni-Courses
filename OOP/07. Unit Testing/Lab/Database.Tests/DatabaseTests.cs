using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { })]
        [TestCase(new int[0])]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { int.MinValue, 2, 3, 4, int.MaxValue })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Constructor_SetValidData(int[] elements)
        {
            Database database = new Database(elements);

            Assert.AreEqual(elements.Length, database.Count);
        }

        [TestCase(
            new[] { 1 },
            new[] { 2, 3, 4 }, 4)]
        [TestCase(
            new int[0],
            new[] { int.MinValue, int.MaxValue, 123 },
            3)]
        [TestCase(
            new int[0],
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
            16)]
        public void Add_ValidData(
            int[] ctorElements,
            int[] elementsToAdd,
            int expectedCount)
        {
            Database database = new Database(ctorElements);

            for (int i = 0; i < elementsToAdd.Length; i++)
            {
                database.Add(elementsToAdd[i]);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Add_MoreElements_ShouldThrow(int[] elements)
        {
            Database database = new Database(elements);

            Assert.Throws<InvalidOperationException>(
                () => database.Add(1));
        }


        [TestCase(
            new[] { 1, 2 },
            new[] { 3, 5 },
            4,
            0)]
        [TestCase(
            new int[0],
            new[] { 3, 5 , 7, 12, 123 },
            4,
            1)]
        public void Remove_WithValidData(
            int[] ctorElements,
            int[] elementsToAdd,
            int elementsToRemove,
            int expectedCount)
        {
            Database database = new Database(ctorElements);

            for (int i = 0; i < elementsToAdd.Length; i++)
            {
                database.Add(elementsToAdd[i]);
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void Remove_EmptyCollection_ShouldThrow()
        {
            Database database = new Database();

            database.Add(10);
            database.Remove();

            Assert.Throws<InvalidOperationException>(
                () => database.Remove(), "The collection is empty!");
        }

        [TestCase(new int[0])]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { int.MinValue, 2, 3, 4, int.MaxValue })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Fetch_ShouldReturnSameArray(int[] elements)
        {
            Database database = new Database(elements);
            
            int[] copiedArray = database.Fetch();

            CollectionAssert.AreEqual(elements, copiedArray);
        }
    }
}

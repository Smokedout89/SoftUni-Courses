namespace DatabaseExtended.Tests
{
    using System;
    using System.Collections.Generic;

    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestCaseData")]
        public void Constructor_ValidData_CreateDatabase(
            Person[] people,
            int expectedCount)
        {
            Database database = new Database(people);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddData")]
        public void Add_ShouldAddData_ToDatabase(
            Person[] peopleFromCtor,
            Person[] peopleToAdd,
            int expectedCount)
        {
            Database database = new Database(peopleFromCtor);

            foreach (var person in peopleToAdd)
            {
                database.Add(person);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddInvalidData")]
        public void Add_ShouldThrowInvalidException_WithInvalidData(
            Person[] peopleFromCtor,
            Person[] peopleToAdd,
            Person errorPerson)
        {
            Database database = new Database(peopleFromCtor);

            foreach (var person in peopleToAdd)
            {
                database.Add(person);
            }

            Assert.Throws<InvalidOperationException>(
                () => database.Add(errorPerson));
        }

        [TestCaseSource("TestCaseRemoveData")]
        public void Remove_ShouldRemoveWith_ValidData(
            Person[] peopleFromCtor,
            Person[] peopleToAdd,
            int personToRemove,
            int expectedCount)
        {
            Database database = new Database(peopleFromCtor);

            foreach (var person in peopleToAdd)
            {
                database.Add(person);
            }

            for (int i = 0; i < personToRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseRemoveDataException")]
        public void Remove_ShouldThrowExceptionWith_EmptyCollection(
            Person[] peopleFromCtor,
            Person[] peopleToAdd,
            int personToRemove)
        {
            Database database = new Database(peopleFromCtor);

            foreach (var person in peopleToAdd)
            {
                database.Add(person);
            }

            for (int i = 0; i < personToRemove; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }

        [Test]
        public void FindPerson_ByUsername_ShouldReturn()
        {
            Database database = new Database();

            database.Add(new Person(7, "Dogi"));
            database.Add(new Person(8, "Maugli"));

            var expectedPerson = new Person(1, "Jorko");
            database.Add(expectedPerson);

            var personByUsername = database.FindByUsername("Jorko");

            Assert.AreSame(expectedPerson, personByUsername);
        }

        [Test]
        public void FindPerson_ThrowsException_NullOrEmpty()
        {
            Database database = new Database();

            database.Add(new Person(7, "Dogi"));
            database.Add(new Person(8, "Maugli"));

            var nullPerson = new Person(1, null);
            var emptyPerson = new Person(2, "");

            Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(nullPerson.UserName));

            Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(emptyPerson.UserName));
        }

        [Test]
        public void FindPerson_ThrowsException_NotFind()
        {
            Database database = new Database();

            database.Add(new Person(7, "Dogi"));
            database.Add(new Person(8, "Maugli"));

            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername("Jorkata"));
        }

        [Test]
        public void FindPerson_ById_ShouldReturn()
        {
            Database database = new Database();

            database.Add(new Person(7, "Dogi"));
            database.Add(new Person(8, "Maugli"));

            var expectedPerson = new Person(12, "Tochniq");
            database.Add(expectedPerson);

            var foundPerson = database.FindById(12);

            Assert.AreEqual(expectedPerson.Id, foundPerson.Id);
        }

        [Test]
        public void FindPerson_ById_ShouldThrow()
        {
            Database database = new Database();

            database.Add(new Person(7, "Dogi"));
            database.Add(new Person(8, "Maugli"));

            Assert.Throws<InvalidOperationException>(
                () => database.FindById(12));
        }

        [Test]
        public void FindPerson_ById_ShouldThrowNegativeId()
        {
            Database database = new Database();

            database.Add(new Person(7, "Dogi"));
            database.Add(new Person(8, "Maugli"));

            Assert.Throws<ArgumentOutOfRangeException>(
                () => database.FindById(-12));
        }

        public static IEnumerable<TestCaseData> TestCaseRemoveDataException()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Jorko")
                    },
                    new Person[]
                    {
                        new Person(7, "Dogi"),
                        new Person(8, "Maugli")
                    },
                    3)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseRemoveData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Jorko"),
                        new Person(2, "Goshko"),
                        new Person(3, "Peshko")
                    },
                    new Person[]
                    {
                        new Person(7, "Dogi"),
                        new Person(8, "Maugli"),
                        new Person(9, "Bastun"),
                    },
                    2,
                    4),

                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(7, "Dogi"),
                        new Person(8, "Maugli"),
                    },
                    2,
                    0),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAddInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Jorko"),
                        new Person(2, "Goshko"),
                        new Person(3, "Peshko"),
                        new Person(4, "Shishi"),
                        new Person(5, "Juji"),
                        new Person(6, "Gogi"),
                        new Person(7, "Dogi"),
                        new Person(8, "Maugli")
                    },
                    new Person[]
                    {
                        new Person(9, "Bastun"),
                        new Person(10, "Batak"),
                        new Person(11, "Tashak"),
                        new Person(12, "Qrak"),
                        new Person(13, "Pisna"),
                        new Person(14, "Mi"),
                        new Person(15, "Be"),
                        new Person(16, "Brat")
                    },
                    new Person(17, "Greshka")),

                new TestCaseData(
                new Person[]
                {
                new Person(1, "Jorko"),
                new Person(2, "Goshko"),
                },
                new Person[]
                {
                    new Person(9, "Bastun"),
                },
                new Person(10, "Bastun")),

                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Jorko"),
                        new Person(2, "Goshko"),
                    },
                    new Person[]
                    {
                        new Person(9, "Bastun"),
                    },
                    new Person(9, "Oba"))
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Jorko"),
                        new Person(2, "Goshko"),
                        new Person(3, "Peshko")
                    },
                    new Person[]
                    {
                        new Person(7, "Dogi"),
                        new Person(8, "Maugli"),
                        new Person(9, "Bastun"),
                    },
                    6),

                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(7, "Dogi"),
                        new Person(8, "Maugli"),
                    },
                    2),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Jorko"),
                        new Person(2, "Goshko"),
                        new Person(3, "Peshko")
                    },
                    3),

                new TestCaseData(
                    new Person[]
                    {
                    },
                    0),

                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Jorko"),
                        new Person(2, "Goshko"),
                        new Person(3, "Peshko"),
                        new Person(4, "Shishi"),
                        new Person(5, "Juji"),
                        new Person(6, "Gogi"),
                        new Person(7, "Dogi"),
                        new Person(8, "Maugli"),
                        new Person(9, "Bastun"),
                        new Person(10, "Batak"),
                        new Person(11, "Tashak"),
                        new Person(12, "Qrak"),
                        new Person(13, "Pisna"),
                        new Person(14, "Mi"),
                        new Person(15, "Be"),
                        new Person(16, "Brat")
                    },
                    16)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }
    }
}
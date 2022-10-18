namespace Book.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Book book;

        [SetUp]
        public void Init()
        {
            book = new Book("Messin Around", "Unknown T");
            book.AddFootnote(12, "pffff");
        }

        [Test]
        public void BookConstructorTest()
        {
            Assert.AreEqual("Messin Around", book.BookName);
            Assert.AreEqual("Unknown T", book.Author);
            Assert.AreEqual(1, book.FootnoteCount);
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void BookNameThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(
                () => new Book(name, "Unknown"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void BookAuthorThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(
                () => new Book("Knijka", name));
        }

        [Test]
        public void BookAddFootnoteTest()
        {
            book.AddFootnote(13, "Opalq");

            Assert.AreEqual(2, book.FootnoteCount);
        }

        [Test]
        public void BookAddFootnoteThrowsException()
        {
            Assert.Throws<InvalidOperationException>(
                () => book.AddFootnote(12, "blabla"));
        }

        [Test]
        public void BookTestFindFootnote()
        {
            var text = book.FindFootnote(12);

            Assert.AreEqual(text, "Footnote #12: pffff");
        }

        [Test]
        public void BookFindFootnoteThrowsException()
        {
            Assert.Throws<InvalidOperationException>(
                () => book.FindFootnote(3));
        }

        [Test]
        public void BookAlterFootnote()
        {
            book.AlterFootnote(12, "Probichka");

            Assert.AreEqual("Footnote #12: Probichka", book.FindFootnote(12));
        }

        [Test]
        public void BookAlterFootnoteThrowsException()
        {
            Assert.Throws<InvalidOperationException>(
                () => book.AlterFootnote(13, "Textchi"));
        }
    }
}
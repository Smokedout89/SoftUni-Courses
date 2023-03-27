namespace BookShop
{
    using Data;
    using Models;
    using Initializer;
    using System.Text;
    using Models.Enums;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            DbInitializer.ResetDatabase(context);
        }

        // Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            bool parseSuccess = Enum.TryParse
                (command, true, out AgeRestriction ageRestriction);

            if (!parseSuccess)
            {
                return string.Empty;
            }

            var bookTitles = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold
                            && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        // Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var bookPrice = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToList();

            return string.Join(Environment.NewLine, bookPrice);
        }

        // Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleased = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(t => t.Title)
                .ToList();

            return string.Join(Environment.NewLine, booksNotReleased);
        }

        // Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var titles = context
                .Books
                .Where(b => b.BookCategories
                    .Any(c => categories
                        .Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            return string.Join(Environment.NewLine, titles);
        }

        // Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var dateParsed = 
                DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksBefore = context
                .Books
                .Where(b => b.ReleaseDate < dateParsed)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            foreach (var book in booksBefore)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToList()
                .OrderBy(a => a)
                .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        // Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(a => a.Author.LastName.ToLower()
                    .StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(a => new
                {
                    a.Title,
                    a.Author.FirstName,
                    a.Author.LastName
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }

        // Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var totalCopies = context
                .Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(c => c.Copies)
                .ToList();

            foreach (var copy in totalCopies)
            {
                sb.AppendLine($"{copy.AuthorName} - {copy.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var profitByCategory = context
                .Categories
                .Select(bc => new
                {
                    Categ = bc.Name,
                    Profit = bc.CategoryBooks.Sum(p => p.Book.Copies * p.Book.Price)
                })
                .OrderByDescending(p => p.Profit)
                .ThenBy(c => c.Categ)
                .ToList();

            foreach (var pc in profitByCategory)
            {
                sb.AppendLine($"{pc.Categ} ${pc.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var mostRecent = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    RecentBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate.Value)
                        .Select(cb => new
                        {
                            cb.Book.Title,
                            ReleaseYear = cb.Book.ReleaseDate.Value.Year
                        })
                        .Take(3)
                        .ToList()
                })
                .OrderBy(c => c.Name);

            foreach (var c in mostRecent)
            {
                sb.AppendLine($"--{c.Name}");

                foreach (var b in c.RecentBooks)
                {
                    sb.AppendLine($"{b.Title} ({b.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var booksBeforeYear = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in booksBeforeYear)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200);

            int count = books.Count();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return count;
        }
    }
}
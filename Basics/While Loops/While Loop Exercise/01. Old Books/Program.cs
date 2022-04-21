using System;
namespace _01._Old_Books

{
    class Program
    {
        static void Main(string[] args)
        {
            string searchedBook = Console.ReadLine();
            int bookCounter = 0;
            string currentBook = Console.ReadLine();

            while (currentBook != "No More Books")
            {
                if (currentBook == searchedBook)
                {
                    Console.WriteLine($"You checked {bookCounter} books and found it.");
                    break;
                }
                bookCounter++;
                currentBook = Console.ReadLine();
            }
            if (currentBook == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {bookCounter} books.");
            }
     
        }
    }
}

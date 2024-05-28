using System;
using System.Threading;
using Library;
using Authors;
using Books;
using System.Collections.Generic;

namespace LibraryApp
{
    public class Program
    {

        static void Main()
        {
            Library.Library LibraryInstance;

            System.Console.WriteLine("[LOG] Initializing program.");
            Thread.Sleep(1000);
            System.Console.WriteLine("[LOG] Attempting to initialize new Library instance.");
            Thread.Sleep(500);

            try
            {
                LibraryInstance = new Library.Library();
                System.Console.WriteLine("[LOG] Library instance successfully initiated.");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine($"[ERROR] Failed to initialize an instance of Library.");
                throw;
            }

            Authors.Author NewAuthor;
            Books.Book NewBook;

            try
            {
                NewAuthor = new Authors.Author("JK Rowling", "1990-01-22");
                System.Console.WriteLine($"[INFO] New author created successfully: '{NewAuthor.AuthorName}' born on {NewAuthor.AuthorBirthdate}");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine($"[ERROR] Failed to create a new Author.");
                throw;
            }
            Thread.Sleep(250);

            try
            {
                NewBook = new Books.Book("Harry Potter", NewAuthor);
                System.Console.WriteLine($"[INFO] New book created successfully: '{NewBook.BookName} by {NewBook.BookAuthor.AuthorName}'");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine($"[ERROR] Failed to create a new Book.");
                throw;
            }
            Thread.Sleep(250);

            try
            {
                LibraryInstance.AddBook(NewBook);
                LibraryInstance.PrintAllBooks();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine($"[ERROR] Failed to add Book to Library.");
                throw;
            }

            string TestSearchByTitleBookName = "Harry Potter";

            try
            {
                KeyValuePair<int, Books.Book> TestSearchByTitle = LibraryInstance.SearchForBookByTitle(TestSearchByTitleBookName);
                System.Console.WriteLine($"[INFO] Book '{TestSearchByTitle.Value.BookName}' found!");
            }
            catch (NullReferenceException)
            {
                System.Console.WriteLine($"[INFO] Book '{TestSearchByTitleBookName}' not found.");
            }

            string TestSearchByAuthorBookAuthor = "JK Rowling";

            try
            {
                KeyValuePair<int, Books.Book> TestSearchByAuthor = LibraryInstance.SearchForBookByAuthor(TestSearchByAuthorBookAuthor);
                System.Console.WriteLine($"[INFO] Author '{TestSearchByAuthor.Value.BookAuthor.AuthorName}' found for the book: '{TestSearchByAuthor.Value.BookName}'");
            }
            catch (NullReferenceException)
            {
                System.Console.WriteLine($"[INFO] Author '{TestSearchByAuthorBookAuthor}' not found.");
            }

            LibraryInstance.RemoveBook("Harry Potter");
        }
    }
}
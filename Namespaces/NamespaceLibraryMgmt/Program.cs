using System;
using System.Threading;
using Library;
using Authors;
using Books;

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
                string ErrMsg = "Failed to initialize an instance of Library";
                System.Console.WriteLine($"[ERROR] {ErrMsg}");
                throw new Exception(ErrMsg);
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
                string ErrMsg = "Failed to create a new Author";
                System.Console.WriteLine($"[ERROR] {ErrMsg}");
                throw new Exception(ErrMsg);
            }
            Thread.Sleep(250);

            try
            {
                NewBook = new Books.Book("Harry Potter", NewAuthor);
                System.Console.WriteLine($"[INFO] New book created successfully: '{NewBook.BookName} by {NewBook.BookAuthor.AuthorName}'");
            }
            catch (System.Exception)
            {
                string ErrMsg = "Failed to create a new Book";
                System.Console.WriteLine($"[ERROR] {ErrMsg}");
                throw new Exception(ErrMsg);
            }
            Thread.Sleep(250);

            try
            {
                LibraryInstance.LibraryBooks.Add(NewBook);
                foreach (var book in LibraryInstance.LibraryBooks)
                {
                    System.Console.WriteLine($"[INFO] All books in Library: {book.BookName}");
                }
            }
            catch (System.Exception)
            {
                string ErrMsg = "Failed to add Book to Library";
                System.Console.WriteLine($"[ERROR] {ErrMsg}");
                throw new Exception(ErrMsg);
            }

            string TestSearchByTitleBookName = "Harry";

            try
            {
                Books.Book TestSearchByTitle = LibraryInstance.SearchForBookByTitle(TestSearchByTitleBookName);
                System.Console.WriteLine($"[INFO] Book '{TestSearchByTitle.BookName}' found!");
            }
            catch (NullReferenceException)
            {
                System.Console.WriteLine($"[INFO] Book '{TestSearchByTitleBookName}' not found.");
            }
        }
    }
}
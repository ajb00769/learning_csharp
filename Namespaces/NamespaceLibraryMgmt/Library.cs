using System;
using Books;

namespace Library
{
    public class Library
    {
        public List<Book> LibraryBooks;

        public Library()
        {
            this.LibraryBooks = new List<Book> { };
        }

        public void AddBook(Book bookObj)
        {
            this.LibraryBooks.Add(bookObj);
            System.Console.WriteLine("[INFO] Book added successfully.");
        }

        public void RemoveBook(string bookTitle)
        {
            Book FoundBook = SearchForBookByTitle(bookTitle);

            if (FoundBook != null)
            {
                try
                {
                    this.LibraryBooks.Remove(FoundBook);
                    System.Console.WriteLine($"[INFO] Book {FoundBook.BookName} removed successfully.");
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine($"[ERROR] Failed to remove book {FoundBook.BookName}. Please try again. If issue persists please report this error to the developer.");
                }
            }
            else
            {
                System.Console.WriteLine("[ERROR] Book Title not found.");
            }
        }

        public Book SearchForBookByTitle(string bookTitle)
        {
            return this.LibraryBooks.Find(book => book.BookName == bookTitle);
        }

        public Book SearchForBookByAuthor(string bookAuthor)
        {
            return this.LibraryBooks.Find(book => book.BookAuthor.AuthorName == bookAuthor);
        }

        public void PrintAllBooks()
        {
            foreach (var book in LibraryBooks)
            {
                System.Console.WriteLine(book.BookName);
            }
        }
    }
}
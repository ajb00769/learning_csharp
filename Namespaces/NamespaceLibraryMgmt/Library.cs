using System;
using System.Collections.Generic;
using Books;

namespace Library
{
    public class Library
    {
        // learning about key value pairs here as well even though I could have just opted for using the value of the internal indices
        public List<KeyValuePair<int, Book>> LibraryBooks;

        public Library()
        {
            this.LibraryBooks = new List<KeyValuePair<int, Book>> { };
        }

        public void AddBook(Book bookObj)
        {
            try
            {
                int NewKey = LibraryBooks.Count + 1;
                this.LibraryBooks.Add(new KeyValuePair<int, Book>(NewKey, bookObj));
                System.Console.WriteLine($"[INFO] Book '{bookObj.BookName}' added successfully.");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("[ERROR] Unable to add book.");
                throw;
            }
        }

        public void RemoveBook(string bookTitle)
        {
            KeyValuePair<int, Books.Book> FoundBook = SearchForBookByTitle(bookTitle);

            if (FoundBook.Value.BookName == bookTitle)
            {
                try
                {
                    this.LibraryBooks.Remove(FoundBook);
                    System.Console.WriteLine($"[INFO] Book {FoundBook.Value.BookName} removed successfully.");
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine($"[ERROR] Failed to remove book {FoundBook.Value.BookName}. Please try again. If issue persists please report this error to the developer.");
                }
            }
            else
            {
                System.Console.WriteLine("[ERROR] Book Title not found. Cannot remove book.");
            }
        }

        public KeyValuePair<int, Books.Book> SearchForBookByTitle(string bookTitle)
        {
            return this.LibraryBooks.Find(book => book.Value.BookName == bookTitle);
        }

        public KeyValuePair<int, Books.Book> SearchForBookByAuthor(string bookAuthor)
        {
            return this.LibraryBooks.Find(book => book.Value.BookAuthor.AuthorName == bookAuthor);
        }

        public void PrintAllBooks()
        {
            System.Console.WriteLine("[INFO] Printing all book titles in the library:");
            foreach (var book in LibraryBooks)
            {
                System.Console.WriteLine($"[INFO] {book.Key} - {book.Value.BookName} authored by {book.Value.BookAuthor.AuthorName}");
            }
        }
    }
}
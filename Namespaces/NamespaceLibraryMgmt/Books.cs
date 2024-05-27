using System;
using Authors;

namespace Books
{
    public class Book
    {
        public string BookName;
        public Author BookAuthor;

        public Book(string bookName, Author authorObj)
        {
            this.BookName = bookName;
            this.BookAuthor = authorObj;
        }
    }
}
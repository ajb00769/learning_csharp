using System;
using System.Globalization;

namespace Authors
{
    public class Author
    {
        public string AuthorName;
        public DateOnly AuthorBirthdate;

        public Author(string authorName, string authorBirthdate)
        {
            this.AuthorName = authorName;
            this.AuthorBirthdate = GetDateOnlyObject(authorBirthdate);
        }

        DateOnly GetDateOnlyObject(string rawDateString)
        {
            return DateOnly.ParseExact(rawDateString, "yyyy-mm-dd", CultureInfo.InvariantCulture);
        }
    }
}
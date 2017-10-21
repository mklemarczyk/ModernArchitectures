using System;

namespace ArqLibrarianClassic.Library
{
    public class Book
    {
        private readonly long id;
        private readonly string title;
        private readonly string author;
        private readonly string isbn;
        private readonly string publisher;
        private readonly int year;
        private readonly string category;

        public Book(long id, string title, string author, string isbn, string publisher, int year, string category)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.publisher = publisher;
            this.year = year;
            this.category = category;
        }

        public override string ToString()
        {
            return $"{this.id}: '{this.title}' - {this.author} [{this.isbn}] '{this.publisher}', {this.year}, '{this.category}'";
        }
    }
}
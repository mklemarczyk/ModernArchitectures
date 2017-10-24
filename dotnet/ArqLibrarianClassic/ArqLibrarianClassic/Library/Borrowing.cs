using System;
using ArqLibrarianClassic.Library;

namespace ArqLibrarianClassic
{
    public class Borrowing
    {
        private readonly User user;
        private readonly Book book;
        private readonly DateTime when;

        public Borrowing(User user, Book book)
        {
            this.user = user;
            this.book = book;
            this.when = DateTime.Now;
        }

        public long Id { get; set; }
        public long BookId => this.book.Id;
    }
}
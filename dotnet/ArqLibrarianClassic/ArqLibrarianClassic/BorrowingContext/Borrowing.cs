using System;

namespace ArqLibrarianClassic.BorrowingContext
{
    public class Borrowing
    {
        private readonly UserId user;
        private readonly BookId book;
        private readonly DateTime when;

        public Borrowing(UserId user, BookId book)
        {
            this.user = user;
            this.book = book;
            this.when = DateTime.Now;
        }

        public long Id { get; set; }
        public long BookId => this.book.Id;
    }
}
using System;

namespace ArqLibrarianClassic.BorrowingContext
{
    public class Borrowing
    {
        private readonly BorrowingRepository repository;

        private readonly UserId user;
        private readonly BookId book;
        private readonly DateTime when;
        private DateTime? returnDate;

        public Borrowing(BorrowingRepository repository, UserId user, BookId book)
        {
            this.repository = repository;

            this.user = user;
            this.book = book;
            this.when = DateTime.Now;
        }

        public long Id { get; set; }
        public long BookId => this.book.Id;
        public DateTime? ReturnDate => this.returnDate;

        public void Return()
        {
            returnDate = DateTime.Now;
            repository.Update(this);
        }
    }
}
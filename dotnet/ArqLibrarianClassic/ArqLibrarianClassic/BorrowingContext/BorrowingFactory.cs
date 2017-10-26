using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArqLibrarianClassic.BorrowingContext
{
    public class BorrowingFactory
    {
        private readonly BorrowingRepository repository;

        public BorrowingFactory(BorrowingRepository repository)
        {
            this.repository = repository;
        }

        public Borrowing CreateBorrowing(UserId user, BookId book, Terms terms)
        {
            return new Borrowing(repository, user, book);
        }

        public Terms CreateTerms(string type)
        {
            return new Terms(repository, type);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArqLibrarianClassic.BorrowingContext
{
    public class BorrowingFactory
    {
        public Borrowing CreateBorrowing(UserId user, BookId book, Terms terms)
        {
            return new Borrowing(user, book);
        }

        public Terms CreateTerms(string type)
        {
            return new Terms(type);
        }
    }
}

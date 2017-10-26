using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArqLibrarianClassic.Library
{
    public class BorrowingFactory
    {
        Borrowing CreateBorrowing(User user, Book book, Terms terms)
        {
            return new Borrowing(user, book);
        }

        public Terms CreateTerms(string type)
        {
            return new Terms(type);
        }
    }
}

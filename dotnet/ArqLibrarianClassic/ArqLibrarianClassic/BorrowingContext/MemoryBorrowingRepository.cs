using System;
using System.Collections.Generic;

namespace ArqLibrarianClassic.BorrowingContext
{
    public class MemoryBorrowingRepository : BorrowingRepository
    {
        private static List<Borrowing> borrowings = new List<Borrowing>();
        
        public void Add(Borrowing borrowing)
        {
            borrowing.Id = Generated.BorrowingId();
            borrowings.Add(borrowing);
        }

        public void Update(Borrowing borrowing)
        {
        }

        public Borrowing FindByBookId(long id)
        {
            foreach (var borrowing in borrowings)
            {
                if (borrowing.BookId == id)
                {
                    return borrowing;
                }
            }

            return null;
        }

        public Borrowing FindNotReturnedByBookId(long id)
        {
            foreach (var borrowing in borrowings)
            {
                if (borrowing.BookId == id && borrowing.ReturnDate == null)
                {
                    return borrowing;
                }
            }

            return null;
        }

        public void Init()
        {
            // no borrowings at start yet
        }

        public void Clear()
        {
            borrowings.Clear();
        }
    }
}
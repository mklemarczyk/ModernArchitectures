using System.Collections.Generic;

namespace ArqLibrarianClassic.Library
{
    public class MemoryBorrowingDao : BorrowingDao
    {
        private static List<Borrowing> borrowings = new List<Borrowing>();
        
        public void Insert(Borrowing borrowing)
        {
            borrowing.Id = Generated.BorrowingId();
            borrowings.Add(borrowing);
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
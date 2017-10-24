﻿namespace ArqLibrarianClassic
{
    public interface BorrowingDao
    {
        void Insert(Borrowing borrowing);
        Borrowing FindByBookId(long bookId);
    }
}
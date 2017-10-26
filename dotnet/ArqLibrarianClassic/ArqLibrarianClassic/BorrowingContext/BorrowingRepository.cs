﻿namespace ArqLibrarianClassic.BorrowingContext
{
    public interface BorrowingRepository
    {
        void Add(Borrowing borrowing);
        void Update(Borrowing borrowing);
        Borrowing FindByBookId(long bookId);
        Borrowing FindNotReturnedByBookId(long bookId);
    }
}
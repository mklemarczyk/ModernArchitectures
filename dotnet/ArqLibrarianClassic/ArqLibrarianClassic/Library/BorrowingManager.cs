using System;
using ArqLibrarianClassic.Library;

namespace ArqLibrarianClassic
{
    public class BorrowingManager
    {
        private UserDao userDao;
        private BooksDao bookDao;
        private BorrowingDao borrowingDao;
        
        public void Borrow(long userId, long bookId)
        {
            var user = userDao.FindById(userId);
            var book = bookDao.FindById(bookId);

            borrowingDao.Insert(new Borrowing(user, book));
        }
    }

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
    }
}
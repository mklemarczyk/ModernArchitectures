using ArqLibrarianClassic.Library;

namespace ArqLibrarianClassic
{
    public class BorrowingManager
    {
        private readonly UserDao userDao;
        private readonly BooksDao bookDao;
        private readonly BorrowingDao borrowingDao;

        public BorrowingManager(UserDao userDao, BooksDao bookDao, BorrowingDao borrowingDao)
        {
            this.userDao = userDao;
            this.bookDao = bookDao;
            this.borrowingDao = borrowingDao;
        }

        public void Borrow(long userId, long bookId)
        {
            var user = userDao.FindById(userId);
            var book = bookDao.FindById(bookId);

            borrowingDao.Insert(new Borrowing(user, book));
        }

        public bool Borrowed(long bookId)
        {
            return borrowingDao.FindByBookId(bookId) != null;
        }
    }
}
using ArqLibrarianClassic.Library;

namespace ArqLibrarianClassic
{
    public class BorrowingApplicationService
    {
        private readonly UserDao userDao;
        private readonly BooksDao bookDao;
        private readonly BorrowingRepository borrowingDao;

        public BorrowingApplicationService(UserDao userDao, BooksDao bookDao, BorrowingRepository borrowingDao)
        {
            this.userDao = userDao;
            this.bookDao = bookDao;
            this.borrowingDao = borrowingDao;
        }

        public void Borrow(long userId, long bookId)
        {
            var user = userDao.FindById(userId);
            var book = bookDao.FindById(bookId);

            borrowingDao.Add(new Borrowing(user, book));
        }

        public bool Borrowed(long bookId)
        {
            return borrowingDao.FindByBookId(bookId) != null;
        }
    }
}
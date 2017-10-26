namespace ArqLibrarianClassic.BorrowingContext
{
    public class BorrowingApplicationService
    {
        private readonly BorrowingRepository borrowingDao;

        public BorrowingApplicationService(BorrowingRepository borrowingDao)
        {
            this.borrowingDao = borrowingDao;
        }

        public void Borrow(long userId, long bookId)
        {
            var user = new UserId(userId);
            var book = new BookId(bookId);

            borrowingDao.Add(new Borrowing(user, book));
        }

        public bool Borrowed(long bookId)
        {
            return borrowingDao.FindByBookId(bookId) != null;
        }
    }
}
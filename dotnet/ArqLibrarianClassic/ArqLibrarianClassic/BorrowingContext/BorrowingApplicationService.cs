namespace ArqLibrarianClassic.BorrowingContext
{
    public class BorrowingApplicationService
    {
        private readonly BorrowingFactory borrowingFactory;
        private readonly BorrowingRepository borrowingDao;

        public BorrowingApplicationService(BorrowingFactory borrowingFactory, BorrowingRepository borrowingDao)
        {
            this.borrowingFactory = borrowingFactory;
            this.borrowingDao = borrowingDao;
        }

        public void Borrow(long userId, long bookId)
        {
            var user = new UserId(userId);
            var book = new BookId(bookId);
            var terms = borrowingFactory.CreateTerms(null);

            borrowingDao.Add(borrowingFactory.CreateBorrowing(user, book, terms));
        }

        public bool Borrowed(long bookId)
        {
            return borrowingDao.FindByBookId(bookId) != null;
        }
    }
}
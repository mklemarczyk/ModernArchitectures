namespace ArqLibrarianClassic.BorrowingContext
{
    public struct BookId
    {
        private long id;

        public long Id => id;

        public BookId(long id)
        {
            this.id = id;
        }
    }
}

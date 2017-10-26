namespace ArqLibrarianClassic.BorrowingContext
{
    public struct UserId
    {
        private long id;

        public long Id => id;

        public UserId(long id)
        {
            this.id = id;
        }
    }
}

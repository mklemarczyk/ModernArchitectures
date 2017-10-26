using System;
using ArqLibrarianClassic.BorrowingContext;
using ArqLibrarianClassic.Library;

namespace ArqLibrarianClassic
{
    static class MainClass
    {
        public static void Main(string[] args)
        {
            var application = new Application(new ConsoleIn(), new ConsoleOut());
            var booksDao = CreateBooksDao();
            application.Setup(new BooksManager(booksDao));
            var borrowingRepository = CreateMemoryBorrowingDao();
            application.Setup(new BorrowingApplicationService(CreateBorrowingFactory(borrowingRepository), borrowingRepository));
            application.Start();
        }

        private static BorrowingFactory CreateBorrowingFactory(BorrowingRepository repository)
        {
            var factory = new BorrowingFactory(repository);

            return factory;
        }

        private static MemoryBorrowingRepository CreateMemoryBorrowingDao()
        {
            var dao = new MemoryBorrowingRepository();
            dao.Init();
            
            return dao;
        }

        private static MemoryUserDao CreateMemoryUserDao()
        {
            var dao = new MemoryUserDao();
            dao.Init();
            return dao;
        }

        private static MemoryBooksDao CreateBooksDao()
        {
            var dao = new MemoryBooksDao();
            dao.Init();
            
            return dao;
        }
    }
}

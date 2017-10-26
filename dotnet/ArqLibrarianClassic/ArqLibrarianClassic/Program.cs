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
            application.Setup(new BorrowingApplicationService(CreateBorrowingFactory(), CreateMemoryBorrowingDao()));
            application.Start();
        }

        private static BorrowingFactory CreateBorrowingFactory()
        {
            var factory = new BorrowingFactory();

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

using System;
using Bnsit.ArqLibrarianClassic.Library;

namespace Bnsit.ArqLibrarianClassic
{
    static class MainClass
    {
        public static void Main(string[] args)
        {
            var application = new Application(new ConsoleIn(), new ConsoleOut());
            application.Setup(new BooksManager(CreateBooksDao()));
            application.Start();
        }
        
        private static MemoryBooksDao CreateBooksDao()
        {
            var dao = new MemoryBooksDao();
            dao.Init();
            
            return dao;
        }
    }
}

using System.Collections.Generic;

namespace ArqLibrarianClassic.Library
{
    public class BooksManager
    {
        private readonly BooksDao dao = null;

        public BooksManager(BooksDao dao)
        {
            this.dao = dao;
        }

        public IEnumerable<Book> FindAll()
        {
            return dao.FindAll();
        }
    }
}
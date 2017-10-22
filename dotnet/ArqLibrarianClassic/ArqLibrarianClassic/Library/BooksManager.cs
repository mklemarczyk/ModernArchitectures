using System.Collections.Generic;

namespace Bnsit.ArqLibrarianClassic.Library
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

        public void Create(string title, string author, string isbn, string publisher, int year, string category)
        {    
            dao.Insert(new Book(title, author, isbn, publisher, year, category));
        }

        public IEnumerable<Book> FindByTitle(string title)
        {
            return dao.FindByTitle(title);
        }
    }
}
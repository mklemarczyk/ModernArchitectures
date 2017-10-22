using System.Collections.Generic;
using System.Linq;

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

        public void Create(string title, string author, string isbn, string publisher, int year, string category)
        {    
            dao.Insert(new Book(title, author, isbn, publisher, year, category));
        }

        public IEnumerable<Book> FindByTitle(string title)
        {
            return dao.FindByTitle(title);
        }

        public void Rate(long id, int rating)
        {
            Book book = dao.FindById(id);

            book.Add(new SingleRating(rating));

            dao.Save(book);
        }

        public Book FindById(long id)
        {
            return dao.FindById(id);
        }

        public double ComputeRatingFor(long bookId)
        {
            var book = dao.FindById(bookId);

            if (book.Ratings.Count == 0)
            {
                return -1.0;
            }
            
            
            return book.Ratings.Average(b => b.Rating);
        }
    }
}
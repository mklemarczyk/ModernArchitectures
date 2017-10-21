using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using ArqLibrarianClassic.Library;

namespace ArqLibrarianClassic.Library
{
    public class MemoryBooksDao : BooksDao
    {
        private static readonly List<Book> books = new List<Book>();
        
        public void Create(string title, string author, string isbn, string publisher, int year, string category) 
        {
            books.Add(new Book(Generated.BookId(), title, author, isbn, publisher, year, category));
        }

        public IEnumerable<Book> FindAll()
        {
            return books.AsEnumerable();
        }
    }
}
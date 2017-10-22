using System.Collections.Generic;

namespace ArqLibrarianClassic.Library
 {
     public interface BooksDao
     {
         void Insert(Book book);
         IEnumerable<Book> FindAll();
         IEnumerable<Book> FindByTitle(string title);
         Book FindById(long id);
         void Save(Book book);
     }
 }
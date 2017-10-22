using System.Collections.Generic;

namespace Bnsit.ArqLibrarianClassic.Library
 {
     public interface BooksDao
     {
         void Insert(Book book);
         IEnumerable<Book> FindAll();
         IEnumerable<Book> FindByTitle(string title);
     }
 }
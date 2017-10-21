using System.Collections.Generic;

namespace ArqLibrarianClassic.Library
 {
     public interface BooksDao {
         void Create(string title, string author, string isbn, string publisher, int year, string category);
         IEnumerable<Book> FindAll();
     }
 }
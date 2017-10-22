using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Bnsit.ArqLibrarianClassic.Library;

namespace Bnsit.ArqLibrarianClassic.Library
{
    public class MemoryBooksDao : BooksDao
    {
        private static readonly List<Book> books = new List<Book>();

        public void Insert(Book book)
        {
            book.Id = Generated.BookId();
            books.Add(book);
        }

        public IEnumerable<Book> FindAll()
        {
            return books.AsEnumerable();
        }

        public IEnumerable<Book> FindByTitle(string title)
        {
            return books.Where(b => b.Title.ToLower().Contains(title.ToLower()));
        }

        public Book FindById(long id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public void Save(Book book)
        {
            //nothing to be done, it's memory implementation, so everything is "persisted" instantly
        }

        public void Init()
        {
            books.Clear();
            Insert(new Book("Karolcia", "Maria Kruger", "978-83-7568-638-8", "Siedmioróg", 2011, "Literatura dla dzieci i młodzieży"));
            Insert(new Book("Komunikacja niewerbalna. Płeć i kultura", "Ewa Głażewska, Urszula Kusio", "978-83-7784-177-8", "Wydawnictwo Uniwersytetu Marii Curie-Skłodowskiej", 2012, "Nauki społeczne"));
            Insert(new Book("O powstawaniu gatunków", "Karol Darwin", "978-83-62948-42-0", "Biblioteka Analiz", 2006, "Literatura popularnonaukowa"));
            Insert(new Book("Pedagogika ogólna", "Bogusław Śliwerski", "978-83-7850-169-5", "Oficyna Wydawnicza IMPULS", 2013, "Nauki społeczne"));
            Insert(new Book("Pinokio", "Carlo Collodi", "978-83-7895-249-7", "ZIELONA SOWA", 2009, "Podręczniki i lektury szkolne"));
            Insert(new Book("Podstawy detektywistyki", "Tomasz Aleksandrowicz, Jerzy Konieczny, Anna Konik", "978-83-60807-30-9", "Łośgraf", 2008, "Prawo"));
            Insert(new Book("Renesans", "Adam Karpiński","978-83-01-15409-7", "Wydawnictwo Naukowe PWN", 2007, "Nauki humanistyczne"));
        }
    }
}
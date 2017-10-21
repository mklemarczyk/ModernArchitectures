using System;
using ArqLibrarianClassic.Library;

namespace ArqLibrarianClassic
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
            dao.Create("Karolcia", "Maria Kruger", "978-83-7568-638-8", "Siedmioróg", 2011, "Literatura dla dzieci i młodzieży");
            dao.Create("Komunikacja niewerbalna. Płeć i kultura", "Ewa Głażewska, Urszula Kusio", "978-83-7784-177-8", "Wydawnictwo Uniwersytetu Marii Curie-Skłodowskiej", 2012, "Nauki społeczne");
            dao.Create("O powstawaniu gatunków", "Karol Darwin", "978-83-62948-42-0", "Biblioteka Analiz", 2006, "Literatura popularnonaukowa");
            dao.Create("Pedagogika ogólna", "Bogusław Śliwerski", "978-83-7850-169-5", "Oficyna Wydawnicza IMPULS", 2013, "Nauki społeczne");
            dao.Create("Pinokio", "Carlo Collodi", "978-83-7895-249-7", "ZIELONA SOWA", 2009, "Podręczniki i lektury szkolne");
            dao.Create("Podstawy detektywistyki", "Tomasz Aleksandrowicz, Jerzy Konieczny, Anna Konik", "978-83-60807-30-9", "Łośgraf", 2008, "Prawo");
            dao.Create("Renesans", "Adam Karpiński","978-83-01-15409-7", "Wydawnictwo Naukowe PWN", 2007, "Nauki humanistyczne");
            
            return dao;
        }
    }
}

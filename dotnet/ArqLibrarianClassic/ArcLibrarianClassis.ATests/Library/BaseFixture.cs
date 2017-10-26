using System.Linq;
using ArqLibrarianClassic;
using ArqLibrarianClassic.BorrowingContext;
using ArqLibrarianClassic.Library;

namespace ArcLibrarianClassis.ATests.Library
{
    public class LibraryFixture
    {
        private int startBooksCount = 0;  
        public int StartBooksCount => startBooksCount;

        private Application application;
        private SpyUserIn userIn;
        private SpyUserOut userOut;
        
        private BooksManager booksManager;
        private BorrowingApplicationService borrowingManager;
        private UserDao userDao;

        public void ApplicationStarted()
        {
            this.userOut = new SpyUserOut();    
            this.userIn = new SpyUserIn(userOut);

            this.application = new Application(userIn, userOut);
            
            var booksDao = CreateBooksDao();
            this.booksManager = new BooksManager(booksDao);
            this.application.Setup(this.booksManager);
            
            this.userDao = CreateUserDao();
            var repository = CreateBorrowingDao();
            this.borrowingManager = new BorrowingApplicationService(CreateBorrowingFactory(repository), repository);
            this.application.Setup(this.borrowingManager);
        }

        public void HasSampleBooks() 
        {
            this.booksManager.Create("Karolcia", "Maria Kruger", "978-83-7568-638-8", "Siedmioróg", 2011, "Literatura dla dzieci i młodzieży");
            this.booksManager.Create("Komunikacja niewerbalna. Płeć i kultura", "Ewa Głażewska, Urszula Kusio", "978-83-7784-177-8", "Wydawnictwo Uniwersytetu Marii Curie-Skłodowskiej", 2012, "Nauki społeczne");
            this.booksManager.Create("O powstawaniu gatunków", "Karol Darwin", "978-83-62948-42-0", "Biblioteka Analiz", 2006, "Literatura popularnonaukowa");
            this.booksManager.Create("Pedagogika ogólna", "Bogusław Śliwerski", "978-83-7850-169-5", "Oficyna Wydawnicza IMPULS", 2013, "Nauki społeczne");
            this.booksManager.Create("Pinokio", "Carlo Collodi", "978-83-7895-249-7", "ZIELONA SOWA", 2009, "Podręczniki i lektury szkolne");
            this.booksManager.Create("Podstawy detektywistyki", "Tomasz Aleksandrowicz, Jerzy Konieczny, Anna Konik", "978-83-60807-30-9", "Łośgraf", 2008, "Prawo");
            this.booksManager.Create("Renesans", "Adam Karpiński","978-83-01-15409-7", "Wydawnictwo Naukowe PWN", 2007, "Nauki humanistyczne");
            this.startBooksCount = 7;
            
        }

        public void HasSampleUsers()
        {
            this.userDao.Insert(new User("kowalski", "kowal", "Jan Kowalski", "Gdynia", "87052507754"));
            this.userDao.Insert(new User("nowak", "nowypass", "Piotr Nowak", "Warszawa", "890224031121"));
            this.userDao.Insert(new User("koper", "dupadupa", "Wojciech Koperski", "Zakopane", "91121202176"));
        }

        public void Then()
        {
            this.userIn.EnterLine("exit");
            this.application.Start();
        }
        
        public void SystemShows(string text)
        {   // converting from more friedly regexp
            this.userOut.AssertContains(text.Replace("*", ".*"));
        }
        
        public void HasBook(string title, string author, string isbn, string publisher, int year, string category)
        {
            this.booksManager.Create(title, author, isbn, publisher, year, category);
        }


        public void SystemShowsAtLeastLines(int expectedCount)
        {
            this.userOut.AssertCountainsAtLeastLines(expectedCount);
        }

        public void UserEnters(string text)
        {
            this.userIn.EnterLine(text);
        }

        private static MemoryBooksDao CreateBooksDao()
        {
            ArqLibrarianClassic.Library.Generated.ResetBookId();
            var dao = new MemoryBooksDao();
            dao.Clear();
            
            return dao;
        }

        private static BorrowingFactory CreateBorrowingFactory(BorrowingRepository repository)
        {
            var factory = new BorrowingFactory(repository);

            return factory;
        }

        private static UserDao CreateUserDao()
        {
            ArqLibrarianClassic.Library.Generated.ResetUserId();
            var dao = new MemoryUserDao();
            dao.Clear();
            
            return dao;            
        }
        
        private BorrowingRepository CreateBorrowingDao()
        {
            ArqLibrarianClassic.BorrowingContext.Generated.ResetBorrowingId();
            var dao = new MemoryBorrowingRepository();
            dao.Clear();
            
            return dao; 
        }

        public static string Title(string title)
        {
            return title;
        }

        public static string Author(string author)
        {
            return author;
        }

        public static string Publisher(string publisher)
        {
            return publisher;
        }

        public long BookIdByTitle(string title)
        {
            return this.booksManager.FindByTitle(title).FirstOrDefault().Id;
        }
    }
}
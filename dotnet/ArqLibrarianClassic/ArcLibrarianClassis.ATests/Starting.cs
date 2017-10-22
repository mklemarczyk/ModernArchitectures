using System.Net;
using System.Security.Policy;
using NUnit.Framework;
using Bnsit.ArqLibrarianClassic.Library;

namespace Bnsit.ArqLibrarianClassic.ATests
{
    [TestFixture()]
    public class Starting
    {
        private const int BooksCount = 7;

        private Application application;
        private SpyUserIn userIn;
        private SpyUserOut userOut;
        
        private BooksManager booksManager;


        [SetUp]
        public void SetupFixture()
        {
            userOut = new SpyUserOut();    
            userIn = new SpyUserIn(userOut);

            application = new Application(userIn, userOut);

            // given
            ApplicationStarted();
            HasSampleBooks();
        }


        [Test()]
        public void ShouldShowHelloAtTheBegining()
        {            
            //given
            //see SetUp

            Then();
            WelcomeTextDisplayed();
        }

        [Test]
        public void ShouldSearchAllBooks()
        {
            //given
            //see SetUp

            //when
            UserEnters("search");
            Then();
            SystemShows(Title("Karolcia"));
            SystemShows(Publisher("ZIELONA SOWA"));
            SystemShows(Title("Renesans"));
            SystemShows(Author("Jerzy Konieczny"));
            SystemShowsAtLeastLines(BooksCount);
        }

        [Test]
        public void ShouldAddBook()
        {
            //given
            //see SetUp
            UserEnters("add");
            UserEnters("Ogniem i mieczem");
            UserEnters("Henryk Sienkiewicz");
            UserEnters("978-83-08-06015-5");
            UserEnters("Wydawnictwo Literackie");
            UserEnters("2016");
            UserEnters("Podręczniki i lektury szkolne");
            
            //when
            UserEnters("search");
            
            Then();
            SystemShows(Title("Ogniem i mieczem"));
            SystemShows(Author("Henryk Sienkiewicz"));
            SystemShows(Publisher("Wydawnictwo Literackie"));         
        }

        [Test]
        public void ShouldSearchByTitle()
        {
            //given
            //see SetUp
            HasBook("Ogniem i mieczem", "Henryk Sienkiewicz", "978-83-08-06015-5", "Wydawnictwo Literackie", 2016, "Podręczniki i lektury szkolne");
            
            //when
            UserEnters("search Ogniem i mieczem");

            Then();
            SystemShows("Found: 'Ogniem i mieczem'");
            SystemShows(Title("Ogniem i mieczem"));          
        }

        [Test]
        public void ShouldRateABook()
        {
            const long BookId = 8;
            const int Rating = 4;
            //given
            //see SetUp
            HasBook("Ogniem i mieczem", "Henryk Sienkiewicz", "978-83-08-06015-5", "Wydawnictwo Literackie", 2016, "Podręczniki i lektury szkolne");

            //when
            UserEnters($"rate {BookId} {Rating}");
            UserEnters("search ogniem i mieczem");

            Then();
            SystemShows($"Ogniem i mieczem rated: {Rating}");
            SystemShows($"Ogniem i mieczem* rating: {Rating}");
        }

        private void HasBook(string title, string author, string isbn, string publisher, int year, string category)
        {
            booksManager.Create(title, author, isbn, publisher, year, category);
        }

        private void HasSampleBooks()
        {
            booksManager = new BooksManager(CreateBooksDao());
            application.Setup(booksManager);
        }

        private void SystemShowsAtLeastLines(int expectedCount)
        {
            userOut.AssertCountainsAtLeastLines(expectedCount);
        }

        private void SystemShows(string text)
        {
            userOut.AssertContains(text.Replace("*", ".*"));
        }

        private void Then()
        {
            userIn.EnterLine("exit");
            application.Start();
        }

        private void UserEnters(string text)
        {
            userIn.EnterLine(text);
        }

        private static void ApplicationStarted()
        {
            // for readibility reasons
        }

        private static MemoryBooksDao CreateBooksDao()
        {
            Generated.ResetBookId();
            var dao = new MemoryBooksDao();
            dao.Init();
          
            return dao;
        }

        private void WelcomeTextDisplayed() 
        {
            userOut.AssertContains("Welcome to the ArqLibrarian");
        }
        
        private static string Publisher(string publisher)
        {
            return publisher;
        }

        private static string Author(string author)
        {
            return author;
        }

        private static string Title(string title)
        {
            return title;
        }
    }
    
}

using ArcLibrarianClassis.ATests.Library;
using NUnit.Framework;

namespace ArcLibrarianClassis.ATests.Borrowing
{
    [TestFixture]
    public class BorrowABook
    {
        private LibraryFixture fixture = null;
        
        [SetUp]
        public void SetupFixture()
        {
            fixture = new LibraryFixture();
        }

        [Test]
        public void ShouldBorrowABook()
        {
            fixture.ApplicationStarted();
            fixture.HasSampleBooks();
            fixture.HasBook("Ogniem i mieczem", "Henryk Sienkiewicz", "978-83-08-06015-5", "Wydawnictwo Literackie", 2016, "Podręczniki i lektury szkolne");
            long id = fixture.BookIdByTitle("Ogniem i mieczem");
            
            //when
            fixture.UserEnters($"borrow {id}");
            fixture.UserEnters($"status {id}");
            
            fixture.Then();
            fixture.SystemShows("[borrowed] Ogniem i mieczem");           
        }

        [Test]
        [Ignore]
        public void ShouldRejectBorrowingWhenBookAlreadyBorrowed()
        {
            // implement
        }
    }
}
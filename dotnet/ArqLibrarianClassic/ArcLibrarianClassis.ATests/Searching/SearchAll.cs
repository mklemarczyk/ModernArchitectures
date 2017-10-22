using ArcLibrarianClassis.ATests.Library;
using NUnit.Framework;

namespace ArcLibrarianClassis.ATests.Searching
{
    [TestFixture]
    public class SearchAll
    {
        private LibraryFixture fixture = null;
        
        [SetUp]
        public void SetupFixture()
        {
            fixture = new LibraryFixture();
        }  
        
        [Test]
        public void ShouldSearchAllBooks()
        {
            fixture.ApplicationStarted();
            fixture.HasSampleBooks();

            fixture.UserEnters("search");
            
            fixture.Then();
            fixture.SystemShows(LibraryFixture.Title("Karolcia"));
            fixture.SystemShows(LibraryFixture.Author("Maria Kruger"));
            fixture.SystemShows(LibraryFixture.Title("Renesans"));
            fixture.SystemShows(LibraryFixture.Author("Jerzy Konieczny"));
            fixture.SystemShowsAtLeastLines(fixture.StartBooksCount);
        }
    }
}
using ArcLibrarianClassis.ATests.Library;
using static ArcLibrarianClassis.ATests.Library.LibraryFixture;
using NUnit.Framework;

namespace ArcLibrarianClassis.ATests.Searching
{
    [TestFixture]
    public class SearchByTitle
    {
        private LibraryFixture fixture = null;
        
        [SetUp]
        public void SetupFixture()
        {
            fixture = new LibraryFixture();
        } 
        
        [Test]
        public void ShouldSearchByTitle()
        {
            fixture.ApplicationStarted();
            fixture.HasSampleBooks();

            fixture.HasBook("Ogniem i mieczem", "Henryk Sienkiewicz", "978-83-08-06015-5", "Wydawnictwo Literackie", 2016, "Podręczniki i lektury szkolne");
            
            //when
            fixture.UserEnters("search Ogniem i mieczem");

            fixture.Then();
            fixture.SystemShows("Found: 'Ogniem i mieczem'");
            fixture.SystemShows(Title("Ogniem i mieczem"));          
        }    
    }
}
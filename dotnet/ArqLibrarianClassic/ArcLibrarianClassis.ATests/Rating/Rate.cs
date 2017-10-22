using ArcLibrarianClassis.ATests.Library;
using NUnit.Framework;

namespace ArcLibrarianClassis.ATests.Rating
{
    [TestFixture]
    public class Rate
    {
        private LibraryFixture fixture = null;
        
        [SetUp]
        public void SetupFixture()
        {
            fixture = new LibraryFixture();
        } 
        [Test]
        public void ShouldRateABook()
        {
            
            fixture.ApplicationStarted();
            fixture.HasSampleBooks();
            fixture.HasBook("Ogniem i mieczem", "Henryk Sienkiewicz", "978-83-08-06015-5", "Wydawnictwo Literackie", 2016, "Podręczniki i lektury szkolne");

            //when
            long BookId = fixture.BookIdByTitle("Ogniem i mieczem");
            const int Rating = 4;
            fixture.UserEnters($"rate {BookId} {Rating}");
            fixture.UserEnters("search ogniem i mieczem");

            fixture.Then();
            fixture.SystemShows($"Ogniem i mieczem rated: {Rating}");
            fixture.SystemShows($"Ogniem i mieczem* rating: {Rating}");
        }
    }
}
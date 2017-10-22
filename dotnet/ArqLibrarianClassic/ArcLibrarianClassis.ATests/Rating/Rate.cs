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
            long id = fixture.BookIdByTitle("Ogniem i mieczem");
            const int Rating = 4;

            //when
            fixture.UserEnters($"rate {id} {Rating}");
            fixture.UserEnters("search ogniem i mieczem");

            fixture.Then();
            fixture.SystemShows($"Ogniem i mieczem rated: {Rating}");
            fixture.SystemShows($"Ogniem i mieczem* rating: {Rating}");
        }

        [Test]
        public void ShouldRateABookMultipleTimes()
        {
            fixture.ApplicationStarted();
            fixture.HasSampleBooks();
            fixture.HasBook("Ogniem i mieczem", "Henryk Sienkiewicz", "978-83-08-06015-5", "Wydawnictwo Literackie", 2016, "Podręczniki i lektury szkolne");
            long id = fixture.BookIdByTitle("Ogniem i mieczem");
            const int firstRating = 4;
            fixture.UserEnters($"rate {id} {firstRating}");
            
            //when
            const int secondRating = 2;
            fixture.UserEnters($"rate {id} {secondRating}");
            fixture.UserEnters("search ogniem i mieczem");
            
            fixture.Then();
            const int expectedRating = 3;
            fixture.SystemShows($"Ogniem i mieczem rated* total rating: {expectedRating}");
            fixture.SystemShows($"\"Ogniem i mieczem\"* rating: {expectedRating}");
        }
    }
}
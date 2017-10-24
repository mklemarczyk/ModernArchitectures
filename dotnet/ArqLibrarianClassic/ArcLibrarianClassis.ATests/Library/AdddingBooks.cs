﻿using NUnit.Framework;

namespace ArcLibrarianClassis.ATests.Library
{
    [TestFixture]
    public class AddABook
    {
        private LibraryFixture fixture;

        [SetUp]
        public void SetupFixture()
        {
            this.fixture = new LibraryFixture();
        }

        [Test]
        public void ShouldAddBook()
        {
            fixture.ApplicationStarted();
            fixture.HasSampleBooks();
            
            fixture.UserEnters("add");
            fixture.UserEnters("Ogniem i mieczem");
            fixture.UserEnters("Henryk Sienkiewicz");
            fixture.UserEnters("978-83-08-06015-5");
            fixture.UserEnters("Wydawnictwo Literackie");
            fixture.UserEnters("2016");
            fixture.UserEnters("Podręczniki i lektury szkolne");
            
            fixture.UserEnters("search");
            
            fixture.Then();
            
            fixture.SystemShows("Ogniem i mieczem*Henryk Sienkiewicz*Podręczniki i lektury szkolne");
        }       
    }
}
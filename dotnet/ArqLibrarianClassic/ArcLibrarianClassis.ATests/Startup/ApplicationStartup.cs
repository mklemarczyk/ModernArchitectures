﻿using ArcLibrarianClassis.ATests.Library;
using NUnit.Framework;

namespace ArcLibrarianClassis.ATests.Startup
{
    [TestFixture()]
    public class ApplicationStartup
    {
        private LibraryFixture fixture;

        [SetUp]
        public void SetupFixture()
        {
            this.fixture = new LibraryFixture();
        }


        [Test()]
        public void ShouldShowHelloAtTheBegining()
        {            
            fixture.ApplicationStarted();
            fixture.HasSampleBooks();

            fixture.Then();
            fixture.SystemShows("Welcome to the ArqLibrarian");
        }
    }
}

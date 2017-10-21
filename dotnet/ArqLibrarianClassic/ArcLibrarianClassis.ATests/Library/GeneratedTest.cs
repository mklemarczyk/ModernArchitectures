﻿using NUnit.Framework;

namespace ArqLibrarianClassic.Library
{
    [TestFixture]
    public class GeneratedTest
    {
        [Test]
        public void ShouldGenerateConsequtiveIdsForBooks()
        {
            Assert.AreEqual(1, Generated.BookId());
            Assert.AreEqual(2, Generated.BookId());
            Assert.AreEqual(3, Generated.BookId());
            Assert.AreEqual(4, Generated.BookId());
            Assert.AreEqual(5, Generated.BookId());
        }
        
    }
}
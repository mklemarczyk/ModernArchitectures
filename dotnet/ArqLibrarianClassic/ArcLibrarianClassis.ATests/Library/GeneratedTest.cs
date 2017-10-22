﻿using NUnit.Framework;

namespace Bnsit.ArqLibrarianClassic.Library
{
    [TestFixture]
    public class GeneratedTest
    {
        [Test]
        public void ShouldGenerateConsequtiveIdsForBooks()
        {
            Generated.ResetBookId();
            Assert.AreEqual(1, Generated.BookId());
            Assert.AreEqual(2, Generated.BookId());
            Assert.AreEqual(3, Generated.BookId());
            Assert.AreEqual(4, Generated.BookId());
            Assert.AreEqual(5, Generated.BookId());
        }     
    }
}
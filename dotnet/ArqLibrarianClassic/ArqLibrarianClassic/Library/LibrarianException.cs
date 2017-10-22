using System;

namespace ArqLibrarianClassic.Library
{
    public class LibrarianException : Exception
    {
        public LibrarianException(string message) : base(message)
        {
        }
    }
}
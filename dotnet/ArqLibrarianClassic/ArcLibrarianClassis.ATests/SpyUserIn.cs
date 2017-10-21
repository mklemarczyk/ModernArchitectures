using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArqLibrarianClassic.ATests
{
    public class SpyUserIn : UserIn
    {
        private Queue<string> entered = new Queue<string>();

        internal void EnterLine(string text)
        {
            entered.Enqueue(text);
        }

        public string ReadLine()
        {
            return entered.Dequeue();
        }
    }
}

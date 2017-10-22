using System.Collections.Generic;
using ArqLibrarianClassic;

namespace ArcLibrarianClassis.ATests
{
    public class SpyUserIn : UserIn
    {
        private readonly InputAware input;
        private readonly Queue<string> entered = new Queue<string>();

        public SpyUserIn(InputAware input)
        {
            this.input = input;
        }

        internal void EnterLine(string text)
        {
            entered.Enqueue(text);
            input.OnTextLineEntered(text);
        }

        public string ReadLine()
        {
            return entered.Dequeue();
        }
    }
}

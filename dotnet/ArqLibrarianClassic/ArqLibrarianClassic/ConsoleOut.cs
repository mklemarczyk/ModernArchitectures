using System;
namespace Bnsit.ArqLibrarianClassic
{
    public class ConsoleOut : UserOut
    {
        public void Print(string text)
        {
            Console.Write(text);
        }

        public void PrintLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}

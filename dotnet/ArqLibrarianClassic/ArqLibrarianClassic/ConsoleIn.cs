using System;
namespace ArqLibrarianClassic
{
    public class ConsoleIn : UserIn
    {
        public string ReadLine()
        {
            var result = Console.ReadLine().Trim();
            // Console in buffers enter, so we swallow it
            Console.ReadKey();
            return result;
        }
    }
}

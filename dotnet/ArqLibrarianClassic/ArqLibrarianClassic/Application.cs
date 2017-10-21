using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArqLibrarianClassic.Library;

namespace ArqLibrarianClassic
{
    public class Application
    {
        private readonly UserIn input;
        private readonly UserOut output;
        private BooksManager booksManager;


        public Application(UserIn input, UserOut output)
        {
            this.input = input;
            this.output = output;
        }


        public bool Start()
        {
            output.PrintLine("Welcome to the ArqLibrarian");

            var running = true;

            while (running) {
                output.Print("> ");
                var commandString = input.ReadLine();
                var args = commandString.Split(' ');
                var commandName = args[0];

                switch (commandName)
                {
                    case "exit":
                        running = false;
                        break;
                    case "search":
                        var books = booksManager.FindAll();

                        foreach (var book in books)
                        {
                            output.PrintLine(book.ToString());
                        }
                        break;
                    case "borrow":
                        output.PrintLine("Borrow entered");
                        break;
                    default:
                        output.PrintLine($"Comand {commandName} not recognized");
                        break;
                }
            }

            return running;
        }

        public void Setup(BooksManager manager)
        {
            this.booksManager = manager;
        }
    }
}

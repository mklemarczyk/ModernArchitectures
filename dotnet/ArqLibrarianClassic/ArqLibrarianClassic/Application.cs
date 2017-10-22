using System;
using System.Collections.Generic;
using System.Linq;
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
                        SearchBook(commandString);
                        break;
                    case "add":
                        AddBook();
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

        private void SearchBook(string command)
        {  
            IEnumerable<Book> books = null;
            if (HasParameters(command))
            {
                books = booksManager.FindAll();
            }
            else
            {
                var toSearch = SubstringAfterFirstSpace(command);
  
                books = booksManager.FindByTitle(toSearch);
                if (books.Any())
                {
                    output.PrintLine($"Found: '{toSearch}'");
                }
                else
                {
                    output.PrintLine($"'{toSearch}' title not Found");
                }
            }

            Print(books);
        }

        private static bool HasParameters(string command)
        {
            return command.IndexOf(' ') < 0;
        }

        private static string SubstringAfterFirstSpace(string command)
        {
            return command.Substring(command.IndexOf(' ') + 1);
        }

        private void Print(IEnumerable<Book> books)
        {
            foreach (Book book in books)
            {
                output.PrintLine(book.ToString());
            }
        }

        private void AddBook()
        {
            output.PrintLine("Adding a new book");
            output.Print("Title: ");
            string title = input.ReadLine();
            
            output.Print("Author: ");
            string author = input.ReadLine();

            output.Print("isbn: ");
            string isbn = input.ReadLine();
            
            output.Print("Publihser: ");
            string publisher = input.ReadLine();
            
            output.Print("Year: ");
            var yearString = input.ReadLine();
            int year = int.Parse(yearString);
            
            output.Print("Category: ");
            string category = input.ReadLine();

            booksManager.Create(title, author, isbn, publisher, year, category);
        }

        public void Setup(BooksManager manager)
        {
            this.booksManager = manager;
        }
    }
}

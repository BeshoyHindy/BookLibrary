using BookLibrary.Domain.Data.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using BookLibrary.Domain.Data.Models;
using BookLibrary.Domain.Data.Service;

namespace BookLibrary.UI.App
{
    class Program
    {
        private static LibraryService _libraryService;
        static void Main(string[] args)
        {
            _libraryService = new LibraryService();
            string command = "";
            do
            {
                Console.WriteLine("\r\n-- COMMAND LIST --");
                Console.WriteLine("  LA. List all authors");
                Console.WriteLine("  LB. List all books");
                Console.WriteLine("  LM. List all magazine");
                Console.WriteLine("  FBN. Find book by ISBN");
                Console.WriteLine("  FMN. Find magazine by ISBN");
                Console.WriteLine("  FBMN. Find book or magazine by ISBN");
                Console.WriteLine("  FBA. Find book by author");
                Console.WriteLine("  FMA. Find magazine by author");
                Console.WriteLine("  FBMA. Find book or magazine by author");
                Console.WriteLine("  SB. List books sorted by title");
                Console.WriteLine("  SM. List magazine sorted by title");


                Console.WriteLine("  Q. Quit");

                command = Console.ReadLine()?.Trim().ToLower();

                Execute(command);
            } while (command != "q");


        }

        private static void Execute(string command)
        {
            switch (command)
            {
                case "la":
                    ListAllAuthors();
                    break;
                case "lb":
                    ListAllBooks();
                    break;
                case "lm":
                    ListAllMagazines();
                    break;
                case "fbn":
                    FindBookByIsbnNumber();
                    break;
                case "fmn":
                    FindMagazineByIsbnNumber();
                    break;
                case "fbmn":
                    FindBookOrMagazineByIsbnNumber();
                    break;
                case "fba":
                    FindBookByAuthor();
                    break;
                case "fma":
                    FindMagazineByAuthor();
                    break;
                case "fbma":
                    FindBookOrMagazineByAuthor();
                    break;
                case "sb":
                    ListAllBooks(true);
                    break;
                case "sm":
                    ListAllMagazines(true);
                    break;

                case "q":
                    break;
                default:
                    Console.WriteLine("\r\nIncorrect command.");
                    break;
            }
        }

        private static void ListAllAuthors()
        {
            var authors = _libraryService.GetAllAuthors();
            if (authors.Any())
            {
                PrintOutList<Author>(authors, $"\r -- Authors list :\n");
            }
            else
            {
                Console.WriteLine("\r -- Authors list not found.");
            }

        }
        private static void ListAllBooks(bool sorted = false)
        {
            var books = _libraryService.GetAllBooks();
            if (books.Any())
            {
                if (sorted)
                {
                    books.Sort();
                }
                PrintOutBooks(books, $"\r -- Books list :\n");
            }
            else
            {
                Console.WriteLine("\r -- Books items list not found.");
            }

        }
        private static void ListAllMagazines(bool sorted = false)
        {
            var magazines = _libraryService.GetAllMagazines();
            if (magazines.Any())
            {
                if (sorted)
                {
                    magazines.Sort();
                }
                PrintOutMagazines(magazines, $"\r -- Magazines list :\n");
            }
            else
            {
                Console.WriteLine("\r -- Magazines items list not found.");
            }

        }

        private static void FindBookByIsbnNumber()
        {
            var isbn = PrintOutInput("\r\n=>Enter the book's ISBN number : ");
            var books = _libraryService.GetBooksByIsbnNumber(isbn);
            if (books.Any())
            {
                PrintOutBooks(books, $"\r Search book results:\n");
            }
            else
            {
                Console.WriteLine("\r -- Items not found.");
            }
        }
        private static void FindMagazineByIsbnNumber()
        {
            var isbn = PrintOutInput("\r\n=>Enter the magazine's ISBN number : ");
            var magazines = _libraryService.GetMagazinesByIsbnNumber(isbn);
            if (magazines.Any())
            {
                PrintOutMagazines(magazines, $"\r Search magazines results:\n");
            }
            else
            {
                Console.WriteLine("\r -- Items not found.");
            }
        }
        private static void FindBookOrMagazineByIsbnNumber()
        {
            var isbn = PrintOutInput("\r\n=>Enter the book's or magazine's ISBN number : ");
            var items = _libraryService.GetBooksOrMagazinesByIsbnNumber(isbn);
            if (items.Any())
            {
                PrintOutList(items.ToList(), $"\r Search results:\n");
            }
            else
            {
                Console.WriteLine("\r -- Items not found.");
            }
        }

        private static void FindBookByAuthor()
        {
            var author = PrintOutInput("\r\n=>Enter the book's author name : ");
            var books = _libraryService.GetBooksByAuthor(author);
            if (books.Any())
            {
                PrintOutBooks(books, $"\r Search book results:\n");
            }
            else
            {
                Console.WriteLine("\r -- Items not found.");
            }
        }
        private static void FindMagazineByAuthor()
        {
            var author = PrintOutInput("\r\n=>Enter the magazine's author name : ");
            var magazines = _libraryService.GetMagazinesByAuthor(author);
            if (magazines.Any())
            {
                PrintOutMagazines(magazines, $"\r Search magazines results:\n");
            }
            else
            {
                Console.WriteLine("\r -- Items not found.");
            }
        }
        private static void FindBookOrMagazineByAuthor()
        {
            var author = PrintOutInput("\r\n=>Enter the book's or magazine's author name : ");
            var items = _libraryService.GetBooksOrMagazinesByAuthor(author);
            if (items.Any())
            {
                PrintOutList(items.ToList(), $"\r Search results:\n");
            }
            else
            {
                Console.WriteLine("\r -- Items not found.");
            }
        }


        private static void PrintOutBooks(IList<Book> books, string title)
        {
            PrintOutList<Book>(books, title);
        }
        private static void PrintOutMagazines(IList<Magazine> magazines, string title)
        {
            PrintOutList<Magazine>(magazines, title);
        }
        private static void PrintOutList<TEntity>(IList<TEntity> items, string title)
        {
            Console.WriteLine(title);
            foreach (var item in items)
            {
                Console.WriteLine($"\r{items.IndexOf(item) + 1} - {item.ToString()}");
                Console.WriteLine($"______________________________________________________\n");
            }
        }
        private static string PrintOutInput(string title)
        {
            Console.WriteLine(title);
            return Console.ReadLine();
        }

    }
}
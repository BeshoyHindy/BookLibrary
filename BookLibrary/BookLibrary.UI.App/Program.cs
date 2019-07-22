using BookLibrary.Domain.Data.Repository;
using System;
using BookLibrary.Domain.Data.Models;

namespace BookLibrary.UI.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var test = new AuthorRepository();
            var list = test.GetAllAuthors();


            var testbooks = new BookRepository();
            var listBooks = testbooks.GetAllBooks();
            Console.ReadLine();

        }
    }
}

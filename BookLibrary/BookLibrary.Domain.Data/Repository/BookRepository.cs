using System.Collections.Generic;
using BookLibrary.Domain.Data.Infrastructure;
using BookLibrary.Domain.Data.Models;

namespace BookLibrary.Domain.Data.Repository
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository() : base("books.csv")
        {
        }

        public List<Book> GetAllBooks()
        {
            return this.GetAll(Book.FromCsv);
        }
    }
}
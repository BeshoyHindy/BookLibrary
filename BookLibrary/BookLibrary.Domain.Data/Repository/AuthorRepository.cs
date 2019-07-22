using System.Collections.Generic;
using BookLibrary.Domain.Data.Infrastructure;
using BookLibrary.Domain.Data.Models;

namespace BookLibrary.Domain.Data.Repository
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository() : base("authors.csv")
        {
        }


        public List<Author> GetAllAuthors()
        {
            return this.GetAll(Author.FromCsv);
        }
    }
}
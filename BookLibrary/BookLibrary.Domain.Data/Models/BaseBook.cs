using System.Collections.Generic;
using BookLibrary.Domain.Data.Infrastructure;

namespace BookLibrary.Domain.Data.Models
{
    public abstract class BaseBook : Entity
    {
        public string Title { get; protected set; }
        public string IsbnNumber { get; protected set; }
        public List<Author> Authors { get; protected set; }

    }
}
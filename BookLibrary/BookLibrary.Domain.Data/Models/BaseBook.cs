using System;
using System.Collections.Generic;
using System.Linq;
using BookLibrary.Domain.Data.Infrastructure;

namespace BookLibrary.Domain.Data.Models
{
    public abstract class BaseBook : Entity, IComparable<BaseBook>
    {

        public string Title { get; protected set; }
        public string IsbnNumber { get; protected set; }
        public List<Author> Authors { get; protected set; }

        //this for sorting by title instead of using order by in LINQ
        public int CompareTo(BaseBook other)
        {
            return string.Compare(Title, other.Title, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return $"{nameof(Title),10}: {Title,10}\n{"ISBN Number:",15} {IsbnNumber}\n{"Authors:",15} [{string.Join(",\n", Authors.Select(a => a.ToString()).ToArray())}]";
        }
    }
}
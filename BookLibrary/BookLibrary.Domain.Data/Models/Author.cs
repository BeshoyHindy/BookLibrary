using System;
using BookLibrary.Domain.Data.Infrastructure;

namespace BookLibrary.Domain.Data.Models
{
    public class Author : Entity
    {
        public Author(string email)
        {
            Id = email;
            Email = email;
        }
        public Author(string email, FullName fullName)
        {
            Id = email;
            Email = email;
            FullName = fullName;
        }

        public string Email { get; private set; }

        public FullName FullName { get; private set; }

        public static Author FromCsv(string csvLine)
        {
            var values = csvLine.Split(';');
            return new Author(values[0], new FullName(values[1], values[2]));
        }

        public override object FromCsvObject(string csvLine)
        {
            return FromCsv(csvLine);
        }
    }
}
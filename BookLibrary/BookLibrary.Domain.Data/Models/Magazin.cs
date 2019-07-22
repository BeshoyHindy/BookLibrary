using System;
using System.Collections.Generic;

namespace BookLibrary.Domain.Data.Models
{
    public class Magazine : BaseBook
    {
        public Magazine(string title, string isbnNumber, List<Author> authors, DateTime released)
        {
            Id = isbnNumber;
            Title = title;
            IsbnNumber = isbnNumber;
            Authors = authors;
            Released = released;
        }

        public DateTime Released { get; private set; }

        public static Magazine FromCsv(string csvLine)
        {
            var values = csvLine.Split(';');
            return new Magazine(values[0], values[1], new List<Author> { new Author(values[2]) }, DateTime.Parse(values[3]));
        }

        public override object FromCsvObject(string csvLine)
        {
            return FromCsv(csvLine);
        }
    }
}
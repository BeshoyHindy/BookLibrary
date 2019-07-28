using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Domain.Data.Models
{
    public class Book : BaseBook
    {
        public Book(string title, string isbnNumber, List<Author> authors, string summary)
        {
            Id = isbnNumber;
            Title = title;
            IsbnNumber = isbnNumber;
            Authors = authors;
            Summary = summary;
        }

        public string Summary { get; private set; }

        public static Book FromCsv(string csvLine)
        {
            var values = csvLine.Split(';');
            var authors = values[2].Split(',').Select(a => new Author(a)).ToList();
            return new Book(values[0], values[1], authors, values[3]);
        }

        public override object FromCsvObject(string csvLine)
        {
            return FromCsv(csvLine);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n {"Summary:",14} {Summary}";
        }


    }
}
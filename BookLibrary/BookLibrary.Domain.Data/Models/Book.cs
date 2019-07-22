using System.Collections.Generic;

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
            return new Book(values[0], values[1], new List<Author> { new Author(values[2]) }, values[3]);
        }

        public override object FromCsvObject(string csvLine)
        {
            return FromCsv(csvLine);
        }
    }
}
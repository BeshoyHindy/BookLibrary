using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
            var authors = values[2].Split(',').Select(a => new Author(a)).ToList();

            return new Magazine(values[0], values[1], authors, DateTime.ParseExact(values[3], "dd.MM.yyyy", CultureInfo.InvariantCulture));
        }

        public override object FromCsvObject(string csvLine)
        {
            return FromCsv(csvLine);
        }
        public override string ToString()
        {
            return $"{base.ToString()}\n{"Publish date :",15} {Released.ToString()}";
        }
    }
}
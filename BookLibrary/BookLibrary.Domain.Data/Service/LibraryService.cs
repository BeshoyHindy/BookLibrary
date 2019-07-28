using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BookLibrary.Domain.Data.Models;
using BookLibrary.Domain.Data.Repository;

namespace BookLibrary.Domain.Data.Service
{
    public class LibraryService
    {
        private readonly AuthorRepository _authorRepository;
        private readonly BookRepository _bookRepository;
        private readonly MagazineRepository _magazineRepository;

        private List<Author> _authorsList;
        private List<Book> _booksList;
        private List<Magazine> _magazinesList;


        public LibraryService()
        {
            _authorRepository = new AuthorRepository();
            _bookRepository = new BookRepository();
            _magazineRepository = new MagazineRepository();

            //fill all models from data
            _authorsList = _authorRepository.GetAllAuthors();
            _booksList = _bookRepository.GetAllBooks();
            _magazinesList = _magazineRepository.GetAllMagazines();

            //fill authors data from author data into author objects in books and magazines
            _booksList.ForEach(m => m.Authors.ForEach(a => a.FillAuthorName(_authorsList.FirstOrDefault(f => f.Email == a.Email)?.FullName)));
            _magazinesList.ForEach(m => m.Authors.ForEach(a => a.FillAuthorName(_authorsList.FirstOrDefault(f => f.Email == a.Email)?.FullName)));

        }


        public List<Author> GetAllAuthors()
        {
            return _authorsList;
        }

        public List<Book> GetAllBooks()
        {
            return _booksList;
        }

        public List<Magazine> GetAllMagazines()
        {
            return _magazinesList;
        }


        public List<Book> GetBooksByIsbnNumber(string isbn)
        {
            return _booksList.Where(b => b.IsbnNumber.Contains(isbn)).ToList();
        }
        public List<Magazine> GetMagazinesByIsbnNumber(string isbn)
        {
            return _magazinesList.Where(b => b.IsbnNumber.Contains(isbn)).ToList();
        }


        public IEnumerable<BaseBook> GetBooksOrMagazinesByIsbnNumber(string isbn)
        {
            foreach (var book in _booksList)
            {
                if (book.IsbnNumber.Contains(isbn))
                {
                    yield return (BaseBook)book;
                }
            }
            foreach (var magazine in _magazinesList)
            {
                if (magazine.IsbnNumber.Contains(isbn))
                {
                    yield return (BaseBook)magazine;
                }
            }
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return _booksList.Where(b => b.Authors.Any(a => a.FullName.ToString().ToLower().Contains(author))).ToList();
        }

        public List<Magazine> GetMagazinesByAuthor(string author)
        {
            return _magazinesList.Where(b => b.Authors.Any(a => a.FullName.ToString().ToLower().Contains(author))).ToList();
        }

        public IEnumerable<BaseBook> GetBooksOrMagazinesByAuthor(string author)
        {
            foreach (var book in _booksList)
            {
                if (book.Authors.Any(a => a.FullName.ToString().ToLower().Contains(author)))
                {
                    yield return (BaseBook)book;
                }
            }
            foreach (var magazine in _magazinesList)
            {
                if (magazine.Authors.Any(a => a.FullName.ToString().ToLower().Contains(author)))
                {
                    yield return (BaseBook)magazine;
                }
            }
        }


    }
}
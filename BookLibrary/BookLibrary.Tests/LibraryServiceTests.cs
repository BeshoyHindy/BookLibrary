using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookLibrary.Domain.Data.Models;
using BookLibrary.Domain.Data.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookLibrary.Tests
{
    [TestClass]
    public class LibraryServiceTests : BaseTest
    {
        private LibraryService _libraryService;

        [TestInitialize]
        public void BeforeEachTest()
        {
            LibraryServiceMock = new Mock<LibraryService>();

            //LibraryServiceMock.Setup(l => l.GetAllAuthors()).Returns(AuthorsList).Verifiable();
        }

        [TestMethod]
        public void TestGetAllAuthors()
        {
            // Arrange
            _libraryService = LibraryServiceMock.Object;

            // Act
            var result = _libraryService.GetAllAuthors();
            var count = result.Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void TestGetAllBooks()
        {
            // Arrange
            _libraryService = LibraryServiceMock.Object;

            // Act
            var result = _libraryService.GetAllBooks();
            var count = result.Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(8, count);
        }

        [TestMethod]
        public void TestGetAllMagazines()
        {
            // Arrange
            _libraryService = LibraryServiceMock.Object;

            // Act
            var result = _libraryService.GetAllMagazines();
            var count = result.Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void TestGetBooksByAuthor()
        {
            // Arrange
            _libraryService = LibraryServiceMock.Object;

            // Act
            var authorName = "paul walter";
            var result = _libraryService.GetBooksByAuthor(authorName);
            var count = result.Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void TestGetBooksByIsbnNumber()
        {
            // Arrange
            _libraryService = LibraryServiceMock.Object;

            // Act
            var isbnNumber = "55";
            var result = _libraryService.GetBooksByIsbnNumber(isbnNumber);
            var count = result.Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void TestGetBooksOrMagazinesByAuthor()
        {
            // Arrange
            _libraryService = LibraryServiceMock.Object;

            // Act
            var authorName = "paul walter";
            var result = _libraryService.GetBooksOrMagazinesByAuthor(authorName);
            var count = result.ToList().Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void TestGetBooksOrMagazinesByIsbnNumber()
        {
            // Arrange
            _libraryService = LibraryServiceMock.Object;

            // Act
            var isbnNumber = "55";
            var result = _libraryService.GetBooksOrMagazinesByIsbnNumber(isbnNumber);
            var count = result.ToList().Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void TestGetMagazinesByAuthor()
        {
            // Arrange
            _libraryService = LibraryServiceMock.Object;

            // Act
            var authorName = "paul walter";
            var result = _libraryService.GetMagazinesByAuthor(authorName);
            var count = result.ToList().Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void TestGetMagazinesByIsbnNumber()
        {
            // Arrange
            _libraryService = LibraryServiceMock.Object;

            // Act
            var isbnNumber = "55";
            var result = _libraryService.GetMagazinesByIsbnNumber(isbnNumber);
            var count = result.ToList().Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, count);
        }

    }

}
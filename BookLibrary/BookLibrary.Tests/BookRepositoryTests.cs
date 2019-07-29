using BookLibrary.Domain.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookLibrary.Tests
{
    [TestClass]
    public class BookRepositoryTests : BaseTest
    {
        private BookRepository _bookRepository;

        [TestInitialize]
        public void BeforeEachTest()
        {

        }

        [TestMethod]
        public void TestGetAllBooks()
        {
            // Arrange
            _bookRepository = new BookRepository();

            // Act
            var result = _bookRepository.GetAllBooks();
            var count = result.Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(8, count);
        }

    }
}
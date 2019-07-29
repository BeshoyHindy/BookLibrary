using BookLibrary.Domain.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookLibrary.Tests
{
    [TestClass]
    public class AuthorRepositoryTests : BaseTest
    {
        private AuthorRepository _authorRepository;

        [TestInitialize]
        public void BeforeEachTest()
        {

        }

        [TestMethod]
        public void TestGetAllAuthors()
        {
            // Arrange
            _authorRepository = new AuthorRepository();

            // Act
            var result = _authorRepository.GetAllAuthors();
            var count = result.Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, count);
        }

    }

}

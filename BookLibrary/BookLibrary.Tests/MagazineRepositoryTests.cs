using BookLibrary.Domain.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookLibrary.Tests
{
    [TestClass]
    public class MagazineRepositoryTests : BaseTest
    {
        private MagazineRepository _magazineRepository;

        [TestInitialize]
        public void BeforeEachTest()
        {
        }

        [TestMethod]
        public void TestGetAllMagazines()
        {
            // Arrange
            _magazineRepository = new MagazineRepository();

            // Act
            var result = _magazineRepository.GetAllMagazines();
            var count = result.Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, count);
        }

    }
}
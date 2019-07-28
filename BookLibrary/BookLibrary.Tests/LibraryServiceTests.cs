using System;
using System.Collections.Generic;
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
            //_pingAppService.Setup(appService => appService.SendPingMessageAsync(It.IsAny<PingViewModel>())).Returns(Task.CompletedTask).Verifiable();
            //_notifications = new Mock<DomainNotificationHandler>().Object;
            //_mediator = new Mock<IMediatorHandler>().Object;

            //_pingController = new PingController(_pingAppService.Object, _notifications, _mediator);
        }



        [TestMethod]
        public void TestGetAuthors()
        {
            LibraryServiceMock = new Mock<LibraryService>();

            LibraryServiceMock.Setup(l=> l.GetAllAuthors()).Returns(AuthorsList).Verifiable();

            // Arrange
            _libraryService = LibraryServiceMock.Object;

            // Act
            var result = _libraryService.GetAllAuthors();
            var count = result.Count;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, count);
        }
    }


}
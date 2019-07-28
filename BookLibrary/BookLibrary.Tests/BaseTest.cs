using System.Collections.Generic;
using BookLibrary.Domain.Data.Models;
using BookLibrary.Domain.Data.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookLibrary.Tests
{
    [TestClass]
    public class BaseTest
    {

        public static Mock<LibraryService> LibraryServiceMock;

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            LibraryServiceMock = new Mock<LibraryService>();
        }

        [ClassInitialize]
        public static void BeforeAllTests(TestContext context)
        {


        }

        public List<Author> AuthorsList()
        {
            return new List<Author>
            {
                new Author("mail1@test.com", new FullName("test1", "name")),
                new Author("mail2@test.com", new FullName("test2", "name")),
                new Author("mail3@test.com", new FullName("test3", "name"))
            };
        }

    }
}

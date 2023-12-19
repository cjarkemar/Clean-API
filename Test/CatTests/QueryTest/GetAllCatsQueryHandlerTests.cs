//using Moq;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Domain.Models;
//using Infrastructure.Database;
//using Application.Queries.Cats.GetAll;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using Application.Queries.Cats;

//namespace Test.CatTests.QueryTest
//{
//    [TestFixture]
//    public class GetAllCatsQueryHandlerTests
//    {
//        [Test]
//        public async Task Handle_ReturnsAllCats()
//        {
//            // Arrange
//            var catsData = new List<Cat>
//            {
//                new Cat { Name = "Oskar", LikesToPlay = true },
//                new Cat { Name = "Elliot", LikesToPlay = false }
//            };

//            var catsDbSetMock = new Mock<DbSet<Cat>>();
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.Provider).Returns(catsData.AsQueryable().Provider);
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.Expression).Returns(catsData.AsQueryable().Expression);
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.ElementType).Returns(catsData.AsQueryable().ElementType);
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.GetEnumerator()).Returns(catsData.AsQueryable().GetEnumerator());

//            var mockDatabase = new Mock<RealDatabase>();
//            mockDatabase.Setup(db => db.Cats).Returns(catsDbSetMock.Object);

//            var handler = new GetAllCatsQueryHandler(mockDatabase.Object);
//            var request = new GetAllCatsQuery(); // Assuming this is your query with no parameters

//            // Act
//            var result = await handler.Handle(request, CancellationToken.None);

//            // Assert
//            Assert.That(result.Count, Is.EqualTo(catsData.Count), "The number of cats returned should match the mock data.");
//            CollectionAssert.AreEquivalent(catsData, result, "The returned cats should match the mock data.");
//        }
//    }
//}

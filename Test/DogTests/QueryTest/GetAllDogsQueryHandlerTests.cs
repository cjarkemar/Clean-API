using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database;
using Application.Queries.Dogs.GetAll;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Application.Queries.Dogs;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsQueryHandlerTests
    {
        [Test]
        public async Task Handle_ReturnsAllCats()
        {
            // Arrange
            var dogsData = new List<Dog>
            {
                new Dog { Name = "Billy"},
                new Dog { Name = "Elliot"}
            };

            var dogsDbSetMock = new Mock<DbSet<Dog>>();
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.Provider).Returns(dogsData.AsQueryable().Provider);
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.Expression).Returns(dogsData.AsQueryable().Expression);
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.ElementType).Returns(dogsData.AsQueryable().ElementType);
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.GetEnumerator()).Returns(dogsData.AsQueryable().GetEnumerator());

            var mockDatabase = new Mock<RealDatabase>();
            mockDatabase.Setup(db => db.Dogs).Returns(dogsDbSetMock.Object);

            var handler = new GetAllDogsQueryHandler(mockDatabase.Object);
            var request = new GetAllDogsQuery(); // Assuming this is your query with no parameters

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(dogsData.Count), "The number of dogs returned should match the mock data.");
            CollectionAssert.AreEquivalent(dogsData, result, "The returned dogs should match the mock data.");
        }
    }
}

using NUnit.Framework;
using Infrastructure.Database;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Cats.GetAll;
using Application.Queries.Cats;

namespace Test.CatTests.QueryTest
{
    [TestFixture]
    public class GetAllCatsQueryHandlerTests
    {
        [Test]
        public async Task Handle_ReturnsAllCats()
        {
            // Arrange
            var mockDatabase = new MockDatabase();
            var cats = new List<Cat>
            {
                new Cat { Name = "Oskar", LikesToPlay = true },
                new Cat { Name = "Elliot", LikesToPlay = false },
            };

            mockDatabase.Cats = cats;

            var handler = new GetAllCatsQueryHandler(mockDatabase);
            var request = new GetAllCatsQuery(); // Assuming this is your query with no parameters

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(cats.Count), "The number of cats returned should match the mock data.");
            CollectionAssert.AreEquivalent(cats, result, "The returned cats should match the mock data.");
        }
    }
}

using NUnit.Framework;
using Infrastructure.Database;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs;


namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsQueryHandlerTests
    {
        [Test]
        public async Task Handle_ReturnsAllDogs()
        {
            // Arrange
            var mockDatabase = new MockDatabase();
            var dogs = new List<Dog>
            {
                new Dog { /* Initialize properties */ },
                new Dog { /* Initialize properties */ },
                // Add more dogs as needed
            };

            mockDatabase.Dogs = dogs;

            var handler = new GetAllDogsQueryHandler(mockDatabase);
            var request = new GetAllDogsQuery(); // Assuming this is your query with no parameters

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(dogs.Count), "The number of dogs returned should match the mock data.");
            CollectionAssert.AreEquivalent(dogs, result, "The returned dogs should match the mock data.");
        }
    }
}

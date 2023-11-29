using NUnit.Framework;
using Infrastructure.Database;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Cats;
using System;
using Application.Dtos;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatCommandHandlerTest
    {
        private AddCatCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new AddCatCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_AddsCatCorrectly()
        {
            // Arrange
            var newCatName = "Gustav";
            var catDto = new CatDto { Name = newCatName };
            var addCatCommand = new AddCatCommand(catDto);

            // Act
            var result = await _handler.Handle(addCatCommand, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "The returned cat should not be null.");
            Assert.AreEqual(newCatName, result.Name, "The name of the cat should match the requested name.");
            // Additional check to ensure the cat is added to the mock database
            var catInDatabase = _mockDatabase.Cats.Find(cat => cat.Id == result.Id);
            Assert.IsNotNull(catInDatabase, "The cat should be added to the mock database.");
            Assert.AreEqual(newCatName, catInDatabase.Name, "The cat in the database should have the correct name.");
        }
    }
}

using NUnit.Framework;
using Infrastructure.Database;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Dogs;
using System;
using Application.Dtos;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class AddDogCommandHandlerTest
    {
        private AddDogCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new AddDogCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_AddsDogCorrectly()
        {
            // Arrange
            var newDogName = "Buddy";
            var dogDto = new DogDto { Name = newDogName };
            var addDogCommand = new AddDogCommand(dogDto);

            // Act
            var result = await _handler.Handle(addDogCommand, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "The returned dog should not be null.");
            Assert.AreEqual(newDogName, result.Name, "The name of the dog should match the requested name.");
            // Additional check to ensure the dog is added to the mock database
            var dogInDatabase = _mockDatabase.Dogs.Find(d => d.Id == result.Id);
            Assert.IsNotNull(dogInDatabase, "The dog should be added to the mock database.");
            Assert.AreEqual(newDogName, dogInDatabase.Name, "The dog in the database should have the correct name.");
        }
    }
}
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database;
using Application.Dtos;
using Application.Commands.Birds;
using Domain.Models.Animal;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class UpdateBirdByIdCommandHandlerTest
    {
        private UpdateBirdByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_BirdExists_UpdatesBirdSuccessfully()
        {
            // Arrange
            var birdId = Guid.NewGuid();
            var originalBird = new Bird { Id = birdId, Name = "OldName", CanFly = false };
            _mockDatabase.Birds.Add(originalBird);

            var updatedName = "NewName";
            var updatedCanFly = true;
            var birdDto = new BirdDto { Name = updatedName, CanFly = updatedCanFly };
            var updateCommand = new UpdateBirdByIdCommand(birdDto, birdId);

            // Act
            var result = await _handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "Updated bird should not be null.");
            Assert.That(result.Id, Is.EqualTo(birdId), "Updated bird's ID should match the requested ID.");
            Assert.That(result.Name, Is.EqualTo(updatedName), "Updated birds name should reflect the new name.");
            Assert.That(result.CanFly, Is.EqualTo(updatedCanFly), "Updated birds CanFly should reflect the new value.");
        }

        [Test]
        public async Task Handle_BirdDoesNotExist_ReturnsNull()
        {
            // Arrange
            var nonExistentBirdId = Guid.NewGuid();
            var birdDto = new BirdDto { Name = "NewName" };
            var updateCommand = new UpdateBirdByIdCommand(birdDto, nonExistentBirdId);

            // Act
            var result = await _handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            Assert.IsNull(result, "Result should be null for a non-existent bird.");
        }
    }
}

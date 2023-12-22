using Application.Commands.Birds.DeleteBird;
using Domain.Models;
using Infrastructure.Repositories.Birds;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class DeleteBirdTests
    {
        [Test]
        public async Task Handle_Delete_Incorrect_Id()
        {
            // Arrange
            var bird = new Bird
            {
                Name = "Hans",
                AnimalId = Guid.NewGuid(),
                Color = "Red"
            };

            var birdRepositoryMock = new Mock<IBirdRepository>();
            birdRepositoryMock.Setup(repo => repo.DeleteBirdById(bird.AnimalId)).ReturnsAsync(bird);

            var handler = new DeleteBirdByIdCommandHandler(birdRepositoryMock.Object);
            var command = new DeleteBirdByIdCommand(bird.AnimalId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("Hans"));
            Assert.That(result.Color, Is.EqualTo("Red"));
            Assert.That(result, Is.TypeOf<Bird>());
            Assert.That(result.AnimalId, Is.EqualTo(bird.AnimalId));


        }
    }
}

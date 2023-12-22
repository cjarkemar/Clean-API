using Application.Commands.Birds.AddBird;
using Application.Dtos;
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
    public class AddBirdTests
    {
        [Test]
        public async Task Handle_Add_Bird_To_Database()
        {
            // Arrange
            var bird = new Bird { Name = "ElonMusk", Color = "Blue" };
            var requestGuid = Guid.NewGuid();

            var birdRepositoryMock = new Mock<IBirdRepository>();
            birdRepositoryMock.Setup(repo => repo.AddBird(bird, requestGuid)).ReturnsAsync(bird);

            var handler = new AddBirdCommandHandler(birdRepositoryMock.Object);

            var dto = new BirdDto
            {
                Name = "ElonMusk",
                Color = "Blue"
            };

            var command = new AddBirdCommand(dto, requestGuid);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("ElonMusk"));
            Assert.That(result.Color, Is.EqualTo("Blue"));
            Assert.That(result, Is.TypeOf<Bird>());
        }
    }
}

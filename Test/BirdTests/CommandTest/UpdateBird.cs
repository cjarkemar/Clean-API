using API.Controllers.BirdsController;
using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Application.Validators;
using Application.Validators.Bird;
using Domain.Models;
using Infrastructure.Repositories.Birds;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class UpdateBirdTests
    {


        [Test]
        public async Task Handle_Update_Correct_Bird_By_Id()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var bird = new Bird { AnimalId = guid, Color = "Green", Name = "Test", CanFly = true };
            var birdDto = new BirdDto { Name = "Frans", CanFly = true, Color = "Green" }; // Update color here

            var birdRepositoryMock = new Mock<IBirdRepository>();
            birdRepositoryMock.Setup(x => x.GetBirdById(guid)).ReturnsAsync(bird);
            birdRepositoryMock.Setup(x => x.UpdateBird(It.IsAny<Bird>())).ReturnsAsync(bird);

            var handler = new UpdateBirdByIdCommandHandler(birdRepositoryMock.Object);
            var command = new UpdateBirdByIdCommand(birdDto, guid);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("Frans"));
            Assert.IsTrue(result.CanFly);
            Assert.IsInstanceOf<Bird>(result);
        }
    }
}

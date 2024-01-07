using API.Controllers.BirdsController;
using Application.Commands.Birds.DeleteBird;
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
    public class DeleteBirdTests
    {
        [Test]
        public async Task Controller_Delete_Bird()
        {
            //Arrange
            var guid = Guid.NewGuid();
            var bird = new BirdDto { Name = "Gustav", CanFly = true, Color = "Black" };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<object>(), CancellationToken.None)).ReturnsAsync(bird);

            var guidValidator = new GuidValidator();
            var birdValidator = new BirdValidator();

            var birdController = new BirdsController(mediatorMock.Object, birdValidator, guidValidator);

            //Act
            var result = await birdController.DeleteBird(guid);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task Handle_Delete_Correct_Id()
        {
            //Arrange
            var bird = new Bird { Name = "McNugget", Color = "Yellow", AnimalId = Guid.NewGuid(), CanFly = true };

            var birdRepositoryMock = new Mock<IBirdRepository>();
            birdRepositoryMock.Setup(x => x.DeleteBirdById(It.IsAny<Guid>())).ReturnsAsync(bird);

            var handler = new DeleteBirdByIdCommandHandler(birdRepositoryMock.Object);
            var command = new DeleteBirdByIdCommand(bird.AnimalId);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("McNugget"));
            Assert.That(result, Is.TypeOf<Bird>());
            Assert.That(result.AnimalId.Equals(bird.AnimalId));
        }
    }
}

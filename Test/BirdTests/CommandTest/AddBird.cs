using API.Controllers.BirdsController;
using Application.Commands.Birds.AddBird;
using Application.Dtos;
using Application.Validators;
using Application.Validators.Bird;
using Domain.Models;
using Infrastructure.Repositories.Birds;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class AddBirdTests
    {
        [Test]
        public async Task Contoller_AddBird()
        {
            //Arrange
            var guid = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var bird = new BirdDto { Name = "Gustav", CanFly = true, Color = "Black" };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<object>(), CancellationToken.None)).ReturnsAsync(bird);

            var guidValidator = new GuidValidator();
            var birdValidator = new BirdValidator();

            var birdController = new BirdsController(mediatorMock.Object, birdValidator, guidValidator);

            //Act
            var result = await birdController.AddBird(bird, userId);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task Handler_AddBird()
        {
            //Arrange
            var guid = Guid.NewGuid();
            var bird = new Bird { AnimalId = guid, Name = "McNugget", Color = "Yellow" };
            var birdDto = new BirdDto { Name = bird.Name, Color = bird.Color, CanFly = true };

            var birdRepositoryMock = new Mock<IBirdRepository>();
            birdRepositoryMock.Setup(x => x.AddBird(It.IsAny<Bird>(), It.IsAny<Guid>())).ReturnsAsync(bird);

            var handler = new AddBirdCommandHandler(birdRepositoryMock.Object);
            var command = new AddBirdCommand(birdDto, guid);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<Bird>());
            Assert.That(result.Name.Equals("McNugget"));
        }
    }
}

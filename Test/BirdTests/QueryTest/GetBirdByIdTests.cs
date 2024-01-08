using API.Controllers.BirdsController;
using Application.Queries.Birds.GetById;
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

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetBirdByIdTests
    {
        private BirdsController _controller;
        private IMediator _mediator;
        private GuidValidator _guidValidator;
        private BirdValidator _birdValidator;

        [SetUp]
        public void SetUp()
        {
            _mediator = new Mock<IMediator>().Object;
            _guidValidator = new GuidValidator();
            _birdValidator = new BirdValidator();
            _controller = new BirdsController(_mediator, _birdValidator, _guidValidator);
        }



        [Test]
        public async Task Handle_ValidId_ReturnCorrectBird()
        {
            var guid = Guid.NewGuid();
            var bird = new Bird { Name = "McNugget", Color = "Yellow" };

            var birdRepositoryMock = new Mock<IBirdRepository>();
            birdRepositoryMock.Setup(x => x.GetBirdById(It.IsAny<Guid>())).ReturnsAsync(bird);

            var handler = new GetBirdByIdQueryHandler(birdRepositoryMock.Object);
            var command = new GetBirdByIdQuery(guid);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<Bird>());
            Assert.That(result.Name.Equals("McNugget"));
        }
    }
}

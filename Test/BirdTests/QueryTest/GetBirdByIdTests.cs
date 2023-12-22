﻿using API.Controllers.BirdsController;
using Application.Validators;
using Application.Validators.Bird;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetBirdByIdTests
    {
        private BirdsController _controller;
        private Mock<IMediator> _mediatorMock;
        private GuidValidator _guidValidator;
        private BirdValidator _birdValidator;

        [SetUp]
        public void SetUp()
        {
            _mediatorMock = new Mock<IMediator>();
            _guidValidator = new GuidValidator();
            _birdValidator = new BirdValidator();
            _controller = new BirdsController(_mediatorMock.Object, _birdValidator, _guidValidator);
        }

        [Test]
        public async Task Controller_Get_Bird_By_Id()
        {
            // Arrange
            var birdId = new Guid("33355658-1434-5628-9214-567814345603");

            // Act
            var result = await _controller.GetBirdById(birdId);

            // Assert
            Assert.NotNull(result);


        }
    }
}

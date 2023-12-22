using API.Controllers.BirdsController;
using Application.Dtos;
using Application.Validators;
using Application.Validators.Bird;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class UpdateBirdTests
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
        public async Task Controller_Update_Correct_Bird_By_Id()
        {
            // Arrange
            var birdId = new Guid("12345678-1234-5678-1234-567812345678");
            var birdName = "ElonMusk";
            var dto = new BirdDto { Name = birdName };

            // Act
            var result = await _controller.UpdateBird(dto, birdId);

            // Assert
            Assert.That(result, Is.Not.Null);


        }
    }
}

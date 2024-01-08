using API.Controllers.DogsController;
using Application.Validators;
using Application.Validators.Dog;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetDogByIdTests
    {
        private DogsController _controller;
        private Mock<IMediator> _mediatorMock;
        private GuidValidator _guidValidator;
        private DogValidator _dogValidator;

        [SetUp]
        public void SetUp()
        {
            _mediatorMock = new Mock<IMediator>();
            _guidValidator = new GuidValidator();
            _dogValidator = new DogValidator();
            _controller = new DogsController(_mediatorMock.Object, _dogValidator, _guidValidator);
        }

        [Test]
        public async Task Controller_Get_Dog_By_Id()
        {
            // Arrange
            var dogId = new Guid("523a0c2b-6b9b-4239-a691-495a6c5778c6");

            // Act
            var result = await _controller.GetDogById(dogId);

            // Assert
            Assert.That(result, Is.Not.Null);


        }
    }
}

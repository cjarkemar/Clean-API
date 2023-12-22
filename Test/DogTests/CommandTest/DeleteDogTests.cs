using API.Controllers.DogsController;
using Application.Validators;
using Application.Validators.Dog;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class DeleteDogTests
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
        public async Task Controller_Delete_Correct_Dog_By_Id()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345679");

            // Act
            var result = await _controller.DeleteDog(dogId);

            // Assert
            Assert.That(result, Is.Not.Null);


        }
    }
}


using Application.Dtos;
using Application.Validators;
using Application.Validators.Dog;
using Moq;
using MediatR;
using API.Controllers.DogsController;

namespace Test.DogTests.CommandTest.AddDogTests
{
    [TestFixture]
    public class UpdateDogTests
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
        public async Task Controller_Update_Correct_Dog_By_Id()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");
            var dogName = "Allan";
            var dto = new DogDto { Name = dogName };

            // Mock the behavior of IMediator for your specific scenario
            _mediatorMock
                .Setup(mediator => mediator.Send(It.IsAny<Application.Commands.Dogs.UpdateDog.UpdateDogByIdCommandHandler>(), default))
                .ReturnsAsync(new DogDto { Name = dogName }); // Replace with your expected result

            // Act
            var result = await _controller.UpdateDog(dto, dogId);

            // Assert
            Assert.That(result, Is.Not.Null);


        }
    }
}


using Application.Commands.Dogs;
using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class DeleteDogByIdCommandHandlerTest
    {
        private DeleteDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_DogExists_DeletesDogSuccessfully()
        {
            // Arrange
            var dogId = Guid.NewGuid();
            var dog = new Dog { Id = dogId, /* other properties */ };
            _mockDatabase.Dogs.Add(dog);

            var command = new DeleteDogByIdCommand(dogId); // Adjusted to use constructor

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "Deleted dog should not be null.");
            Assert.That(result.Id, Is.EqualTo(dogId), "Deleted dog's ID should match the requested ID.");
            Assert.IsFalse(_mockDatabase.Dogs.Contains(dog), "Dog should be removed from the database.");
        }


        [Test]
        public async Task Handle_DogDoesNotExist_ReturnsNull()
        {
            // Arrange
            var nonExistentDogId = Guid.NewGuid();
            var command = new DeleteDogByIdCommand(nonExistentDogId); 

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result, "Result should be null for a non-existent dog.");
        }

    }
}

      


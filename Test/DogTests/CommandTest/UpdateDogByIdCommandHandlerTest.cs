// UpdateDogByIdCommandHandlerTest
using System;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
    namespace Test.DogTests.CommandTest
    {
        [TestFixture]
        public class UpdateDogByIdCommandHandlerTest
        {
            private UpdateDogByIdCommandHandler _handler;
            private MockDatabase _mockDatabase;

            [SetUp]
            public void SetUp()
            {
                _mockDatabase = new MockDatabase();
                _handler = new UpdateDogByIdCommandHandler(_mockDatabase);
            }

            [Test]
            public async Task Handle_DogExists_UpdatesDogSuccessfully()
            {
                // Arrange
                var dogId = Guid.NewGuid();
                var originalDog = new Dog { Id = dogId, Name = "OldName"};
                _mockDatabase.Dogs.Add(originalDog);

                var updatedName = "NewName";
                var dogDto = new DogDto { Name = updatedName }; 
                var updateCommand = new UpdateDogByIdCommand(dogDto, dogId); 

                // Act
                var result = await _handler.Handle(updateCommand, CancellationToken.None);

                // Assert
                Assert.IsNotNull(result, "Updated dog should not be null.");
                Assert.That(result.Id, Is.EqualTo(dogId), "Updated dog's ID should match the requested ID.");
                Assert.That(result.Name, Is.EqualTo(updatedName), "Updated dog's name should reflect the new name.");
            }


            [Test]
            public async Task Handle_DogDoesNotExist_ReturnsNull()
            {
                // Arrange
                var nonExistentDogId = Guid.NewGuid();
                var dogDto = new DogDto { Name = "NewName" }; 
                var updateCommand = new UpdateDogByIdCommand(dogDto, nonExistentDogId); 

                // Act
                var result = await _handler.Handle(updateCommand, CancellationToken.None);

                // Assert
                Assert.IsNull(result, "Result should be null for a non-existent dog.");
            }

        }
    }

}
    

using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database;
using Application.Commands.Dogs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Application.Commands.Dogs.DeleteDog;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class DeleteDogByIdCommandHandlerTest
    {
        private DeleteDogByIdCommandHandler _handler;
        private Mock<RealDatabase> _mockDatabase;
        private List<Dog> _dogsData;

        [SetUp]
        public void SetUp()
        {
            _dogsData = new List<Dog>();

            var dogsDbSetMock = new Mock<DbSet<Dog>>();
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.Provider).Returns(_dogsData.AsQueryable().Provider);
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.Expression).Returns(_dogsData.AsQueryable().Expression);
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.ElementType).Returns(_dogsData.AsQueryable().ElementType);
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.GetEnumerator()).Returns(_dogsData.AsQueryable().GetEnumerator());

            // Setting up Remove to remove the Dog from the in-memory list
            dogsDbSetMock.Setup(m => m.Remove(It.IsAny<Dog>())).Callback<Dog>(dog => _dogsData.Remove(dog));

            _mockDatabase = new Mock<RealDatabase>();
            _mockDatabase.Setup(db => db.Dogs).Returns(dogsDbSetMock.Object);

            _handler = new DeleteDogByIdCommandHandler(_mockDatabase.Object);
        }

        [Test]
        public async Task Handle_DogExists_DeletesDogSuccessfully()
        {
            // Arrange
            var dogId = Guid.NewGuid();
            var dog = new Dog { Id = dogId};
            _dogsData.Add(dog);

            var command = new DeleteDogByIdCommand(dogId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "Deleted dog should not be null.");
            Assert.That(result.Id, Is.EqualTo(dogId), "Deleted dog's ID should match the requested ID.");
            Assert.IsFalse(_dogsData.Contains(dog), "Dog should be removed from the database.");
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

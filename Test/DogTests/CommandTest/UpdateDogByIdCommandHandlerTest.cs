using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database;
using Application.Dtos;
using Application.Commands.Dogs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Application.Commands.Dogs.UpdateDog;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class UpdateDogByIdCommandHandlerTest
    {
        private UpdateDogByIdCommandHandler _handler;
        private Mock<RealDatabase> _mockDatabase;
        private List<Dog> _dogsData;

        [SetUp]
        public void SetUp()
        {
            _dogsData = new List<Dog>
            {
                new Dog { Id = Guid.NewGuid(), Name = "OldName"}
                
            };

            var dogsDbSetMock = new Mock<DbSet<Dog>>();
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.Provider).Returns(_dogsData.AsQueryable().Provider);
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.Expression).Returns(_dogsData.AsQueryable().Expression);
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.ElementType).Returns(_dogsData.AsQueryable().ElementType);
            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.GetEnumerator()).Returns(_dogsData.AsQueryable().GetEnumerator());

            // Setup mock DbSet to find and return the relevant Dog
            dogsDbSetMock.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => _dogsData.FirstOrDefault(d => d.Id == (Guid)ids[0]));

            _mockDatabase = new Mock<RealDatabase>();
            _mockDatabase.Setup(db => db.Dogs).Returns(dogsDbSetMock.Object);

            _handler = new UpdateDogByIdCommandHandler(_mockDatabase.Object);
        }

        [Test]
        public async Task Handle_DogExists_UpdatesDogSuccessfully()
        {
            // Arrange
            var dogId = _dogsData.First().Id;
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

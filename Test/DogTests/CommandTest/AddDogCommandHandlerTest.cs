using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database;
using Application.Commands.Dogs;
using Application.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class AddDogCommandHandlerTest
    {
        private AddDogCommandHandler _handler;
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

            // Setting up AddAsync to add the Dog to the in-memory list
            dogsDbSetMock.Setup(m => m.Add(It.IsAny<Dog>())).Callback<Dog>(dog => _dogsData.Add(dog));

            _mockDatabase = new Mock<RealDatabase>();
            _mockDatabase.Setup(db => db.Dogs).Returns(dogsDbSetMock.Object);

            _handler = new AddDogCommandHandler(_mockDatabase.Object);
        }

        [Test]
        public async Task Handle_AddsDogCorrectly()
        {
            // Arrange
            var newDogName = "Gustav";
            var dogDto = new DogDto { Name = newDogName };
            var addDogCommand = new AddDogCommand(dogDto);

            // Act
            var result = await _handler.Handle(addDogCommand, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "The returned dog should not be null.");
            Assert.AreEqual(newDogName, result.Name, "The name of the dog should match the requested name.");
            Assert.IsTrue(_dogsData.Any(dog => dog.Name == newDogName), "The dog should be added to the mock database.");
        }
    }
}

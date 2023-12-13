using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database;
using Application.Commands.Cats;
using Application.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatCommandHandlerTest
    {
        private AddCatCommandHandler _handler;
        private Mock<RealDatabase> _mockDatabase;
        private List<Cat> _catsData;

        [SetUp]
        public void SetUp()
        {
            _catsData = new List<Cat>();

            var catsDbSetMock = new Mock<DbSet<Cat>>();
            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.Provider).Returns(_catsData.AsQueryable().Provider);
            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.Expression).Returns(_catsData.AsQueryable().Expression);
            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.ElementType).Returns(_catsData.AsQueryable().ElementType);
            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.GetEnumerator()).Returns(_catsData.AsQueryable().GetEnumerator());

            // Setting up AddAsync to add the Cat to the in-memory list
            catsDbSetMock.Setup(m => m.Add(It.IsAny<Cat>())).Callback<Cat>(cat => _catsData.Add(cat));

            _mockDatabase = new Mock<RealDatabase>();
            _mockDatabase.Setup(db => db.Cats).Returns(catsDbSetMock.Object);

            _handler = new AddCatCommandHandler(_mockDatabase.Object);
        }

        [Test]
        public async Task Handle_AddsCatCorrectly()
        {
            // Arrange
            var newCatName = "Gustav";
            var catDto = new CatDto { Name = newCatName };
            var addCatCommand = new AddCatCommand(catDto);

            // Act
            var result = await _handler.Handle(addCatCommand, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "The returned cat should not be null.");
            Assert.AreEqual(newCatName, result.Name, "The name of the cat should match the requested name.");
            Assert.IsTrue(_catsData.Any(cat => cat.Name == newCatName), "The cat should be added to the mock database.");
        }
    }
}

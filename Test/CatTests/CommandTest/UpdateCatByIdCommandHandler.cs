using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database;
using Application.Dtos;
using Application.Commands.Cats;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class UpdateCatByIdCommandHandlerTest
    {
        private UpdateCatByIdCommandHandler _handler;
        private Mock<RealDatabase> _mockDatabase;
        private List<Cat> _catsData;

        [SetUp]
        public void SetUp()
        {
            _catsData = new List<Cat>
            {
                new Cat { Id = Guid.NewGuid(), Name = "OldName", LikesToPlay = false }
                // Add other cats if needed
            };

            var catsDbSetMock = new Mock<DbSet<Cat>>();
            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.Provider).Returns(_catsData.AsQueryable().Provider);
            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.Expression).Returns(_catsData.AsQueryable().Expression);
            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.ElementType).Returns(_catsData.AsQueryable().ElementType);
            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.GetEnumerator()).Returns(_catsData.AsQueryable().GetEnumerator());

            // Setup mock DbSet to find and return the relevant Cat
            catsDbSetMock.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => _catsData.FirstOrDefault(d => d.Id == (Guid)ids[0]));

            _mockDatabase = new Mock<RealDatabase>();
            _mockDatabase.Setup(db => db.Cats).Returns(catsDbSetMock.Object);

            _handler = new UpdateCatByIdCommandHandler(_mockDatabase.Object);
        }

        [Test]
        public async Task Handle_CatExists_UpdatesCatSuccessfully()
        {
            // Arrange
            var catId = _catsData.First().Id;
            var updatedName = "NewName";
            var updatedLikesToPlay = true;
            var catDto = new CatDto { Name = updatedName, LikesToPlay = updatedLikesToPlay };
            var updateCommand = new UpdateCatByIdCommand(catDto, catId);

            // Act
            var result = await _handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "Updated cat should not be null.");
            Assert.That(result.Id, Is.EqualTo(catId), "Updated cat's ID should match the requested ID.");
            Assert.That(result.Name, Is.EqualTo(updatedName), "Updated cat's name should reflect the new name.");
            Assert.That(result.LikesToPlay, Is.EqualTo(updatedLikesToPlay), "Updated cat's LikesToPlay should reflect the new value.");
        }

        [Test]
        public async Task Handle_CatDoesNotExist_ReturnsNull()
        {
            // Arrange
            var nonExistentCatId = Guid.NewGuid();
            var catDto = new CatDto { Name = "NewName" };
            var updateCommand = new UpdateCatByIdCommand(catDto, nonExistentCatId);

            // Act
            var result = await _handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            Assert.IsNull(result, "Result should be null for a non-existent cat.");
        }
    }
}

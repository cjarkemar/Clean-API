using Application.Commands.Cats;
using Domain.Models;
using Infrastructure.Database;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class DeleteCatByIdCommandHandlerTest
    {
        private DeleteCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_CatExists_DeletesCatSuccessfully()
        {
            // Arrange
            var catId = Guid.NewGuid();
            var cat = new Cat { Id = catId, /* other properties */ };
            _mockDatabase.Cats.Add(cat);

            var command = new DeleteCatByIdCommand(catId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "Deleted cat should not be null.");
            Assert.That(result.Id, Is.EqualTo(catId), "Deleted cat's ID should match the requested ID.");
            Assert.IsFalse(_mockDatabase.Cats.Contains(cat), "Cat should be removed from the database.");
        }

        [Test]
        public async Task Handle_CatDoesNotExist_ReturnsNull()
        {
            // Arrange
            var nonExistentCatId = Guid.NewGuid();
            var command = new DeleteCatByIdCommand(nonExistentCatId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result, "Result should be null for a non-existent cat.");
        }
    }
}

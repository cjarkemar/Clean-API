using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database;
using Application.Dtos;
using Application.Commands.Cats;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class UpdateCatByIdCommandHandlerTest
    {
        private UpdateCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_CatExists_UpdatesCatSuccessfully()
        {
            // Arrange
            var catId = Guid.NewGuid();
            var originalCat = new Cat { Id = catId, Name = "OldName", LikesToPlay = false };
            _mockDatabase.Cats.Add(originalCat);

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

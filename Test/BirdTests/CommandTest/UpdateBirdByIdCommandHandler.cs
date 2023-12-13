using Moq;
using Infrastructure.Database;
using Application.Dtos;
using Application.Commands.Birds;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Animal;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class UpdateBirdByIdCommandHandlerTest
    {
        private UpdateBirdByIdCommandHandler _handler;
        private Mock<RealDatabase> _mockDatabase;
        private List<Bird> _birdsData;

        [SetUp]
        public void SetUp()
        {
            _birdsData = new List<Bird>
            {
                new Bird { Id = Guid.NewGuid(), Name = "OldName", CanFly = false },
                // Add more birds if needed
            };

            var birdsDbSetMock = new Mock<DbSet<Bird>>();
            birdsDbSetMock.As<IQueryable<Bird>>().Setup(m => m.Provider).Returns(_birdsData.AsQueryable().Provider);
            birdsDbSetMock.As<IQueryable<Bird>>().Setup(m => m.Expression).Returns(_birdsData.AsQueryable().Expression);
            birdsDbSetMock.As<IQueryable<Bird>>().Setup(m => m.ElementType).Returns(_birdsData.AsQueryable().ElementType);
            birdsDbSetMock.As<IQueryable<Bird>>().Setup(m => m.GetEnumerator()).Returns(_birdsData.AsQueryable().GetEnumerator());

            _mockDatabase = new Mock<RealDatabase>();
            _mockDatabase.Setup(db => db.Birds).Returns(birdsDbSetMock.Object);

            _handler = new UpdateBirdByIdCommandHandler(_mockDatabase.Object);
        }

        [Test]
        public async Task Handle_BirdExists_UpdatesBirdSuccessfully()
        {
            // Arrange
            var birdId = _birdsData.First().Id;
            var updatedName = "NewName";
            var updatedCanFly = true;
            var birdDto = new BirdDto { Name = updatedName, CanFly = updatedCanFly };
            var updateCommand = new UpdateBirdByIdCommand(birdDto, birdId);

            // Act
            var result = await _handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "Updated bird should not be null.");
            Assert.That(result.Id, Is.EqualTo(birdId), "Updated bird's ID should match the requested ID.");
            Assert.That(result.Name, Is.EqualTo(updatedName), "Updated bird's name should reflect the new name.");
            Assert.That(result.CanFly, Is.EqualTo(updatedCanFly), "Updated bird's CanFly status should reflect the new value.");
        }

        [Test]
        public async Task Handle_BirdDoesNotExist_ReturnsNull()
        {
            // Arrange
            var nonExistentBirdId = Guid.NewGuid();
            var birdDto = new BirdDto { Name = "NewName", CanFly = true };
            var updateCommand = new UpdateBirdByIdCommand(birdDto, nonExistentBirdId);

            // Act
            var result = await _handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            Assert.IsNull(result, "Result should be null for a non-existent bird.");
        }
    }
}

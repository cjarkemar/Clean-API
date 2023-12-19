using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database;
using Application.Queries.Birds.GetById;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Domain.Models.Animal;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetBirdByIdTests
    {
        private GetBirdByIdQueryHandler _handler;
        private Mock<RealDatabase> _mockDatabase;
        private List<Bird> _birdsData;

        [SetUp]
        public void SetUp()
        {
            _birdsData = new List<Bird>
            {
                new Bird { Id = new Guid("12345678-1234-5678-1234-567812345678") },
                
            };

            var birdsDbSetMock = new Mock<DbSet<Bird>>();
            birdsDbSetMock.As<IQueryable<Bird>>().Setup(m => m.Provider).Returns(_birdsData.AsQueryable().Provider);
            birdsDbSetMock.As<IQueryable<Bird>>().Setup(m => m.Expression).Returns(_birdsData.AsQueryable().Expression);
            birdsDbSetMock.As<IQueryable<Bird>>().Setup(m => m.ElementType).Returns(_birdsData.AsQueryable().ElementType);
            birdsDbSetMock.As<IQueryable<Bird>>().Setup(m => m.GetEnumerator()).Returns(_birdsData.AsQueryable().GetEnumerator());

            _mockDatabase = new Mock<RealDatabase>();
            _mockDatabase.Setup(db => db.Birds).Returns(birdsDbSetMock.Object);

            _handler = new GetBirdByIdQueryHandler(_mockDatabase.Object);
        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectBird()
        {
            // Arrange
            var birdId = new Guid("12345678-1234-5678-1234-567812345678");
            var query = new GetBirdByIdQuery(birdId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(birdId));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidBirdId = Guid.NewGuid();
            var query = new GetBirdByIdQuery(invalidBirdId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}

//using Moq;
//using NUnit.Framework;
//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Domain.Models;
//using Infrastructure.Database;
//using Application.Queries.Cats.GetById;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Collections.Generic;

//namespace Test.CatTests.QueryTest
//{
//    [TestFixture]
//    public class GetCatByIdTests
//    {
//        private GetCatByIdQueryHandler _handler;
//        private Mock<RealDatabase> _mockDatabase;
//        private List<Cat> _catsData;

//        [SetUp]
//        public void SetUp()
//        {
//            _catsData = new List<Cat>
//            {
//                new Cat { Id = new Guid("12345678-1234-5678-1234-567812345678") },
                
//            };

//            var catsDbSetMock = new Mock<DbSet<Cat>>();
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.Provider).Returns(_catsData.AsQueryable().Provider);
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.Expression).Returns(_catsData.AsQueryable().Expression);
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.ElementType).Returns(_catsData.AsQueryable().ElementType);
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.GetEnumerator()).Returns(_catsData.AsQueryable().GetEnumerator());

//            // Setup mock DbSet to find and return the relevant Cat
//            catsDbSetMock.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => _catsData.FirstOrDefault(d => d.Id == (Guid)ids[0]));

//            _mockDatabase = new Mock<RealDatabase>();
//            _mockDatabase.Setup(db => db.Cats).Returns(catsDbSetMock.Object);

//            _handler = new GetCatByIdQueryHandler(_mockDatabase.Object);
//        }

//        [Test]
//        public async Task Handle_ValidId_ReturnsCorrectCat()
//        {
//            // Arrange
//            var catId = new Guid("12345678-1234-5678-1234-567812345678");
//            var query = new GetCatByIdQuery(catId);

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.That(result.Id, Is.EqualTo(catId));
//        }

//        [Test]
//        public async Task Handle_InvalidId_ReturnsNull()
//        {
//            // Arrange
//            var invalidCatId = Guid.NewGuid();
//            var query = new GetCatByIdQuery(invalidCatId);

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.IsNull(result);
//        }
//    }
//}

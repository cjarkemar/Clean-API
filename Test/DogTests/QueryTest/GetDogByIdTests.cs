//using Moq;
//using NUnit.Framework;
//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Domain.Models;
//using Infrastructure.Database.RealDatabase;
//using Application.Queries.Dogs.GetById;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Collections.Generic;

//namespace Test.DogTests.QueryTest
//{
//    [TestFixture]
//    public class GetDogsByIdTests
//    {
//        private GetDogByIdQueryHandler _handler;
//        private Mock<RealDatabase> _mockDatabase;
//        private List<Dog> _dogsData;

//        [SetUp]
//        public void SetUp()
//        {
//            _dogsData = new List<Dog>
//            {
//                new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678") },
//                // Add other dogs if needed
//            };

//            var dogsDbSetMock = new Mock<DbSet<Dog>>();
//            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.Provider).Returns(_dogsData.AsQueryable().Provider);
//            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.Expression).Returns(_dogsData.AsQueryable().Expression);
//            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.ElementType).Returns(_dogsData.AsQueryable().ElementType);
//            dogsDbSetMock.As<IQueryable<Dog>>().Setup(m => m.GetEnumerator()).Returns(_dogsData.AsQueryable().GetEnumerator());

//            // Setup mock DbSet to find and return the relevant Dog
//            dogsDbSetMock.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => _dogsData.FirstOrDefault(d => d.Id == (Guid)ids[0]));

//            _mockDatabase = new Mock<RealDatabase>();
//            _mockDatabase.Setup(db => db.Dogs).Returns(dogsDbSetMock.Object);

//            _handler = new GetDogByIdQueryHandler(_mockDatabase.Object);
//        }

//        [Test]
//        public async Task Handle_ValidId_ReturnsCorrectDog()
//        {
//            // Arrange
//            var dogId = new Guid("12345678-1234-5678-1234-567812345678");
//            var query = new GetDogByIdQuery(dogId);

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.That(result.Id, Is.EqualTo(dogId));
//        }

//        [Test]
//        public async Task Handle_InvalidId_ReturnsNull()
//        {
//            // Arrange
//            var invalidDogId = Guid.NewGuid();
//            var query = new GetDogByIdQuery(invalidDogId);

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.IsNull(result);
//        }
//    }
//}

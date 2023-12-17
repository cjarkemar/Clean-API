//using Moq;
//using NUnit.Framework;
//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Domain.Models;
//using Infrastructure.Database.RealDatabase;
//using Application.Commands.Cats;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;

//namespace Test.CatTests.CommandTest
//{
//    [TestFixture]
//    public class DeleteCatByIdCommandHandlerTest
//    {
//        private DeleteCatByIdCommandHandler _handler;
//        private Mock<RealDatabase> _mockDatabase;
//        private List<Cat> _catsData;

//        [SetUp]
//        public void SetUp()
//        {
//            _catsData = new List<Cat>();

//            var catsDbSetMock = new Mock<DbSet<Cat>>();
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.Provider).Returns(_catsData.AsQueryable().Provider);
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.Expression).Returns(_catsData.AsQueryable().Expression);
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.ElementType).Returns(_catsData.AsQueryable().ElementType);
//            catsDbSetMock.As<IQueryable<Cat>>().Setup(m => m.GetEnumerator()).Returns(_catsData.AsQueryable().GetEnumerator());

//            // Setting up Remove to remove the Cat from the in-memory list
//            catsDbSetMock.Setup(m => m.Remove(It.IsAny<Cat>())).Callback<Cat>(cat => _catsData.Remove(cat));

//            _mockDatabase = new Mock<RealDatabase>();
//            _mockDatabase.Setup(db => db.Cats).Returns(catsDbSetMock.Object);

//            _handler = new DeleteCatByIdCommandHandler(_mockDatabase.Object);
//        }

//        [Test]
//        public async Task Handle_CatExists_DeletesCatSuccessfully()
//        {
//            // Arrange
//            var catId = Guid.NewGuid();
//            var cat = new Cat { Id = catId};
//            _catsData.Add(cat);

//            var command = new DeleteCatByIdCommand(catId);

//            // Act
//            var result = await _handler.Handle(command, CancellationToken.None);

//            // Assert
//            Assert.IsNotNull(result, "Deleted cat should not be null.");
//            Assert.That(result.Id, Is.EqualTo(catId), "Deleted cat's ID should match the requested ID.");
//            Assert.IsFalse(_catsData.Contains(cat), "Cat should be removed from the database.");
//        }

//        [Test]
//        public async Task Handle_CatDoesNotExist_ReturnsNull()
//        {
//            // Arrange
//            var nonExistentCatId = Guid.NewGuid();
//            var command = new DeleteCatByIdCommand(nonExistentCatId);

//            // Act
//            var result = await _handler.Handle(command, CancellationToken.None);

//            // Assert
//            Assert.IsNull(result, "Result should be null for a non-existent cat.");
//        }
//    }
//}

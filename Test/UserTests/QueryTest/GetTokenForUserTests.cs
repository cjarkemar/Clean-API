//using Application.Queries.UsersGetToken;
//using Infrastructure.Authentication;
//using Infrastructure.Database;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Test.UserTests.QueryTest
//{
//    [TestFixture]
//    public class GetTokenForUser
//    {
//        private GetUserTokenQueryHandler _handler;
//        private Mock<IMockDatabase> _mockDatabaseMock;
//        private JwtTokenGenerator _jwtGenerator;

//        [SetUp]
//        public void SetUp()
//        {
//            _mockDatabaseMock = new Mock<IMockDatabase>();
//            _jwtGenerator = new JwtTokenGenerator();
//            _handler = new GetUserTokenQueryHandler(_mockDatabaseMock.Object, _jwtGenerator);
//        }

//        [Test]
//        public async Task Handle_Generate_Token_For_Valid_User()
//        {
//            // Arrange
//            var username = "CarlJohan";
//            var password = "123Lösen";
//            var query = new GetUserTokenQuery(username, password);

//            // Mocking the expected behavior of the database
//            _mockDatabaseMock.Setup(db => db.ValidateUser(username, password))
//                             .Returns(true); // Assuming ValidateUser returns a boolean

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.IsNotNull(result);
//        }

//        [Test]
//        public async Task Handle_Invalid_User()
//        {
//            // Arrange
//            var username = "NotOKCarlJohan";
//            var password = "NotOK123Lösen";
//            var query = new GetUserTokenQuery(username, password);

//            // Mocking the expected behavior of the database
//            _mockDatabaseMock.Setup(db => db.ValidateUser(username, password))
//                             .Returns(false); // Assuming ValidateUser returns a boolean

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.IsNull(result);
//        }
//    }
//}

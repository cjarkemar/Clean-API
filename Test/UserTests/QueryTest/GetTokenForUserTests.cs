
//using Application.Queries.UsersGetToken;
//using Moq;
//using Infrastructure.Authentication;
//using Microsoft.EntityFrameworkCore.Storage;
//using Infrastructure.Database.RealDatabase;

//namespace Test.UserTests.QueryTest
//{
//    [TestFixture]
//    public class GetTokenForUserTests
//    {
//        private GetUserTokenQueryHandler _handler;
//        private Mock<RealDatabase> _mockDatabase;
//        private JwtTokenGenerator _jwtGenerator;
//        [SetUp]
//        public void SetUp()
//        {
//            _mockDatabase = new Mock<RealDatabase>();
//            _jwtGenerator = new JwtTokenGenerator();
//            _handler = new GetUserTokenQueryHandler(_mockDatabase.Object, (Infrastructure.Repositories.Users.IUserRepository)_jwtGenerator);
//        }

//        [Test]
//        public async Task Handle_Generate_Token_For_Valid_User()
//        {
//            // Arrange
//            var username = "AnvädareFårToken";
//            var password = "lösen321";
//            _mockDatabase.Setup(x => x.IsValidUser(username, password)).Returns(true);

//            var query = new GetUserTokenQuery(username, password);

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.IsNotNull(result);
//        }

//        [Test]
//        public async Task Handle_Invalid_User()
//        {
//            // Arrange
//            var username = "CJ";
//            var password = "lösen321";
//            _mockDatabase.Setup(x => x.IsValidUser(username, password)).Returns(false);

//            var query = new GetUserTokenQuery(username, password);

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.IsNull(result);
//        }
//    }
//}

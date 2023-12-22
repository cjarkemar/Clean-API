//using API.Controllers.UsersController;
//using Application.Commands.Users.Register;
//using Application.Dtos;
//using Application.Validators;
//using Application.Validators.Users;
//using Domain.Models;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Moq;

//public class UsersControllerTests
//{
//    private Mock<IMediator> _mediatorMock;
//    private Mock<UserValidator> _userValidatorMock;
//    private Mock<GuidValidator> _guidValidatorMock;
//    private UsersController _controller;

//    [SetUp]
//    public void SetUp()
//    {
//        _mediatorMock = new Mock<IMediator>();
//        _userValidatorMock = new Mock<UserValidator>();
//        _guidValidatorMock = new Mock<GuidValidator>();
//        _controller = new UsersController(_mediatorMock.Object, _userValidatorMock.Object, _guidValidatorMock.Object);
//    }

//    [Test]
//    public async Task RegisterUser_ShouldReturnOkResultForValidUser()
//    {
//        var username = "newUser";
//        var password = "newPassword";
//        _mediatorMock.Setup(m => m.Send(It.IsAny<AddUserCommand>(), default)).ReturnsAsync(new User());
//        _userValidatorMock.Setup(v => v.Validate(It.IsAny<UserDto>())).Returns(new ValidationResult());

//        var result = await _controller.RegisterUser(username, password) as OkObjectResult;

//        Assert.IsNotNull(result);
//        Assert.AreEqual(200, result.StatusCode);
//    }

//}
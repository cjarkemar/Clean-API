// UsersController
using System;
using Application.Commands.Users;
//using Application.Commands.Users.DeleteUser;
//using Application.Commands.Users.UpdateUser;
//using Application.Dtos;
using Application.Queries.Users.GetAll;
//  using Application.Queries.Users.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all users from database
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
            //return Ok("GET ALL USERS");
        }

        //Get a user by Id
        //[HttpGet]
        //[Route("getUserById/{userId}")]
        //public async Task<IActionResult> GetUserById(Guid userId)
        //{
        //    var result = await _mediator.Send(new GetUserByIdQuery(userId));
        //    if (result == null)
        //    {
        //        return NotFound("Den användaren finns inte med i listan");
        //    }
        //    return Ok(result);
        //}

        //// Create a new dog 
        //[HttpPost]
        //[Route("addNewUser")]
        //public async Task<IActionResult> AddUser([FromBody] UserDto newUser)
        //{
        //    return Ok(await _mediator.Send(new AddUserCommand(newUser)));
        //}

        //// Update a specific user
        //[HttpPut]
        //[Route("updateUser/{updatedUserId}")]
        //public async Task<IActionResult> UpdateUser([FromBody] UserDto updatedUser, Guid updatedUserId)
        //{
        //    var updateResult = await _mediator.Send(new UpdateUserByIdCommand(updatedUser, updatedUserId));
        //    if (updateResult == null)
        //    {
        //        return NotFound("Den hunden finns inte med i listan");
        //    }
        //    return Ok(updateResult);
        //}

        //[HttpDelete]
        //[Route("deleteUser/{deleteUserId}")]
        //public async Task<IActionResult> DeleteUser(Guid deleteUserId)
        //{
        //    var result = await _mediator.Send(new DeleteUserByIdCommand(deleteUserId));
        //    if (result == null)
        //    {
        //        return NotFound("Den användaren finns inte med i listan");
        //    }
        //    return Ok(result);
        //}



    }
}



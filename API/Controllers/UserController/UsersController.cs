// UsersController
using System;
using Application.Commands.Users;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Validators.User;
using Application.Queries.Users;

namespace API.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly UserValidator _userValidator;

        public UsersController(IMediator mediator, UserValidator userValidator)
        {
            _mediator = mediator;
            _userValidator = userValidator;
        }

        // GET: api/<UsersController>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            var token = await _mediator.Send(new GetTokenForUserQuery(username, password));

            if (token == null)
            {
                return NotFound("User not found");
            }

            return Ok(token);

        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto newUser)
        {
            var userValidator = _userValidator.Validate(newUser);

            if (!userValidator.IsValid)
            {
                return BadRequest(userValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new AddUserCommand(newUser)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }

}

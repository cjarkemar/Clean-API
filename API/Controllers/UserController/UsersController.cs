using Application.Commands.Users.AddUser;
using Application.Commands.Users.DeleteUser;
using Application.Commands.Users.DeleteUsers;
using Application.Commands.Users.UpdateUser;
using Application.Commands.Users.UpdateUsers;
using Application.Dtos;
using Application.Queries.Users.GetToken;
using Application.Validators;
using Application.Validators.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly UserValidator _userValidator;
        internal readonly GuidValidator _guidValidator;

        public UsersController(IMediator mediator, UserValidator userValidator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _userValidator = userValidator;
            _guidValidator = guidValidator;
        }

        // GET: api/<UsersController>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            var token = await _mediator.Send(new GetUserTokenQuery(username, password));

            if (token == null)
            {
                return NotFound("User not found");
            }

            return Ok(token);

        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser(string username, string password)
        {
            //var userValidator = _userValidator.Validate(username);
            /*
            if (!userValidator.IsValid)
            {
                return BadRequest(userValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            */
            try
            {
                return Ok(await _mediator.Send(new AddUserCommand(username, password)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        [Route("deleteUser/{deleteUserId}")]
        public async Task<IActionResult> DeleteUser(Guid deleteUserId)
        {
            var guidValidator = _guidValidator.Validate(deleteUserId);

            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                await _mediator.Send(new DeleteUserByIdCommand(deleteUserId));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return NoContent();
        }
        [HttpPut]
        [Route("updateUser/{updateUserId}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userToUpdate, Guid updateUserId)
        {
            var userValidator = _userValidator.Validate(userToUpdate);

            var guidValidator = _guidValidator.Validate(updateUserId);
            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            if (!userValidator.IsValid)
            {
                return BadRequest(userValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                var user = await _mediator.Send(new UpdateUserByIdCommand(userToUpdate, updateUserId));

                if (user == null)
                {
                    return NotFound($"User with Id {updateUserId} does not exist in database");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
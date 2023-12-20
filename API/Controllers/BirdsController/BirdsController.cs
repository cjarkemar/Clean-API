using Application.Commands.Birds.AddBird;
using Application.Commands.Birds.DeleteBird;
using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Application.Queries.Birds.GetAll;
using Application.Queries.Birds.GetById;
using Application.Validators;
using Application.Validators.Bird;
using Application.Validators.Birds;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.BirdsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly BirdValidator _birdValidator;
        internal readonly GuidValidator _guidValidator;

        public BirdsController(IMediator mediator, BirdValidator birdValidator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _birdValidator = birdValidator;
            _guidValidator = guidValidator;
        }

        // GET: api/<BirdsController>
        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            return Ok(await _mediator.Send(new GetAllBirdsQuery()));
        }

        [HttpGet]
        [Route("getBirdById/{birdId}")]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            var guidValidator = _guidValidator.Validate(birdId);

            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            var bird = await _mediator.Send(new GetBirdByIdQuery(birdId));

            if (bird == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(bird);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("addNewBird")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird, Guid userId)
        {
            var birdValidator = _birdValidator.Validate(newBird);

            if (!birdValidator.IsValid)
            {
                return BadRequest(birdValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new AddBirdCommand(newBird, userId)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //[Authorize]
        [HttpPut]
        [Route("updateBird/{updateBirdId}")]
        public async Task<IActionResult> UpdateBirdById([FromBody] BirdDto birdToUpdate, Guid updateBirdId)
        {
            var guidValidator = _guidValidator.Validate(updateBirdId);

            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            var birdValidator = _birdValidator.Validate(birdToUpdate);

            if (!birdValidator.IsValid)
            {
                return BadRequest(birdValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            var bird = await _mediator.Send(new UpdateBirdByIdCommand(birdToUpdate, updateBirdId));

            if (bird == null)
            {
                return NotFound($"Bird with Id: {updateBirdId} does not exist in database");
            }

            try
            {
                return Ok(bird);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //[Authorize]
        [HttpDelete]
        [Route("deleteBird/{deleteBirdId}")]
        public async Task<IActionResult> DeleteBird(Guid deleteBirdId)
        {
            var guidValidator = _guidValidator.Validate(deleteBirdId);

            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                await _mediator.Send(new DeleteBirdByIdCommand(deleteBirdId));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return NoContent();
        }
    }
}
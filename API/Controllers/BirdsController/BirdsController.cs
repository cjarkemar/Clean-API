using Application.Commands.Birds;
using Application.Dtos;
using Application.Queries.Birds.GetAll;
using Application.Queries.Birds.GetById;
using Application.Validators;
using Application.Validators.Cats;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BirdsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly CatValidator _catValidator;
        internal readonly GuidValidator _guidValidator;
        public BirdsController(IMediator mediator, CatValidator catValidator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _catValidator = catValidator;
            _guidValidator = guidValidator;
        }

        // Get all birds from database
        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            return Ok(await _mediator.Send(new GetAllBirdsQuery()));
        }

        // Get one Bird by Id
        [HttpGet]
        [Route("getBirdById/{birdId}")]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            var result = await _mediator.Send(new GetBirdByIdQuery(birdId));
            if (result == null)
            {
                return NotFound("Fågeln finns inte med i listan");
            }
            return Ok(result);
        }

        // Create a new Bird
        [HttpPost]
        [Route("addNewBird")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            return Ok(await _mediator.Send(new AddBirdCommand(newBird)));
        }

        // Update a specific Bird
        [HttpPut]
        [Route("updateBird/{updatedBirdId}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            var updateResult = await _mediator.Send(new UpdateBirdByIdCommand(updatedBird, updatedBirdId));
            if (updateResult == null)
            {
                return NotFound("Fågeln finns inte med i listan");
            }
            return Ok(updateResult);
        }

        // Delete a specific Bird
        [HttpDelete]
        [Route("deleteBird/{deleteBirdId}")]
        public async Task<IActionResult> DeleteBird(Guid deleteBirdId)
        {
            var result = await _mediator.Send(new DeleteBirdByIdCommand(deleteBirdId));
            if (result == null)
            {
                return NotFound("Fågeln finns inte med i listan");
            }
            return Ok(result);
        }
    }
}

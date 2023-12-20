using Application.Queries.Animals.GetAll;
using Application.Queries.Animals.GetAllAnimalsForUser;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AnimalsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly GuidValidator _guidValidator;

        public AnimalsController(IMediator mediator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _guidValidator = guidValidator;
        }

        [HttpGet]
        [Route("getAllAnimals")]
        public async Task<IActionResult> GetAllAnimals()
        {
            return Ok(await _mediator.Send(new GetAllAnimalsQuery()));
        }

        [HttpGet]
        [Route("getAllAnimalsById/{userId}")]
        public async Task<IActionResult> GetAnimalsById(Guid userId)
        {
            var animals = await _mediator.Send(new GetAllAnimalsByIdQuery(userId));

            return Ok(animals);
        }
    }
}
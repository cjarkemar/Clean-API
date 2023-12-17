using Application.Commands.Cats;
using Application.Dtos;
using Application.Queries.Cats.GetAll;
using Application.Queries.Cats.GetById;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Validators.Cats;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CatsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly CatValidator _catValidator;
        internal readonly GuidValidator _guidValidator;
        public CatsController(IMediator mediator, CatValidator catValidator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _catValidator = catValidator;
            _guidValidator = guidValidator;
        }

        // Get all cats from database
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            return Ok(await _mediator.Send(new GetAllCatsQuery()));
        }

        // Get a cat by Id
        [HttpGet]
        [Route("getCatById/{catId}")]
        public async Task<IActionResult> GetCatById(Guid catId)
        {
            var result = await _mediator.Send(new GetCatByIdQuery(catId));
            if (result == null)
            {
                return NotFound("Katten finns inte med i listan");
            }
            return Ok(result);
        }

        // Create a new cat
        [HttpPost]
        [Route("addNewCat")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            return Ok(await _mediator.Send(new AddCatCommand(newCat)));
        }

        // Update a specific cat
        [HttpPut]
        [Route("updateCat/{updatedCatId}")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            var updateResult = await _mediator.Send(new UpdateCatByIdCommand(updatedCat, updatedCatId));
            if (updateResult == null)
            {
                return NotFound("Katten finns inte med i listan");
            }
            return Ok(updateResult);
        }

        // Delete a specific cat
        [HttpDelete]
        [Route("deleteCat/{deleteCatId}")]
        public async Task<IActionResult> DeleteCat(Guid deleteCatId)
        {
            var result = await _mediator.Send(new DeleteCatByIdCommand(deleteCatId));
            if (result == null)
            {
                return NotFound("Katten finns inte med i listan");
            }
            return Ok(result);
        }
    }
}

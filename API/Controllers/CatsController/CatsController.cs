using Application.Commands.Cats;
using Application.Commands.Cats.AddCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Application.Queries.Cats.GetAll;
using Application.Queries.Cats.GetById;
using Application.Validators;
using Application.Validators.Cat;
using Application.Validators.Cats;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CatsController
{
    [Route("/[controller]")]
    [ApiController]
    public class CatsController : Controller
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
            var guidValidator = _guidValidator.Validate(catId);

            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            var cat = await _mediator.Send(new GetCatByIdQuery(catId));

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

        //[Authorize]
        [HttpPost]
        [Route("addNewCat")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat, Guid userId)
        {
            var catValidate = _catValidator.Validate(newCat);

            if (!catValidate.IsValid)
            {
                return BadRequest(catValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            return Ok(await _mediator.Send(new AddCatCommand(newCat, userId)));
        }

        [Authorize]
        [HttpPut]
        [Route("updateCat/{updateCatId}")]
        public async Task<IActionResult> UpdateCatById([FromBody] CatDto catToUpdate, Guid updateCatId)
        {
            var guidValidator = _guidValidator.Validate(updateCatId);

            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            var catValidate = _catValidator.Validate(catToUpdate);

            if (!catValidate.IsValid)
            {
                return BadRequest(catValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            var cat = await _mediator.Send(new UpdateCatByIdCommand(catToUpdate, updateCatId));

            if (cat == null)
            {
                return NotFound($"Cat with Id:{updateCatId} does not exist in database");
            }

            return Ok(cat);

        }

        [Authorize]
        [HttpDelete]
        [Route("deleteCat/{deleteCatId}")]
        public async Task<IActionResult> DeleteCat(Guid deleteCatId)
        {
            var guidValidator = _guidValidator.Validate(deleteCatId);

            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            await _mediator.Send(new DeleteCatByIdCommand(deleteCatId));

            return NoContent();
        }
    }
}
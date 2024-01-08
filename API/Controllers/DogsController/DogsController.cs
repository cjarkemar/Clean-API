using Application.Commands.Dogs;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using Application.Queries.Dogs.GetWeightAndBreed;
using Application.Validators;
using Application.Validators.Dog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly DogValidator _dogValidator;
        internal readonly GuidValidator _guidValidator;
        public DogsController(IMediator mediator, DogValidator dogValidator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _dogValidator = dogValidator;
            _guidValidator = guidValidator;
        }

        // Get all dogs from database
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllDogsQuery()));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // Get a dog by Id
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            var guidValidator = _guidValidator.Validate(dogId);

            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            var dog = await _mediator.Send(new GetDogByIdQuery(dogId));

            if (dog == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(dog);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Create a new dog 
        //[Authorize]
        [HttpPost]
        [Route("addNewDog")]
        [ProducesResponseType(typeof(DogDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog, Guid userId)
        {
            var dogValidator = _dogValidator.Validate(newDog);

            if (!dogValidator.IsValid)
            {
                return BadRequest(dogValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new AddDogCommand(newDog, userId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update a specific dog
        //[Authorize]
        [HttpPut]
        [Route("updateDog/{updateDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto dogToUpdate, Guid updateDogId)
        {
            var dogValidator = _dogValidator.Validate(dogToUpdate);

            var guidValidator = _guidValidator.Validate(updateDogId);

            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            if (!dogValidator.IsValid)
            {
                return BadRequest(dogValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                var dog = await _mediator.Send(new UpdateDogByIdCommand(dogToUpdate, updateDogId));

                if (dog == null)
                {
                    return NotFound($"Dog with Id:{updateDogId} does not exist in database");
                }
                return Ok(dog);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // Delete a specific dog
        //[Authorize]
        [HttpDelete]
        [Route("deleteDog/{deleteDogId}")]
        public async Task<IActionResult> DeleteDog(Guid deleteDogId)
        {
            var guidValidator = _guidValidator.Validate(deleteDogId);

            if (!guidValidator.IsValid)
            {
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                await _mediator.Send(new DeleteDogByIdCommand(deleteDogId));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("getDogsByWeightOrBreed")]
        public async Task<IActionResult> GetAllDogsByWeight(int? weight, string? breed)
        {
            return Ok(await _mediator.Send(new GetDogsByWeightOrBreedQuery { Weight = weight, Breed = breed }));
        }
    }
}
using Application.Commands.Dogs;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Validators.Dogs; ;
usi

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly DogValidator _dogValidator;
        internal readonly GuidValidator _guidValidator;
        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
            _dogValidator = dogValidator;
            _guidValidator = guidValidator;
        }

        // Get all dogs from database
        [HttpGet]
        [Route("getAllDogs")]

        public async Task<IActionResult> GetAllDogs() // metod för att hämta alla hundar i Db 
        {
            var guidValidator = _guidValidator.Validate(dogId); 
            try
            {
                return Ok(await _mediator.Send(new GetAllDogsQuery()));
                //return Ok("GET ALL DOGS");

            }
            catch (Exception ex)
            {

                throw new Exception("Get All Dogs did not work successfully as planned, check code. Error: " + ex.Message, ex);
            }

        }

        // Get a dog by Id
        [HttpGet] 
        [Route("getDogById/{dogId}")]  
        public async Task<IActionResult> GetDogById(Guid dogId)  // metod för att hämta en hund baserat på dess ID.
        {
            var guidValidator = _guidValidator.Validate(dogId);  // Validerar 'dogId' för att se så att deN är GUID.

            if (!guidValidator.IsValid)  //om valideringen misslyckas
            {
                // Om 'dogId' är ogiltigt, meddelande med varför det är ogiltigt.
                return BadRequest(guidValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            var dog = await _mediator.Send(new GetDogByIdQuery(dogId));  //  MediatR för att skicka en förfrågan för att get the dauuwg.

            if (dog == null)  // on hunden inte kunde hittas via id
            {
                return NotFound();  // returnera då ett error 404
            }

            try
            {
                return Ok(dog);  // Om hunden finns returnera 200 respons (den finns).
            }
            catch (Exception ex)  // extra som fångar upp andra fel 
            {
                
                throw new Exception(ex.Message);
            }
        }

        // Create a new dog 
        [HttpPost]
        [Route("addNewDog")]
        [ProducesResponseType(typeof(DogDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            var dogValidator = _dogValidator.Validate(newDog);

            if (!dogValidator.IsValid)
            {
                return BadRequest(dogValidator.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new AddDogCommand(newDog)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update a specific dog
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

            var dog = await _mediator.Send(new UpdateDogByIdCommand(dogToUpdate, updateDogId));

            if (dog == null)
            {
                return NotFound($"Dog with Id:{updateDogId} does not exist in database");
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

            return NotFound();
        }



    }
}

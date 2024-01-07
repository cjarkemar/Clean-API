using Application.Commands.AnimalUser.AddAnimalToUser;
using Application.Commands.AnimalUser.DeleteAnimalToUser;
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
            try
            {
                return Ok(await _mediator.Send(new GetAllAnimalsQuery()));
            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all animals from the database", ex);
            }
        }

        [HttpGet]
        [Route("getAllAnimalsById/{userId}")]
        public async Task<IActionResult> GetAnimalsById(Guid userId)
        {
            var animals = await _mediator.Send(new GetAllAnimalsByIdQuery(userId));

            return Ok(animals);
        }

        [HttpPost]
        [Route("ConnectAnimalToUser")]
        public async Task<IActionResult> JoinAnimal(Guid userId, Guid animalId)
        {
            try
            {
                var userGuid = _guidValidator.Validate(userId);


                var animalguid = _guidValidator.Validate(animalId);

                if (!userGuid.IsValid || !animalguid.IsValid)
                {
                    return BadRequest();
                }

                var connection = await _mediator.Send(new AddAnimalToUserCommand(userId, animalId));

                return Ok(connection);

            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while connection userId {userId} with animalId {animalId}", ex);
            }



        }
        [HttpDelete]
        [Route("RemoveConnectionBetweenAnimalAndUser")]
        public async Task<IActionResult> DeleteJoinedAnimal(Guid userId, Guid animalId)
        {
            try
            {
                var userGuid = _guidValidator.Validate(userId);

                var animalGuid = _guidValidator.Validate(animalId);

                if (!animalGuid.IsValid || !animalGuid.IsValid)
                {
                    return BadRequest();
                }

                await _mediator.Send(new DeleteAnimalToUserCommand(userId, animalId));

                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
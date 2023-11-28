﻿using Application.Commands.Dogs;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all dogs from database
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            return Ok(await _mediator.Send(new GetAllDogsQuery()));
            //return Ok("GET ALL DOGS");
        }

        // Get a dog by Id
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            var result = await _mediator.Send(new GetDogByIdQuery(dogId));
            if (result == null)
            {
                return NotFound("Den hunden finns inte med i listan");
            }
            return Ok(result);
        }

        // Create a new dog 
        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            return Ok(await _mediator.Send(new AddDogCommand(newDog)));
        }

        // Update a specific dog
        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            var updateResult = await _mediator.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId));
            if (updateResult == null)
            {
                return NotFound("Den hunden finns inte med i listan");
            }
            return Ok(updateResult);
        }

        [HttpDelete]
        [Route("deleteDog/{deleteDogId}")]
        public async Task<IActionResult> DeleteDog(Guid deleteDogId)
        {
            var result = await _mediator.Send(new DeleteDogByIdCommand(deleteDogId));
            if (result == null)
            {
                return NotFound("Den hunden finns inte med i listan"); 
            }
            return Ok(result);
        }



    }
}

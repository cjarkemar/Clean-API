// DeleteDogById
using System;
using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest<Dog>
    {
        public Guid DogId { get; }

        public DeleteDogByIdCommand(Guid dogId)
        {
            DogId = dogId;
        }
    }
}


using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommand : IRequest<Dog>
    {
        public UpdateDogByIdCommand(DogDto dogToUpdate, Guid id)
        {
            DogToUpdate = dogToUpdate;
            Id = id;
        }

        public DogDto DogToUpdate { get; }
        public Guid Id { get; }
    }
}
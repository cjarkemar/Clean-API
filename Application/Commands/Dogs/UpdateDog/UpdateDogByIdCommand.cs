using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommand: IRequest<Dog>
    {
        public DogDto UpdatedDog { get; }
        public Guid Id { get; }

        public UpdateDogByIdCommand(DogDto updatedDog, Guid id)
        {
            UpdatedDog = updatedDog;
            Id = id;
        }

        
    }
}

using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest<Dog>
    {
        public Guid Id { get; }

        public DeleteDogByIdCommand(Guid dogId)
        {
            Id = dogId;
        }
    }
}


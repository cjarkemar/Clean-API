using Domain.Models;
using Domain.Models.Animal;
using MediatR;

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommand : IRequest<Bird>
    {
        public DeleteBirdByIdCommand(Guid birdId)
        {
            Id = birdId;
        }

        public Guid Id { get; }
    }
}
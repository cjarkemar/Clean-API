using Application.Dtos;
using Domain.Models.Animal;
using MediatR;

namespace Application.Commands.Birds
{
    public class UpdateBirdByIdCommand : IRequest<Bird>
    {
        public BirdDto UpdatedBird { get; }
        public Guid Id { get; }

        public UpdateBirdByIdCommand(BirdDto updatedBird, Guid birdId)
        {
            UpdatedBird = updatedBird;
            Id = birdId;
        }
    }
}

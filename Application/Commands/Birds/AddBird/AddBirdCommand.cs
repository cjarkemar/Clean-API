using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Birds.AddBird
{
    public class AddBirdCommand : IRequest<Bird>
    {
        public AddBirdCommand(BirdDto newBird, Guid userId)
        {
            NewBird = newBird;
            UserId = userId;
        }

        public BirdDto NewBird { get; }
        public Guid UserId { get; }
    }
}
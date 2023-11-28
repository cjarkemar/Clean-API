using Application.Dtos;
using Domain.Models.Animal;
using MediatR;

namespace Application.Commands.Birds
{
    public class AddBirdCommand : IRequest<Bird>
    {
        public BirdDto NewBird { get; }

        public AddBirdCommand(BirdDto newBird)
        {
            NewBird = newBird;
        }
    }
}

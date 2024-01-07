using Application.Dtos;
using Domain.Models;
using MediatR;


namespace Application.Commands.Birds.UpdateBird
{
    public class UpdateBirdByIdCommand : IRequest<Bird>
    {
        public BirdDto BirdToUpdate { get; }
        public Guid Id { get; }

        public UpdateBirdByIdCommand(BirdDto birdToUpdate, Guid id)
        {
            BirdToUpdate = birdToUpdate;
            Id = id;
        }


    }
}
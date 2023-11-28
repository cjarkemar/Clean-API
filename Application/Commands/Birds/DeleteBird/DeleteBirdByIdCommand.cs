using MediatR;
using System;
using Domain.Models.Animal;

namespace Application.Commands.Birds
{
    public class DeleteBirdByIdCommand : IRequest<Bird>
    {
        public Guid Id { get; }

        public DeleteBirdByIdCommand(Guid birdId)
        {
            Id = birdId;
        }
    }
}

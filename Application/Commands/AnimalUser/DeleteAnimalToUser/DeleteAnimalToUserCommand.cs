// DeleteAnimalToUser
using System;
using Domain.Models.UserAnimal;
using MediatR;

namespace Application.Commands.AnimalUser.DeleteAnimalToUser
{
    public class DeleteAnimalToUserCommand : IRequest<UserAnimalJointTable>
    {
        public DeleteAnimalToUserCommand(Guid userId, Guid animalId)
        {
            UserId = userId;
            AnimalId = animalId;
        }

        public Guid UserId { get; }
        public Guid AnimalId { get; }
    }
}


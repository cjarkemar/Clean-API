// AddAnimalToUser
using System;
using Domain.Models.UserAnimal;
using MediatR;

namespace Application.Commands.AnimalUser.AddAnimalToUser
{
    public class AddAnimalToUserCommand : IRequest<UserAnimalJointTable>
    {

        public AddAnimalToUserCommand(Guid userId, Guid animalId)
        {
            UserId = userId;
            AnimalId = animalId;
        }

        public Guid UserId { get; }
        public Guid AnimalId { get; }
    }
}


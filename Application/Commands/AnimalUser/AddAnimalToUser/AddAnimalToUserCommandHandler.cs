
using System;
using Domain.Models.UserAnimal;
using Infrastructure.Repositories.Animals;
using MediatR;

namespace Application.Commands.AnimalUser.AddAnimalToUser
{
    public class AddAnimalToUserCommandHandler : IRequestHandler<AddAnimalToUserCommand, UserAnimalJointTable>
    {
        private readonly IAnimalRepository _animalRepository;
        public AddAnimalToUserCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public Task<UserAnimalJointTable> Handle(AddAnimalToUserCommand request, CancellationToken cancellationToken)
        {

            var connectionToCreate = _animalRepository.JoinAnimal(request.UserId, request.AnimalId);


            return connectionToCreate;
        }
    }
}


// DeleteAnimalToUserCommandHandler
using System;
using Domain.Models.UserAnimal;
using Infrastructure.Repositories.Animals;
using MediatR;

namespace Application.Commands.AnimalUser.DeleteAnimalToUser
{
    public class DeleteAnimalToUserCommandHandler : IRequestHandler<DeleteAnimalToUserCommand, UserAnimalJointTable>
    {
        private readonly IAnimalRepository _animalRepository;

        public DeleteAnimalToUserCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public Task<UserAnimalJointTable> Handle(DeleteAnimalToUserCommand request, CancellationToken cancellationToken)
        {
            var connectionToDelete = _animalRepository.DeleteJoinedAnimal(request.UserId, request.AnimalId);

            return connectionToDelete;
        }
    }
}


// IAnimalRepository
using System;
using Domain.Models.Animal;
using Domain.Models.UserAnimal;

namespace Infrastructure.Repositories.Animals
{
    public interface IAnimalRepository
    {
        Task<List<AnimalUserModel>> GetAllAnimals();
        Task<UserAnimalModel> GetAllAnimalsForUser(Guid id);
        Task<AnimalUserModel> GetAnimalById(Guid id);
        Task<UserAnimalJointTable> JoinAnimal(Guid userId, Guid animalId);
        Task<UserAnimalJointTable> DeleteJoinedAnimal(Guid userId, Guid animalId);

    }
}


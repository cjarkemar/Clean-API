// IAnimalRepository
using System;
using Domain.Models.Animal;
using Domain.Models.UserAnimal;

namespace Infrastructure.Repositories.Animals
{
    public interface IAnimalRepository
    {
        Task<List<AnimalModel>> GetAllAnimals();
        Task<List<UserAnimalModel>> GetAllUserAnimals();
        Task<List<AnimalUserModel>> GetAllAnimalUsers();
        Task<UserAnimalModel> GetAllAnimalsForUser(Guid Id);
    }
}


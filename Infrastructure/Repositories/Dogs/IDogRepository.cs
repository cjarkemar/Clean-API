using Domain.Models;

namespace Infrastructure.Repositories.Dogs
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllDogsAsync();
        Task<Dog> GetDogById(Guid id);
        Task<Dog> AddDog(Dog newDog, Guid id);
        Task<Dog> UpdateDog(Dog updateDog);
        Task<Dog> DeleteDogById(Guid id);
        Task<List<Dog>> GetDogsByWeightBreed(int? weight, string? breed);
    }
}

using Domain.Models;
namespace Infrastructure.RepositoryPatternFiles.DogsPattern
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllDogsAsync();
        Task<Dog> GetDogById(Guid id);
        Task<Dog> AddDog(Dog newDog);
        Task<Dog> DeleteDogById(Guid id);
        Task<Dog> UpdateDog(Dog updateDog);
    }
}


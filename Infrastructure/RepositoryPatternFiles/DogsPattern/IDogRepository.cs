
using Domain.Models;
namespace Infrastructure.RepositoryPatternFiles.DogsPattern
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllDogs(CancellationToken cancellationToken);
        Task<Dog> GetDogById(Guid id, CancellationToken cancellationToken);
      
        Task<Dog> AddDog(Dog newdog, CancellationToken cancellationToken);
        Task<Dog> UpdateDog(Guid id, string newName, bool Barks, string breed, int weight, string OwnerDogUserName, CancellationToken cancellationToken);

        Task<Dog> DeleteDogById(Guid id, CancellationToken cancellationToken);

        Task<List<Dog>> GetDogByProperty(string breed, int? weight, CancellationToken cancellationToken);
    }
}


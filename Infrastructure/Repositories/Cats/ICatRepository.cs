using Domain.Models;

namespace Infrastructure.Repositories.Cats
{
    public interface ICatRepository
    {
        Task<List<Cat>> GetAllCatsAsync();
        Task<Cat> GetCatById(Guid id);
        Task<Cat> AddCat(Cat newCat, Guid Id);
        Task<Cat> UpdateCat(Cat updateCat);
        Task<Cat> DeleteCatById(Guid id);
        Task<List<Cat>> GetCatsByWeightBreed(int? weight, string? breed);
    }
}
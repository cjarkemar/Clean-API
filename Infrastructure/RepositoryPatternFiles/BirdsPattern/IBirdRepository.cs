// IBirdRepository
using System;
using Domain.Models.Animal;

namespace Infrastructure.RepositoryPatternFiles.BirdsPattern
{
    public interface IBirdRepository
    {
        Task<List<Bird>> GetAllBirdsAsync();
        Task<Bird> GetBirdById(Guid id);
        Task<Bird> AddBird(Bird newBird);
        Task<Bird> DeleteBirdById(Guid id);
        Task<Bird> UpdateBird(Bird updateBird);
    }
}


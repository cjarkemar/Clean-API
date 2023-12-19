// ICatRepository
using System;
using Domain.Models;

namespace Infrastructure.RepositoryPatternFiles.CatsPattern
{
    public interface ICatRepository
    {
        Task<List<Cat>> GetAllCats(CancellationToken cancellationToken);
        Task<Cat> GetCatById(Guid id, CancellationToken cancellationToken);

        Task<Cat> AddCat(Cat newcat, CancellationToken cancellationToken);
        Task<Cat> UpdateCat(Guid id, string newName, bool LikesToPlay, string breed, int weight, string OwnerCatUserName, CancellationToken cancellationToken);

        Task<Cat> DeleteCat(Guid id, CancellationToken cancellationToken);

        Task<List<Cat>> GetCatByProperty(string breed, int? weight, CancellationToken cancellationToken);
    }
}


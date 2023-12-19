// CatRepository
using System;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Infrastructure.Database;
using Infrastructure.RepositoryPatternFiles.CatsPattern;
using Domain.Models.User;

namespace Infrastructure.RepositoryPatternFiles.CatsPattern
{
    public class CatRepository : ICatRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger<CatRepository> _logger;

        public CatRepository(RealDatabase realDatabase, ILogger<CatRepository> logger)
        {
            _realDatabase = realDatabase;
            _logger = logger;
        }
        public Task<List<Cat>> GetAllCats(CancellationToken cancellationToken)
        {
            try
            {
                List<Cat> allCatsFromDatabase = _realDatabase.Cats.ToList();

                foreach (var cat in allCatsFromDatabase)
                {
                    var CatOwner = _realDatabase.CatOwner.FirstOrDefault(uc => uc.CatId == cat.Id);

                    if (CatOwner != null)
                    {
                        var user = _realDatabase.Users.FirstOrDefault(u => u.Id == CatOwner.UserId);
                        cat.OwnerCatUserName = user!.Username;
                    }
                }

                return Task.FromResult(allCatsFromDatabase);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all cats from the database");
                throw new Exception("An error occurred while getting all cats from the database", ex);
            }
        }

        public Task<Cat> GetCatById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Cat wantedCat = _realDatabase.Cats.FirstOrDefault(cat => cat.Id == id)!;
                var CatOwner = _realDatabase.CatOwner.FirstOrDefault(uc => uc.CatId == wantedCat.Id);

                if (CatOwner != null)
                {
                    var user = _realDatabase.Users.FirstOrDefault(u => u.Id == CatOwner.UserId);
                    wantedCat.OwnerCatUserName = user!.Username;
                }
                return Task.FromResult(wantedCat);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all cats from the database");
                throw new Exception("An error occurred while getting all cats from the database", ex);
            }
        }

        public Task<List<Cat>> GetCatByProperty(string? breed, int? weight, CancellationToken cancellationToken)
        {
            try
            {
                List<Cat> filteredCats = _realDatabase.Cats
                                        .Where(c => (string.IsNullOrEmpty(breed) || c.Breed == breed) &&
                                        (weight == null || c.Weight >= weight))
                                        .ToList();

                foreach (var cat in filteredCats)
                {
                    var CatOwner = _realDatabase.CatOwner.FirstOrDefault(uc => uc.CatId == cat.Id);

                    if (CatOwner != null)
                    {
                        var user = _realDatabase.Users.FirstOrDefault(u => u.Id == CatOwner.UserId);
                        cat.OwnerCatUserName = user!.Username;
                    }
                }
                return Task.FromResult(filteredCats);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all catss from the database");
                throw new Exception("An error occurred while getting all catss from the database", ex);
            }
        }

        public Task<Cat> AddCat(Cat newcat, CancellationToken cancellationToken)
        {
            try
            {
                var user = _realDatabase.Users
                    .FirstOrDefault(u => u.Username == newcat.OwnerCatUserName);

                if (user == null)
                {
                    // Handle the case where the user is not found
                    _logger.LogError($"Username {newcat.OwnerCatUserName} not found");
                    throw new Exception($"Username {newcat.OwnerCatUserName} not found");
                }

                newcat.CatOwner= new List<CatOwner>
                {
                    new CatOwner { UserId = user.Id , CatId = newcat.Id},
                };

                _realDatabase.Cats.Add(newcat);
                _realDatabase.SaveChangesAsync(cancellationToken);

                return Task.FromResult(newcat);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while adding a cat to the database");
                throw new Exception("An error occurred while adding a cat to the database", ex);
            }
        }

        public Task<Cat> UpdateCat(Guid id, string newName, bool likesToPlay, string breed, int weight, string OwnerCatUserName, CancellationToken cancellationToken)
        {
            try
            {
                Cat catToUpdate = _realDatabase.Cats.FirstOrDefault(at => at.Id == id)!;

                catToUpdate.Name = newName;
                catToUpdate.LikesToPlay = likesToPlay;
                catToUpdate.Breed = breed;
                catToUpdate.Weight = weight;
                catToUpdate.OwnerCatUserName = OwnerCatUserName;

                var user = _realDatabase.Users
                    .FirstOrDefault(u => u.Username == catToUpdate.OwnerCatUserName);
                if (user != null)
                {
                    catToUpdate.CatOwner = new List<CatOwner>
                    {
                        new CatOwner { UserId = user.Id , CatId = catToUpdate.Id},
                    };
                }
                _realDatabase.SaveChangesAsync();

                return Task.FromResult(catToUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating a cat with ID {id} from the database");
                throw new Exception($"An error occurred while  cat with ID {id} from the database", ex);
            }
        }

        public Task<Cat> DeleteCat(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var catToDelete = _realDatabase.Cats.FirstOrDefault(cat => cat.Id == id);

                _realDatabase.Cats.Remove(catToDelete!);
                _realDatabase.SaveChangesAsync();
                return Task.FromResult(catToDelete!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a cat with ID {id} from the database");
                throw new Exception($"An error occurred while deleting a cat with ID {id} from the database", ex);
            }
        }



    }
}


using System;
using Domain.Models;
using Domain.Models.User;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.RepositoryPatternFiles.DogsPattern
{
    public class DogRepository : IDogRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger<DogRepository> _logger;

        public DogRepository(RealDatabase realDatabase, ILogger<DogRepository> logger)
        {
            _realDatabase = realDatabase;
            _logger = logger;
        }

        public Task<List<Dog>> GetAllDogs(CancellationToken cancellationToken)
        {
            try
            {
                List<Dog> allDogsFromDatabase = _realDatabase.Dogs.ToList();

                foreach (var dog in allDogsFromDatabase)
                {
                    var DogOwner = _realDatabase.DogOwner.FirstOrDefault(ud => ud.DogId == dog.Id);

                    if (DogOwner != null)
                    {
                        var user = _realDatabase.Users.FirstOrDefault(u => u.Id == DogOwner.UserId);
                        dog.OwnerDogUsername = user!.Username;
                    }
                }

                return Task.FromResult(allDogsFromDatabase);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all dogs from the database");
                throw new Exception("An error occurred while getting all dogs from the database", ex);
            }
        }

        public Task<Dog> GetDogById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Dog wantedDog = _realDatabase.Dogs.FirstOrDefault(dog => dog.Id == id)!;
                var DogOwner = _realDatabase.DogOwner.FirstOrDefault(ud => ud.DogId == wantedDog.Id);

                if (DogOwner != null)
                {
                    var user = _realDatabase.Users.FirstOrDefault(u => u.Id == DogOwner.UserId);
                    wantedDog.OwnerDogUsername = user!.Username;
                }
                return Task.FromResult(wantedDog);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all dogs from the database");
                throw new Exception("An error occurred while getting all dogs from the database", ex);
            }
        }

        public Task<List<Dog>> GetDogByProperty(string? breed, int? weight, CancellationToken cancellationToken)
        {
            try
            {
                List<Dog> DogsfilteredByProp= _realDatabase.Dogs
                                        .Where(d => (string.IsNullOrEmpty(breed) || d.Breed == breed) &&
                                        (weight == null || d.Weight >= weight))
                                        .ToList();

                foreach (var dog in DogsfilteredByProp)
                {
                    var DogOwner = _realDatabase.DogOwner.FirstOrDefault(ud => ud.DogId == dog.Id);

                    if (DogOwner == null)
                    {
                        var user = _realDatabase.Users.FirstOrDefault(u => u.Id == DogOwner.UserId);
                        dog.OwnerDogUsername = user!.Username;
                    }
                }

                return Task.FromResult(DogsfilteredByProp);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all dogs from the database");
                throw new Exception("An error occurred while getting all dogs from the database", ex);
            }
        }

        public async Task<Dog> AddDog(Dog newdog, CancellationToken cancellationToken)
        {
            try
            {
                var user = _realDatabase.Users
                    .FirstOrDefault(u => u.Username == newdog.OwnerDogUsername);

                if (user == null)
                {
                    // if the user is not found
                    _logger.LogError($"Username {newdog.OwnerDogUsername} not found");
                    throw new Exception($"Username {newdog.OwnerDogUsername} not found");
                }

                newdog.DogOwner = new List<DogOwner>
                {
                    new DogOwner { UserId = user.Id , DogId = newdog.Id},
                };

                _realDatabase.Dogs.Add(newdog);
                await _realDatabase.SaveChangesAsync(cancellationToken);

                return newdog;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while adding a dog to the database");
                throw new Exception("An error occurred while adding a dog to the database", ex);
            }
        }

        public async Task<Dog> UpdateDog(Guid id, string newName, bool Barks, string breed, int weight, string OwnerDogUserName, CancellationToken cancellationToken)
        {
            try
            {
                Dog dogToUpdate = _realDatabase.Dogs.FirstOrDefault(dog => dog.Id == id)!;

                dogToUpdate.Name = newName;
                dogToUpdate.Barks = Barks;
                dogToUpdate.Breed = breed;
                dogToUpdate.Weight = weight;
                dogToUpdate.OwnerDogUsername = OwnerDogUserName;

                var user = _realDatabase.Users
                    .FirstOrDefault(u => u.Username == dogToUpdate.OwnerDogUsername);
                if (user != null)
                {
                    dogToUpdate.DogOwner = new List<DogOwner>
                    {
                        new DogOwner { UserId = user.Id , DogId = dogToUpdate.Id},
                    };
                }

                await _realDatabase.SaveChangesAsync();

                return dogToUpdate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a dog with ID {id} from the database");
                throw new Exception($"An error occurred while deleting a dog with ID {id} from the database", ex);
            }
        }

        public async Task<Dog> DeleteDogById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var dogToDelete = _realDatabase.Dogs.FirstOrDefault(d => d.Id == id);

                _realDatabase.Dogs.Remove(dogToDelete!);
                await _realDatabase.SaveChangesAsync();
                return dogToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a dog with ID {id} from the database");
                throw new Exception($"An error occurred while deleting a dog with ID {id} from the database", ex);
            }

        }

    }

}
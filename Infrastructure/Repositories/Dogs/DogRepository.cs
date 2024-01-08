using Domain.Models;
using Domain.Models.UserAnimal;
using Infrastructure.Database.RealDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Dogs
{
    public class DogRepository : IDogRepository
    {
        private readonly RealDatabase _realDatabase;
        //Implement ILogger

        public DogRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<Dog> AddDog(Dog newDog, Guid id)
        {
            try
            {

                var user = await _realDatabase.Users.FirstOrDefaultAsync(x => x.UserId == id);

                if (user == null)
                {
                    throw new Exception("User not found");
                }

                var userAnimal = new UserAnimalJointTable { AnimalId = newDog.AnimalId, UserId = id };

                _realDatabase.UserAnimals.Add(userAnimal);

                _realDatabase.Dogs.Add(newDog);
                _realDatabase.SaveChanges();


                return await Task.FromResult(newDog);

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Dog> DeleteDogById(Guid id)
        {
            try
            {
                Dog dogToDelete = await GetDogById(id);

                _realDatabase.Dogs.Remove(dogToDelete);

                _realDatabase.SaveChanges();

                return await Task.FromResult(dogToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while deleting a dog with Id {id} from the database", ex);
            }
        }

        public async Task<List<Dog>> GetAllDogsAsync()
        {
            try
            {
                return await _realDatabase.Dogs.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while getting all dogs from the database", ex);
            }
        }

        public async Task<Dog> GetDogById(Guid dogId)
        {
            try
            {
                Dog? wantedDog = await _realDatabase.Dogs.FirstOrDefaultAsync(dog => dog.AnimalId == dogId);

                if (wantedDog == null)
                {
                    throw new Exception($"There was no dog with Id {dogId} in the database");
                }

                return await Task.FromResult(wantedDog);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while getting a dog by Id {dogId} from database", ex);
            }
        }

        public async Task<List<Dog>> GetDogsByWeightBreed(int? weight, string? breed)
        {
            try
            {
                var query = _realDatabase.Dogs.OfType<Dog>();

                if (weight.HasValue)
                {
                    query = query.Where(dog => dog.Weight >= weight.Value);
                }

                if (!string.IsNullOrEmpty(breed))
                {
                    query = query.Where(dog => dog.Breed == breed);
                }

                var dogs = await query.OrderByDescending(dog => dog.Weight).ToListAsync();

                return dogs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Dog> UpdateDog(Dog updatedDog)
        {
            try
            {
                _realDatabase.Dogs.Update(updatedDog);

                _realDatabase.SaveChanges();

                return await Task.FromResult(updatedDog);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while updating a dog by Id {updatedDog.AnimalId} from database", ex);
            }
        }
    }
}
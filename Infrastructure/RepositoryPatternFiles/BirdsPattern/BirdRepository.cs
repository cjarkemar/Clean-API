// BirdRepository
using System;
using Domain.Models.Animal;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoryPatternFiles.BirdsPattern
{
    public class BirdRepository : IBirdRepository
    {
        private readonly RealDatabase _realDatabase;
        //Implement ILogger

        public BirdRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<Bird> AddBird(Bird newBird)
        {
            try
            {
                _realDatabase.Birds.Add(newBird);
                _realDatabase.SaveChanges();
                return await Task.FromResult(newBird);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Bird> DeleteBirdById(Guid id)
        {
            try
            {
                Bird birdToDelete = await GetBirdById(id);

                _realDatabase.Birds.Remove(birdToDelete);

                _realDatabase.SaveChanges();

                return await Task.FromResult(birdToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while deleting a bird with Id {id} from the database", ex);
            }
        }

        public async Task<List<Bird>> GetAllBirdsAsync()
        {
            try
            {
                return await _realDatabase.Birds.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while getting all birds from the database", ex);
            }
        }

        public async Task<Bird> GetBirdById(Guid birdId)
        {
            try
            {
                Bird? wantedBird = await _realDatabase.Birds.FirstOrDefaultAsync(bird => bird.Id == birdId);

                if (wantedBird == null)
                {
                    throw new Exception($"There was no bird with Id {birdId} in the database");
                }

                return await Task.FromResult(wantedBird);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while getting a bird by Id {birdId} from database", ex);
            }
        }

        public async Task<Bird> UpdateBird(Bird updatedBird)
        {
            try
            {
                _realDatabase.Birds.Update(updatedBird);

                _realDatabase.SaveChanges();

                return await Task.FromResult(updatedBird);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while updating a bird by Id {updatedBird.Id} from database", ex);
            }
        }
    }
}


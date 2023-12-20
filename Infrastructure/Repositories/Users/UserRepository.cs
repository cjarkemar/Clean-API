using Domain.Models;
using Infrastructure.Authentication;
using Infrastructure.Database.RealDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Users
{
    internal class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public UserRepository(RealDatabase realDatabase, JwtTokenGenerator jwtTokenGenerator)
        {
            _realDatabase = realDatabase;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<User> AddUser(User user)
        {
            try
            {
                _realDatabase.Users.Add(user);
                _realDatabase.SaveChanges();

                return await Task.FromResult(user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<User> DeleteUser(Guid userId)
        {
            try
            {
                User userToDelete = await GetUserById(userId);

                _realDatabase.Users.Remove(userToDelete);

                _realDatabase.SaveChanges();

                return await Task.FromResult(userToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while deleting a user with Id {userId} from the database", ex);
            }
        }

        public async Task<User> GetUserById(Guid userId)
        {
            try
            {
                User? wantedUser = await _realDatabase.Users.FirstOrDefaultAsync(user => user.UserId == userId);

                if (wantedUser == null)
                {
                    throw new Exception($"There is no user with Id {userId} in the database");
                }

                return await Task.FromResult(wantedUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occed while getting a user by Id {userId} from database", ex);
            }
        }

        public async Task<string> SignInUser(string username, string password)
        {
            User? wantedUser = await _realDatabase.Users.Where(user => user.Username == username).FirstOrDefaultAsync();

            if (wantedUser == null)
            {
                return null!;
            }

            bool userPassword = BCrypt.Net.BCrypt.Verify(password, wantedUser.Password);

            if (!userPassword)
            {
                return null!;
            }

            return _jwtTokenGenerator.GenerateJwtToken(wantedUser);
        }

        public async Task<User> UpdateUser(User updatedUser)
        {
            try
            {
                _realDatabase.Users.Update(updatedUser);

                _realDatabase.SaveChanges();

                return await Task.FromResult(updatedUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while updating a user by Id {updatedUser.UserId} from database", ex);
            }
        }
    }
}
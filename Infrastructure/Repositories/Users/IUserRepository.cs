using Domain.Models;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(Guid userId);
        Task<User> GetUserById(Guid userId);
        Task<string> SignInUser(string username, string password);
    }
}

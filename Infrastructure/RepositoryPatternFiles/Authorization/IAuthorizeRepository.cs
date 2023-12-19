using Domain.Models;
using Domain.Models.User;

namespace Infrastructure.RepositoryPatternFiles.Authorization
{
    public interface IAuthorizeRepository
    {
        User AuthenticateUser(string username, string password);
        string GenerateJwtToken(User user);
    }
}
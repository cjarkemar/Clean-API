// IUserRepository
using System;
using Domain.Models.User;

namespace Infrastructure.RepositoryPatternFiles.UserPattern
{
   
       public interface IUserRepository
        {
            Task<List<User>> GetAllUsers();
            Task<User> RegisterUser(User userToRegister);
        }
    
}


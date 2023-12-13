using Domain.Models;
using Domain.Models.User;
using MediatR;

namespace Application.Queries.Users.GetAll
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}

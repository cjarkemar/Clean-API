using Domain.Models.Animal;
using Domain.Models.UserAnimal;
using MediatR;

namespace Application.Queries.Animals.GetAll
{
    public class GetAllAnimalsQuery : IRequest<List<AnimalUserModel>>
    {
    }
}
using Domain.Models.Animal;
using MediatR;

namespace Application.Queries.Animals.GetAll
{
    public class GetAllAnimalsQuery : IRequest<List<AnimalModel>>
    {
    }
}
using Domain.Models.UserAnimal;
using MediatR;

namespace Application.Queries.Animals.GetAllAnimalsForUser
{
    public class GetAllAnimalsByIdQuery : IRequest<UserAnimalModel>
    {
        public Guid Id { get; }

        public GetAllAnimalsByIdQuery(Guid userId)
        {
            Id = userId;
        }

    }
}

using Domain.Models.Animal;
using MediatR;

namespace Application.Queries.Birds.GetById
{
    public class GetBirdByIdQuery : IRequest<Bird>
    {
        public Guid Id { get; }

        public GetBirdByIdQuery(Guid birdId)
        {
            Id = birdId;
        }
    }
}


using Domain.Models;
using MediatR;

namespace Application.Queries.Dogs.GetById
{
    public class GetDogByIdQuery : IRequest<Dog>
    {
        public Guid Id { get; }

        public GetDogByIdQuery(Guid dogId)
        {
            Id = dogId;
        }

        
    }
}

using Domain.Models;
using MediatR;

namespace Application.Queries.Cats.GetById
{
    public class GetCatByIdQuery : IRequest<Cat>
    {
        public Guid Id { get; }

        public GetCatByIdQuery(Guid catId)
        {
            Id = catId;
        }
    }
}


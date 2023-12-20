using Domain.Models;
using MediatR;

namespace Application.Queries.Cats.GetWeight
{
    public class GetCatsByWeightOrBreedQuery : IRequest<List<Cat>>
    {
        public int? Weight { get; set; }
        public string? Breed { get; set; }
    }
}

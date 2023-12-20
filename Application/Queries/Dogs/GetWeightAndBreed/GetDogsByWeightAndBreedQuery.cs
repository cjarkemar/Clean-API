using Domain.Models;
using MediatR;

namespace Application.Queries.Dogs.GetWeightAndBreed
{
    public class GetDogsByWeightOrBreedQuery : IRequest<List<Dog>>
    {
        public int? Weight { get; set; }
        public string? Breed { get; set; }
    }
}

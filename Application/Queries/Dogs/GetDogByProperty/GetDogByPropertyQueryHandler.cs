// GetDogByPropertyQueryHandler
using System;
using Domain.Models;
using Infrastructure.RepositoryPatternFiles.DogsPattern;
using MediatR;

namespace Application.Queries.Dogs.GetDogByProperty
{
    public sealed class GetDogByPropertyQueryHandler : IRequestHandler<GetDogByPropertyQuery, List<Dog>>
    {
        private readonly IDogRepository _dogRepository;

        public GetDogByPropertyQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<List<Dog>> Handle(GetDogByPropertyQuery request, CancellationToken cancellationToken)
        {
            List<Dog> dogs = await _dogRepository.GetDogByProperty(request.breed, request.weight, cancellationToken);

            return dogs;
        }
    }
}


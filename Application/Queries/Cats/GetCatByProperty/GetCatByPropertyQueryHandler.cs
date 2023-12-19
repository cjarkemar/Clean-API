// GetCatByPropertyQueryHandler
using System;
using Domain.Models;
using Infrastructure.RepositoryPatternFiles.CatsPattern;
using MediatR;

namespace Application.Queries.Cats.GetCatByProperty
{
    public sealed class GetCatByPropertyQueryHandler : IRequestHandler<GetCatByPropertyQuery, List<Cat>>
    {
        private readonly ICatRepository _catRepository;

        public GetCatByPropertyQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<List<Cat>> Handle(GetCatByPropertyQuery request, CancellationToken cancellationToken)
        {
            List<Cat> cats = await _catRepository.GetCatByProperty(request.breed, request.weight, cancellationToken);

            return cats;
        }
    }
}


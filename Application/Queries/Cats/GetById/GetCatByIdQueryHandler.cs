using Domain.Models;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Queries.Cats.GetById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly ICatRepository _catRepository;

        public GetCatByIdQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = await _catRepository.GetCatById(request.Id);

            if (wantedCat == null)
            {
                return null!;
            }

            return wantedCat;
        }
    }
}
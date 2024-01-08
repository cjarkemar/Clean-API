using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Queries.Dogs
{
    internal sealed class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly IDogRepository _dogRepository;


        public GetAllDogsQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            //List<Dog> allDogsFromSqlDatabase = _dogRepository.GetAllDogs();

            List<Dog> alldogs = await _dogRepository.GetAllDogsAsync();

            //List<Dog> allDogsFromMockDatabase = _mockDatabase.Dogs;
            return alldogs;
        }
    }
}
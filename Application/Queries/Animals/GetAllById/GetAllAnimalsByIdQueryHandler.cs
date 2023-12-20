using Domain.Models.UserAnimal;
using Infrastructure.Database.RealDatabase;
using Infrastructure.Repositories.Animals;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Queries.Animals.GetAllAnimalsForUser
{
    public class GetAllAnimalsByIdQueryHandler : IRequestHandler<GetAllAnimalsByIdQuery, UserAnimalModel>
    {
        private readonly IDogRepository _dogRepository;
        private readonly SqlDatabase _sqlDatabase;

        private readonly IAnimalRepository _animalRepository;

        public GetAllAnimalsByIdQueryHandler(IDogRepository dogRepository, SqlDatabase sqlDatabase, IAnimalRepository animalRepository)
        {
            _dogRepository = dogRepository;
            _sqlDatabase = sqlDatabase;
            _animalRepository = animalRepository;
        }
        public async Task<UserAnimalModel> Handle(GetAllAnimalsByIdQuery request, CancellationToken cancellationToken)
        {
            var animals = await _animalRepository.GetAllAnimalsForUser(request.Id);

            return animals;
        }
    }
}
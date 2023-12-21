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
        private readonly RealDatabase _realDatabase;

        private readonly IAnimalRepository _animalRepository;

        public GetAllAnimalsByIdQueryHandler(IDogRepository dogRepository, RealDatabase realDatabase, IAnimalRepository animalRepository)
        {
            _dogRepository = dogRepository;
            _realDatabase = realDatabase;
            _animalRepository = animalRepository;
        }
        public async Task<UserAnimalModel> Handle(GetAllAnimalsByIdQuery request, CancellationToken cancellationToken)
        {
            var animals = await _animalRepository.GetAllAnimalsForUser(request.Id);

            return animals;
        }
    }
}
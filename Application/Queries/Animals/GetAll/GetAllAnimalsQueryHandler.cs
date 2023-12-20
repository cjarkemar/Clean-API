using Domain.Models.Animal;
using Infrastructure.Repositories.Animals;
using MediatR;

namespace Application.Queries.Animals.GetAll
{
    public class GetAllAnimalsQueryHandler : IRequestHandler<GetAllAnimalsQuery, List<AnimalModel>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAllAnimalsQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<AnimalModel>> Handle(GetAllAnimalsQuery request, CancellationToken cancellationToken)
        {
            List<AnimalModel> allAnimals = await _animalRepository.GetAllAnimals();

            return allAnimals;
        }
    }
}
using Domain.Models.Animal;
using Domain.Models.UserAnimal;
using Infrastructure.Repositories.Animals;
using MediatR;

namespace Application.Queries.Animals.GetAll
{
    public class GetAllAnimalsQueryHandler : IRequestHandler<GetAllAnimalsQuery, List<AnimalUserModel>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAllAnimalsQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<AnimalUserModel>> Handle(GetAllAnimalsQuery request, CancellationToken cancellationToken)
        {
            List<AnimalUserModel> allAnimals = await _animalRepository.GetAllAnimals();

            return allAnimals;
        }
    }
}
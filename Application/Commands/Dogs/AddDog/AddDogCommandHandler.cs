using Application.Validators.Dog;
using Domain.Models;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Commands.Dogs
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;


        public AddDogCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;

        }
        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {

            Dog dogToCreate = new()
            {
                Breed = request.NewDog.Breed,
                Weight = request.NewDog.Weight,
                AnimalId = Guid.NewGuid(),
                Name = request.NewDog.Name

            };


            var createdDog = await _dogRepository.AddDog(dogToCreate, request.Id);


            return createdDog;
        }

    }
}
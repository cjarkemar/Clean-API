
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using Infrastructure.RepositoryPatternFiles.DogsPattern;
using Application.Validators.Dogs;


namespace Application.Commands.Dogs
{
    public sealed class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        private readonly DogValidator _dogValidator;

        public AddDogCommandHandler(IDogRepository dogRepository, DogValidator dogValidator)
        {
            _dogRepository = dogRepository;

            _dogValidator = dogValidator;
        }

        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            Dog dogToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewDog.Name,
                Barks = request.NewDog.Barks,
                Breed = request.NewDog.Breed,
                Weight = request.NewDog.Weight,
                OwnerDogUsername = request.NewDog.OwnerDogUserName,
            };

            await _dogRepository.AddDog(dogToCreate, cancellationToken);

            return dogToCreate;
        }
    }
}

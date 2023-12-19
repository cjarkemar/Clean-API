using Domain.Models;
using Infrastructure.Database;
using MediatR;
using Infrastructure.RepositoryPatternFiles.DogsPattern;
using Application.Validators.Dogs;


namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        private readonly DogValidator _dogValidator;

        public UpdateDogByIdCommandHandler(IDogRepository dogRepository, DogValidator validator)
        {
            _dogRepository = dogRepository;
            _dogValidator = validator;
        }
        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            var Id = request.Id;
            var Name = request.UpdatedDog.Name;
            var Barks = request.UpdatedDog.Barks;
            var Breed = request.UpdatedDog.Breed;
            int Weight = request.UpdatedDog.Weight;
            var OwnerDogUserName = request.UpdatedDog.OwnerDogUserName;

            Dog dogToUpdate = await _dogRepository.UpdateDog(Id, Name, Barks, Breed, Weight, OwnerDogUserName, cancellationToken);

            return dogToUpdate;
        }
    }
}

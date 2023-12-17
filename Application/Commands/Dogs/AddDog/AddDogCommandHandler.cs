
using Domain.Models;
using Infrastructure.Database.RealDatabase;
using MediatR;
using Infrastructure.RepositoryPatternFiles.DogsPattern;
using Application.Validators.Dogs;


namespace Application.Commands.Dogs
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        //private readonly RealDatabase _realDatabase;
        private readonly IDogRepository _dogRepository;
        private readonly DogValidator _dogValidator;
       

        public AddDogCommandHandler(IDogRepository dogRepository, DogValidator validator)
        {
            //_realDatabase = realDatabase;
            _dogRepository = dogRepository;
            _dogValidator = validator;
        }

        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            Dog dogToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewDog.Name
            };

            var createdDog = await _dogRepository.AddDog(dogToCreate);

            return createdDog;
        }
    }
}

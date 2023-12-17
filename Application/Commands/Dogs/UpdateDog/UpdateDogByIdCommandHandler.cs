using Domain.Models;
using Infrastructure.Database.RealDatabase;
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

            Dog dogToUpdate = await _dogRepository.GetDogById(request.Id);

            if (dogToUpdate == null)
            {
                return null!;
            }


            dogToUpdate.Name = request.DogToUpdate.Name;

            var updatedDog = await _dogRepository.UpdateDog(dogToUpdate);

            return updatedDog;
        }
    }
}

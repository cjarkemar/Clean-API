using Application.Validators.Dog;
using Domain.Models;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;


        public UpdateDogByIdCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;

        }
        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {

            Dog dogToUpdate = await _dogRepository.GetDogById(request.Id);

            if (dogToUpdate == null)
            {
                return null!;
            }

            dogToUpdate.Breed = request.DogToUpdate.Breed;
            dogToUpdate.Weight = request.DogToUpdate.Weight;
            dogToUpdate.Name = request.DogToUpdate.Name;


            await _dogRepository.UpdateDog(dogToUpdate);

            return dogToUpdate;
        }
    }
}
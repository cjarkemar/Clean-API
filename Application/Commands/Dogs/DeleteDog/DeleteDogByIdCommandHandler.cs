using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using MediatR;
using Infrastructure.RepositoryPatternFiles.DogsPattern;
using Application.Validators.Dogs;

namespace Application.Commands.Dogs
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        private readonly DogValidator _dogValidator;

        public DeleteDogByIdCommandHandler(IDogRepository dogRepository, DogValidator validator)
        {
            _dogRepository = dogRepository;
            _dogValidator = validator;
        }

        public async Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            var dogToDelete = await _dogRepository.DeleteDogById(request.Id, cancellationToken);

            return dogToDelete;
        }
    }
}

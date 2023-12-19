
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using Infrastructure.RepositoryPatternFiles.CatsPattern;
using Application.Validators.Cats;


namespace Application.Commands.Cats
{
    public sealed class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly ICatRepository _catRepository;
        private readonly CatValidator _catValidator;

        public AddCatCommandHandler(ICatRepository catRepository, CatValidator catValidator)
        {
            _catRepository = catRepository;

            _catValidator = catValidator;
        }

        public Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            Cat catToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewCat.Name,
                LikesToPlay = request.NewCat.LikesToPlay,
                Breed = request.NewCat.Breed,
                Weight = request.NewCat.Weight,
                OwnerCatUserName = request.NewCat.OwnerCatUserName,
            };

            _catRepository.AddCat(catToCreate, cancellationToken);

            return Task.FromResult(catToCreate);
        }
    }
}

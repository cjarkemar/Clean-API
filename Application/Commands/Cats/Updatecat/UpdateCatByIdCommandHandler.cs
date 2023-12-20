using Domain.Models;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public UpdateCatByIdCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = await _catRepository.GetCatById(request.Id);

            if (catToUpdate == null)
            {
                return null!;
            }

            catToUpdate.Name = request.CatToUpdate.Name;
            catToUpdate.LikesToPlay = request.CatToUpdate.LikesToPlay;

            await _catRepository.UpdateCat(catToUpdate);

            return catToUpdate;
        }
    }
}
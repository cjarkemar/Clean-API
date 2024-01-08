using Domain.Models;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public DeleteCatByIdCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {

            var deletedCat = await _catRepository.DeleteCatById(request.Id);

            return deletedCat;
        }
    }
}
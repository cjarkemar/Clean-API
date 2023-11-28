using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Cats
{
    public class UpdateCatByIdCommand : IRequest<Cat>
    {
        public CatDto UpdatedCat { get; }
        public Guid Id { get; }

        public UpdateCatByIdCommand(CatDto updatedCat, Guid catId)
        {
            UpdatedCat = updatedCat;
            Id = catId;
        }
    }
}

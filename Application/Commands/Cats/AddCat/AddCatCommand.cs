using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Cats.AddCat
{
    public class AddCatCommand : IRequest<Cat>
    {
        public AddCatCommand(CatDto newCat, Guid userId)
        {
            NewCat = newCat;
            UserId = userId;
        }

        public CatDto NewCat { get; }
        public Guid UserId { get; }
    }
}
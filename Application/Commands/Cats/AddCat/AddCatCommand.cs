using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Cats
{
    public class AddCatCommand : IRequest<Cat>
    {
        public CatDto NewCat { get; }

        public AddCatCommand(CatDto newCat)
        {
            NewCat = newCat;
        }
    }
}


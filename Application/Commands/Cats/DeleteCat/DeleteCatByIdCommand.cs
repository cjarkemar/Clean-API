using Domain.Models;
using MediatR;

namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommand : IRequest<Cat>
    {

        public Guid Id { get; }


        public DeleteCatByIdCommand(Guid id)
        {
            Id = id;
        }

    }
}
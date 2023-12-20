using Domain.Models;
using MediatR;

namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommand : IRequest<Cat>
    {
        public DeleteCatByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{

    public class DeleteDogByIdCommand : IRequest<Dog>
    {
        public DeleteDogByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }

    }

}
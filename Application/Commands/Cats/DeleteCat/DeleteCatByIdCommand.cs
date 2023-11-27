using MediatR;
using Domain.Models;
using System;

namespace Application.Commands.Cats
{
    public class DeleteCatByIdCommand : IRequest<Cat>
    {
        public Guid Id { get; }

        public DeleteCatByIdCommand(Guid catId)
        {
            Id = catId;
        }
    }
}


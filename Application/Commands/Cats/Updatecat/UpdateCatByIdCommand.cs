using Application.Dtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommand : IRequest<Cat>
    {

        public CatDto CatToUpdate { get; }
        public Guid Id { get; }

        public UpdateCatByIdCommand(CatDto catToUpdate, Guid id)
        {
            CatToUpdate = catToUpdate;
            Id = id;
        }


    }
}
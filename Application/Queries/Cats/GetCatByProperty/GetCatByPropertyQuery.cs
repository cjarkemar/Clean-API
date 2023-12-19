// GetCatByPropertyQuery
using System;
using Domain.Models;
using MediatR;

namespace Application.Queries.Cats.GetCatByProperty
{
    public class GetCatByPropertyQuery : IRequest<List<Cat>>
    {
        public GetCatByPropertyQuery(string Breed, int? Weight)
        {
            breed = Breed;
            weight = Weight;
        }

        public string breed { get; }
        public int? weight { get; }
    }
}


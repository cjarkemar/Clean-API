// GetDogByPropertyQuery
using System;
using Domain.Models;
using MediatR;

namespace Application.Queries.Dogs.GetDogByProperty
{
    public class GetDogByPropertyQuery : IRequest<List<Dog>>
    {
        public GetDogByPropertyQuery(string Breed, int? Weight)
        {
            breed = Breed;
            weight = Weight;
        }

        public string breed { get; }
        public int? weight { get; }
    }
}


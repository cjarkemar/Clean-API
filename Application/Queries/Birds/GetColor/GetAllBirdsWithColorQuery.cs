//using Domain.Models;
using Domain.Models;
using MediatR;

namespace Application.Queries.Birds.GetColor
{
    public class GetAllBirdsWithColorQuery : IRequest<List<Bird>>
    {
        public string Color { get; set; }
    }
}
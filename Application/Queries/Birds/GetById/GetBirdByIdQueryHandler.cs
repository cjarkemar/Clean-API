using Domain.Models.Animal;
using Infrastructure.Database.RealDatabase;
using MediatR;


namespace Application.Queries.Birds.GetById
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {
        private readonly RealDatabase _realDatabase;

        public GetBirdByIdQueryHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = _realDatabase.Birds.FirstOrDefault(bird => bird.Id == request.Id);
            return Task.FromResult(wantedBird);
        }
    }
}

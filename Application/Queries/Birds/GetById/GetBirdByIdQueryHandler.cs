using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;


namespace Application.Queries.Birds.GetById
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public GetBirdByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = _mockDatabase.Birds.FirstOrDefault(bird => bird.Id == request.Id);
            return Task.FromResult(wantedBird);
        }
    }
}

using Application.Queries.Birds.GetAll;
using Domain.Models.Birds;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Birds
{
    internal class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllBirdsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirdsFromMockDatabase = _mockDatabase.Birds;
            return Task.FromResult(allBirdsFromMockDatabase);
        }
    }
}

using Application.Queries.Birds.GetAll;
using Domain.Models.Animals.Birds;
using Infrastructure.Repositories.Animals.Birds;
using MediatR;

namespace Application.Queries.Birds
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly IBirdRepository _birdRepository;

        public GetAllBirdsQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirds = await _birdRepository.GetAllBirds();
            return allBirds;
        }
    }
}

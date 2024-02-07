using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Birds;
using MediatR;

namespace Application.Queries.Birds.GetById
{
    public class GetBirdByIQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public GetBirdByIQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = await _birdRepository.GetBirdById(request.Id);
            return wantedBird;
        }
    }
}

using Application.Queries.Dogs.GetAll;
using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Dogs;
using MediatR;

namespace Application.Queries.Dogs.GetAll
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly IDogRepository _dogRepository;

        public GetAllDogsQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromRealDatabase = await _dogRepository.GetAllDogs();
            return allDogsFromRealDatabase;
        }
    }
}

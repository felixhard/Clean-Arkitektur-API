using Application.Queries.Cats.GetAll;
using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Cats;
using MediatR;

namespace Application.Queries.Cats
{
    internal class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly ICatRepository _catRepository;

        public GetAllCatsQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }
        public async Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCats = await _catRepository.GetAllCats();
            return allCats;
        }
    }
}

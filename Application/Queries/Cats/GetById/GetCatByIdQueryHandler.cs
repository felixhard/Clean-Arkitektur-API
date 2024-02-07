using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Cats;
using MediatR;

namespace Application.Queries.Cats.GetById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly ICatRepository _catRepository;

        public GetCatByIdQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = await _catRepository.GetCatById(request.Id);
            return wantedCat;
        }
    }
}

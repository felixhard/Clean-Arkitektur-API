using Application.Queries.Cats.GetByBreedAndWeight;
using Application.Queries.Cats;
using Domain.Models.Animals.Cats;
using MediatR;
using Infrastructure.Repositories.Animals.Cats;


namespace Application.Queries.Cats.GetByBreedAndWeight
{
    public class GetCatsByBreedAndWeightQueryHandler : IRequestHandler<GetCatsByBreedAndWeightQuery, List<Cat>>
    {
        private readonly ICatRepository _catRepository;

        public GetCatsByBreedAndWeightQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<List<Cat>> Handle(GetCatsByBreedAndWeightQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsByBreedAndWeightFromDB = await _catRepository.GetCatsByBreedAndWeight(request.Breed, request.Weight);

            return allCatsByBreedAndWeightFromDB;
        }
    }
}
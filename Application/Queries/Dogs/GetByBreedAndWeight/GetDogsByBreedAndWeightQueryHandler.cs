using Application.Queries.Dogs.GetByBreedAndWeight;
using Application.Queries.Dogs;
using Domain.Models.Animals.Dogs;
using MediatR;
using Infrastructure.Repositories.Animals.Dogs;


namespace Application.Queries.Dogs.GetByBreedAndWeight
{
    public class GetDogsByBreedAndWeightQueryHandler : IRequestHandler<GetDogsByBreedAndWeightQuery, List<Dog>>
    {
        private readonly IDogRepository _dogRepository;

        public GetDogsByBreedAndWeightQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<List<Dog>> Handle(GetDogsByBreedAndWeightQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsByBreedAndWeightFromDB = await _dogRepository.GetDogsByBreedAndWeight(request.Breed, request.Weight);

            return allDogsByBreedAndWeightFromDB;
        }
    }
}
using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Queries.Cats.GetByBreedAndWeight
{
    public class GetCatsByBreedAndWeightQuery : IRequest<List<Cat>>
    {
        public int? Weight { get; }
        public string Breed { get; }
        public GetCatsByBreedAndWeightQuery(int? weight, string breed)
        {
            Weight = weight;
            Breed = breed;
        }
    }
}
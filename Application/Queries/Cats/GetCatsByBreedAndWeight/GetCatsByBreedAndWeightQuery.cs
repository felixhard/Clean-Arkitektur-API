using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Queries.Cats.GetByBreedAndWeight
{
    public class GetCatsByBreedAndWeightQuery : IRequest<List<Cat>>
    {
        public int? Weight { get; set; }
        public string Breed { get; set; }

    }
}
using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Queries.Dogs.GetByBreedAndWeight
{
    public class GetDogsByBreedAndWeightQuery : IRequest<List<Dog>>
    {
        public int? Weight { get; set; }
        public string? Breed { get; set; }
    }
}
using Application.Dtos.AnimalDtos.CatDto;
using MediatR;
using Domain.Models.Animals.Cats;

namespace Application.Commands.Animals.Cats.AddCat
{
    public class AddCatCommand : IRequest<Cat>
    {
        public AddCatCommand(CatDto newCat)
        {
            NewCat = newCat;
        }
        public CatDto NewCat { get; }
    }
}
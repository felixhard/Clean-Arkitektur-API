using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Dogs;
using MediatR;

namespace Application.Commands.Animals.Dogs.AddDog
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        public AddDogCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Dog dogToCreate = new()
                {
                    AnimalId = Guid.NewGuid(),
                    Name = request.NewDog.Name,
                    Breed = request.NewDog.Breed,
                    Weight = request.NewDog.Weight,
                };

                await _dogRepository.AddDog(dogToCreate);
                return dogToCreate;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
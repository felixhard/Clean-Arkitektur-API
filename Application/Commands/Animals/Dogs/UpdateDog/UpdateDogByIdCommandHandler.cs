using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Dogs;
using MediatR;


namespace Application.Commands.Animals.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        public UpdateDogByIdCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            // Find the dog to update
            Dog dogToUpdate = await _dogRepository.GetDogById(request.Id);
            if (dogToUpdate == null)
            {
                return null!;
            }

            dogToUpdate.Name = request.UpdatedDog.Name;
            dogToUpdate.Breed = request.UpdatedDog.Breed;
            dogToUpdate.Weight = request.UpdatedDog.Weight;

            var updatedDog = await _dogRepository.UpdateDog(dogToUpdate);

            return updatedDog;
        }
    }
}
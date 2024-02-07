using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Dogs;
using MediatR;

namespace Application.Commands.Animals.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        public DeleteDogByIdCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _dogRepository.GetDogById(request.Id).Result;

            var deletedDog = await _dogRepository.DeleteDog(dogToDelete);

            return deletedDog;
        }
    }
}
using MediatR;
using Infrastructure.Database;
using Domain.Models.Dogs;
using Application.Commands.Dogs;

namespace Application.Commands.Dogs.DeleteDog
{
    internal class DeleteDogByIDCommandHandler : IRequestHandler<DeleteDogByIDCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;
    
        public DeleteDogByIDCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Dog> Handle(DeleteDogByIDCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.ID)!; 
            _mockDatabase.Dogs.Remove(dogToDelete);

            return Task.FromResult(dogToDelete);
        }
    }

}

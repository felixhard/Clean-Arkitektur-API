using MediatR;
using Infrastructure.Database;
using Domain.Models.Dogs;
using Application.Commands.Dogs;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.ID)!;
            _mockDatabase.Dogs.Remove(dogToDelete);

            return Task.FromResult(dogToDelete);
        }
    }

}

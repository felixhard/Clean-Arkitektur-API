using Application.Queries.Dogs.GetById;
using Infrastructure.Database;
using Application.Commands.Dogs.DeleteDog;

namespace Test.DogTests.CommandTest
{
    public class TestToDeleteDog
    {
        private MockDatabase _mockDatabase;
        private GetDogByIdQueryHandler _GetDogByIDQueryHandler;
        private DeleteDogByIdCommandHandler _DeleteDogByIdCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetDogByIDQueryHandler = new GetDogByIdQueryHandler(_mockDatabase);
            _DeleteDogByIdCommandHandler = new DeleteDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Test_To_Delete_Dog()
        {
            // Arrange
            var dogId = new Guid("02345678-1234-5678-1234-567812345678");
            var queryDeleteDogById = new DeleteDogByIdCommand(dogId);
            var queryGetDogById = new GetDogByIdQuery(dogId);

            // Act
            var result = await _DeleteDogByIdCommandHandler.Handle(queryDeleteDogById, CancellationToken.None);
            var result2 = await _GetDogByIDQueryHandler.Handle(queryGetDogById, CancellationToken.None);

            // Assert
            Assert.That(result2, Is.Null);
            Assert.That(result.Id, Is.EqualTo(dogId));

        }
    }
}

using Application.Commands.Dogs.UpdateDog;
using Application.Queries.Dogs.GetById;
using Infrastructure.Database;
using Application.Dtos.DogDto;

namespace Test.DogTests.CommandTest
{
    public class TestToUpdateDog
    {
        private MockDatabase _mockDatabase;
        private GetDogByIdQueryHandler _handler;
        private UpdateDogByIdCommandHandler _UpdateDogByIdCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetDogByIdQueryHandler(_mockDatabase);
            _UpdateDogByIdCommandHandler = new UpdateDogByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Test_To_Update_Dog()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");
            DogDto dogDto = new DogDto { Name = "UpdatedDogName" };

            var queryUpdateDogById = new UpdateDogByIdCommand(dogDto, dogId);

            // Act
            var result = await _UpdateDogByIdCommandHandler.Handle(queryUpdateDogById, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(dogDto.Name));
        }
    }
}

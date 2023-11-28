using Infrastructure.Database;
using Application.Queries.Dogs.GetById;
using Application.Commands.Dogs.AddDog;
using Application.Dtos.AnimalDtos.DogDto;

namespace Test.DogTests.CommandTest
{
    public class AddDogTest
    {
        private MockDatabase _mockDatabase;
        private GetDogByIdQueryHandler _handler;
        private AddDogCommandHandler _AddDogCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetDogByIdQueryHandler(_mockDatabase);
            _AddDogCommandHandler = new AddDogCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Test_To_Add_Dog()
        {
            // Arrange
            DogDto dogDto = new DogDto { Name = "AddedDogTestName" };

            var query = new AddDogCommand(dogDto);

            // Act
            var result = await _AddDogCommandHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(dogDto.Name));
        }

    }
}

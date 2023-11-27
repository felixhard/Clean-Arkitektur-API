using Infrastructure.Database;
using Application.Commands.Dogs.AddDog;
using Application.Dtos.DogDto;
using Application.Queries.Dogs.GetById;
using Application.Commands.Dogs;

namespace Test.DogTests.CommandTest
{
    public class AddDogTest
    {
        private MockDatabase _mockDatabase;
        private GetDogByIdQueryHandler _handler;
        //Fortstätt här imorgon.......................................
        private AddDogCommandHandler _AddDogCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetDogByIdQueryHandler(_mockDatabase);
            _AddDogCommandHandler = AddDogCommandHandler(_mockDatabase);
        }
        
        [Test]
        public async Task Dog_Add_Test()
        {
            // Arrange
            DogDto dogDto = new DogDto { Name = "AddedDogTestName" };

            var query = new AddDogCommand(dogDto);

            // Act
            var result = await _AddDogCommandHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(dogDto.Name));
        }

    }
}

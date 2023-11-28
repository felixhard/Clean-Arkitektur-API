using Infrastructure.Database;
using Application.Queries.Birds.GetById;
using Application.Commands.Birds.AddBird;
using Application.Dtos.AnimalDtos.BirdDto;

namespace Test.BirdTests.CommandTest
{
    public class AddBirdTest
    {
        private MockDatabase _mockDatabase;
        private GetBirdByIdQueryHandler _handler;
        private AddBirdCommandHandler _AddBirdCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetBirdByIdQueryHandler(_mockDatabase);
            _AddBirdCommandHandler = new AddBirdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Test_To_Add_Bird()
        {
            // Arrange
            BirdDto birdDto = new BirdDto { Name = "AddedBirdTestName" };

            var query = new AddBirdCommand(birdDto);

            // Act
            var result = await _AddBirdCommandHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(birdDto.Name));
        }

    }
}

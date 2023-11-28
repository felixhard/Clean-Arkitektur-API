using Application.Commands.Birds.UpdateBird;
using Application.Dtos.AnimalDtos.BirdDto;
using Domain.Models.Birds;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class TestToUpdateBird
    {
        private MockDatabase _mockDatabase;
        private UpdateBirdByIdCommandHandler _updateBirdByIdCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _updateBirdByIdCommandHandler = new UpdateBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Test_To_Update_Bird()
        {
            // Arrange
            var birdId = new Guid("12300078-1234-5678-1234-567812345678");
            BirdDto updatedBirdDto = new BirdDto { Name = "UpdatedBirdName", CanFly = true };

            // Set up a mock bird in the database
            _mockDatabase.Birds.Add(new Bird { Id = birdId });

            var queryUpdateBirdById = new UpdateBirdByIdCommand(updatedBirdDto, birdId);

            // Act
            var result = await _updateBirdByIdCommandHandler.Handle(queryUpdateBirdById, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo(updatedBirdDto.Name));
            Assert.That(result!.CanFly, Is.EqualTo(updatedBirdDto.CanFly));
        }
    }
}
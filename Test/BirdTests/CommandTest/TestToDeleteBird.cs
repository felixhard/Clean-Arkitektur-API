using Application.Queries.Birds.GetById;
using Infrastructure.Database;
using Application.Commands.Birds.DeleteBird;

namespace Test.BirdTests.CommandTest
{
    public class TestToDeleteBird
    {
        private MockDatabase _mockDatabase;
        private GetBirdByIdQueryHandler _GetBirdByIDQueryHandler;
        private DeleteBirdByIdCommandHandler _DeleteBirdByIdCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetBirdByIDQueryHandler = new GetBirdByIdQueryHandler(_mockDatabase);
            _DeleteBirdByIdCommandHandler = new DeleteBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Test_To_Delete_Bird()
        {
            // Arrange
            var birdId = new Guid("12300078-1234-5678-1234-567812345678");
            var queryDeleteBirdById = new DeleteBirdByIdCommand(birdId);
            var queryGetBirdById = new GetBirdByIdQuery(birdId);

            // Act
            var result = await _DeleteBirdByIdCommandHandler.Handle(queryDeleteBirdById, CancellationToken.None);
            var result2 = await _GetBirdByIDQueryHandler.Handle(queryGetBirdById, CancellationToken.None);

            // Assert
            Assert.That(result2, Is.Null);
            Assert.That(result.Id, Is.EqualTo(birdId));

        }
    }
}

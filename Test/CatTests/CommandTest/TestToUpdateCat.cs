using Application.Commands.Cats.UpdateCat;
using Application.Queries.Cats.GetById;
using Infrastructure.Database;
using Application.Dtos.AnimalDtos.CatDto;

namespace Test.CatTests.CommandTest
{
    public class TestToUpdateCat
    {
        private MockDatabase _mockDatabase;
        private GetCatByIdQueryHandler _handler;
        private UpdateCatByIdCommandHandler _UpdateCatByIdCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetCatByIdQueryHandler(_mockDatabase);
            _UpdateCatByIdCommandHandler = new UpdateCatByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Test_To_Update_Cat()
        {
            // Arrange
            var catId = new Guid("00045678-1234-5678-1234-567812345678");
            CatDto catDto = new CatDto { Name = "UpdatedCatName" };

            var queryUpdateCatById = new UpdateCatByIdCommand(catDto, catId);

            // Act
            var result = await _UpdateCatByIdCommandHandler.Handle(queryUpdateCatById, CancellationToken.None);

            // Assert
            //Här fick jag även lägga in en assert för bool "LikesToPlay"
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(catDto.Name));
            Assert.That(result.LikesToPlay, Is.EqualTo(catDto.LikesToPlay));
        }
    }
}

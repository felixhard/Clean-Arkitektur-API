using Application.Queries.Cats.GetById;
using Infrastructure.Database;
using Application.Commands.Cats.DeleteCat;

namespace Test.CatTests.CommandTest
{
    public class TestToDeleteCat
    {
        private MockDatabase _mockDatabase;
        private GetCatByIdQueryHandler _GetCatByIDQueryHandler;
        private DeleteCatByIdCommandHandler _DeleteCatByIdCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetCatByIDQueryHandler = new GetCatByIdQueryHandler(_mockDatabase);
            _DeleteCatByIdCommandHandler = new DeleteCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Test_To_Delete_Cat()
        {
            // Arrange
            //Måste här använda ett annat Id från den i GetCatByIdTests.
            var catId = new Guid("01223456-1234-5678-1234-567812345678");
            var queryDeleteCatById = new DeleteCatByIdCommand(catId);
            var queryGetCatById = new GetCatByIdQuery(catId);

            // Act
            var result = await _DeleteCatByIdCommandHandler.Handle(queryDeleteCatById, CancellationToken.None);
            var result2 = await _GetCatByIDQueryHandler.Handle(queryGetCatById, CancellationToken.None);

            // Assert
            Assert.That(result2, Is.Null);
            Assert.That(result.Id, Is.EqualTo(catId));

        }
    }
}

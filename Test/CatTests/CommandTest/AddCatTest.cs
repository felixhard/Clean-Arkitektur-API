using Infrastructure.Database;
using Application.Queries.Cats.GetById;
using Application.Dtos.AnimalDtos.CatDto;
using Application.Commands.Animals.Cats.AddCat;

namespace Test.CatTests.CommandTest
{
    public class AddCatTest
    {
        private MockDatabase _mockDatabase;
        private GetCatByIdQueryHandler _handler;
        private AddCatCommandHandler _AddCatCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetCatByIdQueryHandler(_mockDatabase);
            _AddCatCommandHandler = new AddCatCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Test_To_Add_Cat()
        {
            // Arrange
            CatDto catDto = new CatDto { Name = "AddedCatTestName" };

            var query = new AddCatCommand(catDto);

            // Act
            var result = await _AddCatCommandHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(catDto.Name));
        }

    }
}

using Application.Queries.Cats.GetById;
using Domain.Models.Animals.Cats;
using FakeItEasy;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Cats;

namespace Test.CatTests.QueryTest
{
    [TestFixture]
    public class GetCatByIdTests
    {

        [Test]
        public async Task Handle_ValidId_ReturnCorrectCat()
        {
            var guid = Guid.NewGuid();

            var cat = new Cat { Name = "Robert", Breed = "Huskatt" };

            var catRepository = A.Fake<ICatRepository>();

            var handler = new GetCatByIdQueryHandler(catRepository);

            A.CallTo(() => catRepository.GetCatById(guid)).Returns(cat);

            var command = new GetCatByIdQuery(guid);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<Cat>());
            Assert.That(result.Name.Equals("Robert"));
            Assert.That(result.Breed.Equals("Huskatt"));

        }
    }
}

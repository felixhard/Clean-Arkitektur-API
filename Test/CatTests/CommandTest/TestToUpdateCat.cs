using Application.Commands.Animals.Cats.UpdateCat;
using Application.Dtos.AnimalDtos.CatDto;
using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;
using FakeItEasy;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class TestToUpdateCat
    {
        [Test]
        public async Task Handle_Update_Correct_Cat_By_Id()
        {

            var guid = new Guid("71985024-636e-4e26-b6f9-b9c8550ac738");

            var cat = new Cat
            {
                AnimalId = new Guid("71985024-636e-4e26-b6f9-b9c8550ac738"),
                Name = "Billy",
                Breed = "Skogskatt",
                Weight = 5,
                LikesToPlay = false
            };

            var catDto = new CatDto { Name = "Niklas", Breed = "Huskatt", Weight = 3, LikesToPlay = false };

            var catRepository = A.Fake<ICatRepository>();

            var handler = new UpdateCatByIdCommandHandler(catRepository);

            A.CallTo(() => catRepository.GetCatById(cat.AnimalId)).Returns(cat);

            A.CallTo(() => catRepository.UpdateCat(cat)).Returns(cat);

            var command = new UpdateCatByIdCommand(catDto, guid);


            var result = await handler.Handle(command, CancellationToken.None);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name.Equals("Niklas"));
            Assert.That(result.Breed.Equals("Huskatt"));
            Assert.That(result.Weight.Equals(3));
            Assert.That(result.LikesToPlay.Equals(false));
            Assert.That(result, Is.TypeOf<Cat>());
        }
    }
}

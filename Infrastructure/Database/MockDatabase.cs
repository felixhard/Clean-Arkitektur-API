using Domain.Models.Dogs;
using Domain.Models.Cats;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }

        private static List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Björn"},
            new Dog { Id = Guid.NewGuid(), Name = "Patrik"},
            new Dog { Id = Guid.NewGuid(), Name = "Alfred"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"},
            new Dog { Id = new Guid("02345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests2"}
        };

        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        private static List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Charlie", LikesToPlay = false},
            new Cat { Id = Guid.NewGuid(), Name = "Niklas", LikesToPlay = true},
            new Cat { Id = Guid.NewGuid(), Name = "Johan", LikesToPlay = true},
            new Cat { Id = new Guid("00045678-1234-5678-1234-567812345678"), Name = "TestCatForUnitTests", LikesToPlay = true},
            new Cat { Id = new Guid("01223456-1234-5678-1234-567812345678"), Name = "TestCatForUnitTests2", LikesToPlay = true}
        };
    }
}

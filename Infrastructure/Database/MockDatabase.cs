/*using Domain.Models.Dogs;
using Domain.Models.Users;
using Domain.Models.Animal.Birds;
using Domain.Models.Animal;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<User> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        private static List<User> allUsers = new()
        {
            new User { Id = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), Username = "Felix", Password = "password123", Authorized = true, Role = "Admin" },
            new User { Id = new Guid("047425eb-15a5-4310-9d25-e281ab036868"), Username = "NotAnAdmin", Password = "password123", Authorized = false, Role = "User"}
        };
        /*public List<Dog> Dogs
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

        public List<Bird> Birds
        {
            get { return allBirds; }
            set { allBirds = value; }
        }

        private static List<Bird> allBirds = new()
        {
            new Bird { Id = Guid.NewGuid(), Name = "Pingvin", CanFly = false},
            new Bird { Id = Guid.NewGuid(), Name = "Fiskmås", CanFly = true},
            new Bird { Id = Guid.NewGuid(), Name = "Koltrast", CanFly = true},
            new Bird { Id = new Guid("12300078-1234-5678-1234-567812345678"), Name = "TestBirdForUnitTests", CanFly = true},
            new Bird { Id = new Guid("31223006-1234-5678-1234-567812345678"), Name = "TestBirdForUnitTests2", CanFly = true}
        };
    }
}
*/

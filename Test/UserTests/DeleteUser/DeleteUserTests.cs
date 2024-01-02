using Domain.Models.Users;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Users;
using Moq;

namespace Test.Repository.UserTests.DeleteUser
{
    internal class DeleteUserTests
    {
        private UserRepository _userRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _userRepository = new UserRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.Users.Remove(It.IsAny<User>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }
        [Test]
        public async Task User_Deleted()
        {
            // Arrange
            List<User> users =
            [
                new User() { Id = new Guid("12345678-1234-5678-1234-567812345674"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" },
                new User() { Id = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Username = "admin1", Password = "Password123!", Authorized = true, Role = "admin" },
            ];

            var Id = new Guid("12345678-1234-5678-1234-567812345674");

            var userToDelete = users.Where(user => user.Id == Id).FirstOrDefault();

            var result = await _userRepository.DeleteUser(userToDelete!);

            Assert.That(result, Is.Not.Null);
            _mockRealDatabase.Verify(db => db.Users.Remove(It.IsAny<User>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
        public async Task User_Not_Found()
        {
            // Arrange
            List<User> users =
            [
                new User() { Id = new Guid("12345678-1234-5678-1234-567812345674"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" },
                new User() { Id = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Username = "admin1", Password = "Password123!", Authorized = true, Role = "admin" },
            ];
            var invalidId = Guid.NewGuid();

            var userToDelete = users.Where(user => user.Id == invalidId).FirstOrDefault();

            var result = await _userRepository.DeleteUser(userToDelete!);

            Assert.That(result, Is.Not.Null);
        }
    }
}
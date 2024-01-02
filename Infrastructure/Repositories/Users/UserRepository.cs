using Domain.Models.Users;
using Infrastructure.Database.MySQLDatabase;

namespace Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<User> RegisterUser(User userToRegister)
        {
            try
            {
                _realDatabase.Users.Add(userToRegister);
                _realDatabase.SaveChanges();
                return await Task.FromResult(userToRegister);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                List<User> allUsersFromDatabase = _realDatabase.Users.ToList();
                return await Task.FromResult(allUsersFromDatabase);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<User> GetUserById(Guid id)
        {
            try
            {
                var wantedUser = _realDatabase.Users.Where(user => user.Id == id).FirstOrDefault()!;
                return await Task.FromResult(wantedUser);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }
        public async Task<User> UpdateUser(User userToUpdate)
        {
            try
            {
                _realDatabase.Users.Update(userToUpdate);
                _realDatabase.SaveChanges();
                return await Task.FromResult(userToUpdate);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }
        public async Task<User> DeleteUser(User userToDelete)
        {
            try
            {
                _realDatabase.Users.Remove(userToDelete);
                _realDatabase.SaveChanges();
                return await Task.FromResult(userToDelete);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }
    }
}

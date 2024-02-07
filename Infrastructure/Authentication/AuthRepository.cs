using Infrastructure.Database;
using Domain.Models.Users;
using Microsoft.Extensions.Configuration;
using Infrastructure.Database.MySQLDatabase;

public class AuthRepository
{
    private readonly IConfiguration _configuration;
    private readonly RealDatabase _realDatabase;

    public AuthRepository(IConfiguration configuration, RealDatabase realDatabase)
    {
        _configuration = configuration;
        _realDatabase = realDatabase;
    }

    public User AuthenticateUser(string username, string password)
    {
        var user = _realDatabase.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            throw new Exception("User not found");
        }
        return user;
    }
}
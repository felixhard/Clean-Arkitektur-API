using Application.Dtos.AnimalUsersDto;
using Domain.Models.AnimalUsers;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.AnimalUsers
{
    public class AnimalUserRepository : IAnimalUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public AnimalUserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<AnimalUser> AddAnimalUser(AnimalUser animalUser)
        {
            try
            {
                _realDatabase.AnimalUsers.Add(animalUser);
                _realDatabase.SaveChanges();
                return await Task.FromResult(animalUser);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<AnimalUser> DeleteAnimalUser(Guid id)
        {
            try
            {
                AnimalUser animalUserToDelete = await GetAnimalUserByID(id);

                _realDatabase.AnimalUsers.Remove(animalUserToDelete);
                _realDatabase.SaveChanges();

                return await Task.FromResult(animalUserToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting an animal user with Id {id} from the database", ex);
            }
        }

        public async Task<List<GetAllAnimalUsersDto>> GetAllAnimalUsers()
        {
            try
            {
                var animalUsers = await _realDatabase.AnimalUsers
                    .Select(au => new GetAllAnimalUsersDto
                    {
                        Username = au.User.Username,
                        AnimalName = au.Animal.Name,
                    })
                    .ToListAsync();
                return animalUsers;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all animal users from the database", ex);
            }
        }

        public async Task<AnimalUser> GetAnimalUserByID(Guid id)
        {
            try
            {
                AnimalUser? wantedAnimalUser = await _realDatabase.AnimalUsers.FirstOrDefaultAsync(animalUser => animalUser.Key == id);

                if (wantedAnimalUser == null)
                {
                    throw new Exception($"There was no animal user with Id {id} in the database");
                }

                return await Task.FromResult(wantedAnimalUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting an animal user with Id {id} from the database", ex);
            }
        }

        public async Task<AnimalUser> UpdateAnimalUser(AnimalUser updateAnimalUser)
        {
            try
            {
                _realDatabase.AnimalUsers.Update(updateAnimalUser);
                _realDatabase.SaveChanges();
                return await Task.FromResult(updateAnimalUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating an animal user by Id {updateAnimalUser.Key} from the database", ex);
            }
        }
    }
}
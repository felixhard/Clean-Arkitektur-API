using Application.Dtos.AnimalUsersDto;
using Domain.Models.AnimalUsers;


namespace Infrastructure.Repositories.AnimalUsers
{
    public interface IAnimalUserRepository
    {
        Task<AnimalUser> AddAnimalUser(AnimalUser animalUserToCreate);
        Task<AnimalUser> UpdateAnimalUser(AnimalUser animalUserToUpdate);
        Task<List<GetAllAnimalUsersDto>> GetAllAnimalUsers();
        Task<AnimalUser> GetAnimalUserByID(Guid id);
        Task<AnimalUser> DeleteAnimalUser(Guid id);
    }
}

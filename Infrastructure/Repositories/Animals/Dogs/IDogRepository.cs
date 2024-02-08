using Domain.Models;
using Domain.Models.Animals.Dogs;

namespace Infrastructure.Repositories.Animals.Dogs
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllDogs();
        Task<List<Dog>> GetDogsByBreedAndWeight(string breed, int? weight);
        Task<Dog> GetDogById(Guid id);
        Task<Dog> AddDog(Dog newDog);
        Task<Dog> UpdateDog(Dog updateDog);
        Task<Dog> DeleteDog(Guid id);
    }
}
using Domain.Models.Animals.Cats;

namespace Infrastructure.Repositories.Animals.Cats
{
    public interface ICatRepository
    {
        Task<List<Cat>> GetAllCats();
        Task<Cat> GetCatById(Guid id);
        Task<Cat> AddCat(Cat catToAdd);
        Task<Cat> UpdateCat(Cat catToUpdate);
        Task<Cat> DeleteCat(Cat catToDelete);
        Task<List<Cat>> GetCatsByBreedAndWeight(string breed, int? weight);
    }
}
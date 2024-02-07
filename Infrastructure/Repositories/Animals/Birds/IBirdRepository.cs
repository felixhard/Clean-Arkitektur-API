using Domain.Models.Animals.Birds;

namespace Infrastructure.Repositories.Animals.Birds
{
    public interface IBirdRepository
    {
        Task<List<Bird>> GetAllBirds();
        Task<List<Bird>> GetBirdsByColor(string color);
        Task<Bird> GetBirdById(Guid id);
        Task<Bird> AddBird(Bird newBird);
        Task<Bird> UpdateBird(Bird updateBird);
        Task<Bird> DeleteBird(Guid id);
    }
}

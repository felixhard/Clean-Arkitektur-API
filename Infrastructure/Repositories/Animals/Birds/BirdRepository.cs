using Domain.Models.Animals.Birds;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Animals.Birds
{
    public class BirdRepository : IBirdRepository
    {
        private readonly RealDatabase _realDatabase;
        public BirdRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<Bird> AddBird(Bird newBird)
        {
            try
            {
                _realDatabase.Birds.Add(newBird);
                _realDatabase.SaveChanges();
                return await Task.FromResult(newBird);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Bird> GetBirdById(Guid id)
        {
            try
            {
                Bird? wantedBird = await _realDatabase.Birds.FirstOrDefaultAsync(bird => bird.AnimalId == id);

                if (wantedBird == null)
                {
                    throw new Exception($"There was no bird with Id {id} in the database");
                }

                return await Task.FromResult(wantedBird);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting a bird with Id {id} from database", ex);
            }
        }

        public async Task<Bird> DeleteBird(Guid id)
        {
            try
            {
                Bird birdToDelete = await GetBirdById(id);

                _realDatabase.Birds.Remove(birdToDelete);

                _realDatabase.SaveChanges();

                return await Task.FromResult(birdToDelete);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while deleting a bird with Id {id} from the database", ex);
            }
        }
        public async Task<List<Bird>> GetAllBirds()
        {
            try
            {
                return await _realDatabase.Birds.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all birds from the database", ex);
            }
        }
        public async Task<List<Bird>> GetBirdsByColor(string color)
        {
            try
            {
                var birds = await _realDatabase.Birds
                    .Where(bird => bird.Color.ToUpper() == color.ToUpper())
                    .OrderByDescending(bird => bird.Name)
                    .ThenByDescending(bird => bird.AnimalId)
                    .ToListAsync();

                if (birds == null)
                {
                    throw new Exception($"There was no bird with {color} color in the database");
                }

                return birds;
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting a bird with {color} color from database", ex);
            }
        }
        public Task<Bird> UpdateBird(Bird updateBird)
        {
            try
            {
                _realDatabase.Birds.Update(updateBird);

                _realDatabase.SaveChanges();

                return Task.FromResult(updateBird);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while updating a bird by Id {updateBird.AnimalId} from database", ex);
            }
        }

    }
}

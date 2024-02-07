using Domain.Models.Animals.Cats;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Animals.Cats
{
    public class CatRepository : ICatRepository
    {
        private readonly RealDatabase _realDatabase;

        public CatRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<Cat> AddCat(Cat catToAdd)
        {
            try
            {
                _realDatabase.Cats.Add(catToAdd);
                _realDatabase.SaveChanges();
                return await Task.FromResult(catToAdd);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Cat> DeleteCat(Cat catToDelete)
        {
            try
            {
                _realDatabase.Cats.Remove(catToDelete);

                _realDatabase.SaveChanges();

                return await Task.FromResult(catToDelete);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while deleting a cat with Id {catToDelete.AnimalId} from the database", ex);
            }
        }

        public async Task<List<Cat>> GetAllCats()
        {
            try
            {
                return await _realDatabase.Cats.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all cats from the database", ex);
            }
        }

        public async Task<Cat> GetCatById(Guid id)
        {
            try
            {
                Cat? wantedCat = await _realDatabase.Cats.FirstOrDefaultAsync(cat => cat.AnimalId == id);

                if (wantedCat == null)
                {
                    throw new Exception($"There was no cat with Id {id} in the database");
                }

                return await Task.FromResult(wantedCat);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting a cat with Id {id} from database", ex);
            }
        }

        public async Task<List<Cat>> GetCatsByBreedAndWeight(string breed, int? weight)
        {
            try
            {
                var catsQuery = _realDatabase.Cats.AsQueryable();

                if (!string.IsNullOrEmpty(breed))
                {
                    catsQuery = catsQuery.Where(cat => cat.Breed == breed);
                }

                if (weight.HasValue)
                {
                    catsQuery = catsQuery.Where(cat => cat.Weight >= weight);
                }

                var cats = await catsQuery.OrderByDescending(cat => cat.Weight).ToListAsync();

                return cats;
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while getting cats of {breed} breed and weight from the database", ex);
            }
        }
        public Task<Cat> UpdateCat(Cat updateCat)
        {
            try
            {
                _realDatabase.Cats.Update(updateCat);

                _realDatabase.SaveChanges();

                return Task.FromResult(updateCat);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while updating a Cat by Id {updateCat.AnimalId} from database", ex);
            }
        }
    }
}